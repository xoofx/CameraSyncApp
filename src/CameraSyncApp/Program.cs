// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ByteSizeLib;
using MediaDevices;
using Spectre.Console;
using XenoAtom.CommandLine;

if (!OperatingSystem.IsWindows())
{
    AnsiConsole.MarkupLine("[red]This tool is only available on Windows[/]");
    return 1;
}

bool verbose = false;

string? namePostFix = null;
string? targetFolder = null;

const string _ = "";

var commandApp = new CommandApp("CameraSyncApp", "CameraSyncApp is a lightweight command-line tool for Windows that simplifies syncing photos and videos.")
        {
            new CommandUsage("Usage: {NAME} [Options] command "),
            _,
            new HelpOption(),
            new VersionOption(),
            { "verbose", "Display verbose progress", v => verbose = v is not null },
            _,
            "Available commands:",
            new Command("sync", "Synchronize images and videos from DCIM/Camera folders from all connected devices")
            {
                new CommandUsage("Usage: {NAME} [Options] --name NAME --output OUTPUT_FOLDER>"),
                _,
                new HelpOption(),
                { "o|output=", "The output {DIRECTORY}..", v => targetFolder = v },
                { "n|name=", "The post-fix name appended to each folder created per month.", v => namePostFix = v },
                // Action for the commit command
                (ctx, arguments) =>
                {
                    if (targetFolder is null)
                    {
                        AnsiConsole.MarkupLine("[red]Missing --output folder option[/]");
                        return ValueTask.FromResult(1);
                    }

                    if (namePostFix is null)
                    {
                        AnsiConsole.MarkupLine("[red]Missing --name option[/]");
                        return ValueTask.FromResult(1);
                    }

                    var devices = MediaDevices.MediaDevice.GetDevices().ToList();
                    if (devices.Count == 0)
                    {
                        AnsiConsole.MarkupLine("[red]No devices found.[/]");
                        return ValueTask.FromResult(1);
                    }

                    var keepUntil = DateTime.Now; //DateTime.Now.AddMonths(-3);

                    bool hasErrors = false;

                    foreach (var device in devices)
                    {
                        device.Connect();

                        try
                        {

                            var markupLine = $"Device `[green]{Markup.Escape(device.FriendlyName)}[/]` (Model: [green]{Markup.Escape(device.Model ?? string.Empty)}[/])";

                            if (!TryGetCameraFolder(device, out var cameraFolder, out var errorMessage))
                            {
                                AnsiConsole.MarkupLine($"{markupLine}. [red]{Markup.Escape(errorMessage)}[/]. [red]✕[/]");
                                hasErrors = true;
                                continue;
                            }
                            else
                            {
                                AnsiConsole.MarkupLine($"{markupLine}. [green]\u2713[/]");
                            }

                            var filesIt = cameraFolder.EnumerateFiles();
                            var files = new List<MediaFileInfo>();
                            var clock = Stopwatch.StartNew();
                            AnsiConsole.Status().Start("Listing files", ctx =>
                            {
                                foreach (var file in filesIt)
                                {
                                    files.Add(file);
                                    ctx.Status($"Listing [yellow]{files.Count}[/] files");
                                    ctx.Refresh();
                                }
                            });
                            clock.Stop();
                            AnsiConsole.MarkupLine($"Collected [yellow]{files.Count}[/] files in [yellow]{clock.Elapsed}s[/]");

                            int totalCount = 0;
                            int processedCount = 0;

                            AnsiConsole.Status().Start("Processing files", statusCtx =>
                            {
                                foreach (var file in files)
                                {
                                    if (!file.LastWriteTime.HasValue)
                                    {
                                        AnsiConsole.WriteLine();
                                        AnsiConsole.WriteLine($"Cannot process {file.FullName} - File does not have a datetime");
                                        continue;
                                    }

                                    var lastWriteTime = file.LastWriteTime.Value;
                                    if (lastWriteTime < keepUntil)
                                    {
                                        var folder = Path.Combine(targetFolder, $"{lastWriteTime.Year:0000}-{lastWriteTime.Month:00}-{namePostFix}");
                                        if (!Directory.Exists(folder))
                                        {
                                            Directory.CreateDirectory(folder);
                                        }

                                        var dest = Path.Combine(folder, Path.GetFileName(file.Name));
                                        var destInfo = new FileInfo(dest);
                                        var needToCopy = !destInfo.Exists || destInfo.Length != unchecked((long)file.Length) || destInfo.CreationTime != lastWriteTime || destInfo.LastWriteTime != lastWriteTime;
                                        if (needToCopy)
                                        {
                                            statusCtx.Status($"Copying {file.FullName} to {dest} ({ByteSize.FromBytes(file.Length)})");
                                            {
                                                using var outputStream = File.Create(dest);
                                                file.CopyTo(outputStream);
                                            }
                                            File.SetCreationTime(dest, lastWriteTime);
                                            File.SetLastWriteTime(dest, lastWriteTime);

                                            processedCount++;
                                            statusCtx.Refresh();
                                        }
                                    }

                                    totalCount++;
                                }
                            });

                            AnsiConsole.MarkupLine($"New files: [yellow]{processedCount}[/] synced. Total files: [yellow]{totalCount}[/] synced");
                        }
                        finally
                        {
                            if (device.IsConnected)
                            {
                                device.Disconnect();
                            }
                        }
                    }

                    return ValueTask.FromResult(hasErrors ? 1 : 0);
                }
            },
            new Command("list", "List devices with DCIM/Camera folders from all connected devices")
            {
                new CommandUsage("Usage: {NAME}"),
                _,
                new HelpOption(),
                // Action for the commit command
                (ctx, arguments) =>
                {
                    var devices = MediaDevices.MediaDevice.GetDevices().ToList();
                    if (devices.Count == 0)
                    {
                        AnsiConsole.MarkupLine("[red]No devices found.[/]");
                        return ValueTask.FromResult(1);
                    }

                    bool hasErrors = false;

                    foreach (var device in devices)
                    {
                        device.Connect();

                        try
                        {
                            var markupLine = $"Device `[green]{Markup.Escape(device.FriendlyName)}[/]` (Model: [green]{Markup.Escape(device.Model ?? string.Empty)}[/])";
                            
                            if (!TryGetCameraFolder(device, out var cameraFolder, out var errorMessage))
                            {
                                AnsiConsole.MarkupLine($"{markupLine}. [red]{Markup.Escape(errorMessage)}[/].");
                                hasErrors = true;
                            }
                            else
                            {
                                AnsiConsole.MarkupLine($"{markupLine}. [green]\u2713[/]");
                            }
                        }
                        finally
                        {
                            if (device.IsConnected)
                            {
                                device.Disconnect();
                            }
                        }

                    }

                    return ValueTask.FromResult(hasErrors ? 1 : 0);
                }
            }
        };

var width = Console.IsOutputRedirected ? 80 : Math.Max(80, Console.WindowWidth);
var optionWidth = Console.IsOutputRedirected || width == 80 ? 29 : 36;

try
{
    return await commandApp.RunAsync(args, new CommandRunConfig(width, optionWidth));
}
catch (Exception ex)
{
    AnsiConsole.Foreground = Color.Red;
    AnsiConsole.WriteLine($"Unexpected error: {ex.Message}");
    AnsiConsole.ResetColors();
    if (verbose)
    {
        AnsiConsole.WriteLine(ex.ToString());
    }
    return 1;
}



static bool TryGetCameraFolder(MediaDevice device, [NotNullWhen(true)] out MediaDirectoryInfo? cameraFolder, [NotNullWhen(false)] out string? errorMessage)
{
    cameraFolder = null;
    var rootFolder = device.GetRootDirectory();
    var folders = rootFolder.EnumerateDirectories().ToList();
    if (folders.Count == 0)
    {
        errorMessage = "No folders found (Unlock the device maybe?)";
        return false;
    }

    foreach (var folder in folders)
    {
        var name = folder.Name;

        if (device.TryGetDirectoryInfo($@"\{name}\DCIM\Camera", out cameraFolder))
        {
            errorMessage = null;
            return true;
        }
    }

    errorMessage = "No DCIM/Camera folder found";
    return false;
}