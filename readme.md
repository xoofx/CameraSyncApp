# CameraSyncApp [![ci](https://github.com/xoofx/CameraSyncApp/actions/workflows/ci.yml/badge.svg)](https://github.com/xoofx/CameraSyncApp/actions/workflows/ci.yml) [![NuGet](https://img.shields.io/nuget/v/CameraSyncApp.svg)](https://www.nuget.org/packages/CameraSyncApp/)

<img align="right" width="160px" height="160px" src="https://raw.githubusercontent.com/xoofx/CameraSyncApp/main/img/CameraSyncApp.png">

**CameraSyncApp** is a lightweight command-line tool for Windows that simplifies syncing photos and videos. It automatically transfers files from the DCIM/Camera folder of connected devices to a specified destination folder.

## 📖 Usage

Install [.NET 8+ SDK](https://dotnet.microsoft.com/download) and run the following command:

```shell
$ dotnet tool install -g CameraSyncApp
```

Then you can run the tool with:

```shell
$ CameraSyncApp list # List all connected devices
```

Copy all images and videos from the Camera folder of a device:
```shell
$ CameraSyncApp sync --output C:\MyOutputFolder --name MyPhone
```

The tool organizes photos into folders based on the month they were taken. Each folder follows the naming convention `yyyy-MM-{name}`, where `yyyy` is the year, `MM` is the month, and `{name}` is a customizable identifier passed via the `--name` command line option.

## 👋 Credits

This repository contains a fork of [MediaDevices](https://github.com/Bassman2/MediaDevices) library to make it compatible with NativeAOT.


## 🪪 License

This software is released under the [BSD-2-Clause license](https://opensource.org/licenses/BSD-2-Clause). 

The [MediaDevices](https://github.com/Bassman2/MediaDevices) library is released under the [MIT license](https://opensource.org/licenses/MIT).


## 🤗 Author

Alexandre Mutel aka [xoofx](https://xoofx.github.io).
