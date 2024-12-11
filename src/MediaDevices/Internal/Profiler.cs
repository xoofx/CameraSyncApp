using System;
using System.Diagnostics;

namespace MediaDevices.Internal
{
    internal sealed class Profiler : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private string? _title;

        
        public Profiler(string title)
        {
            _stopwatch = Stopwatch.StartNew();
            Start(title);
        }

        public void Dispose()
        {
            Stop();
        }

        [Conditional("PROFILING")]
        private void Start(string title)
        {
            this._title = title;
            //Trace.WriteLine($"Profiler {this.title} start");
            this._stopwatch.Restart();
        }

        [Conditional("PROFILING")]
        private void Stop()
        {
            this._stopwatch.Stop();
            //Trace.WriteLine($"Profiler {this.title} : {this.stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffffff").Insert(12, ".")}");

            double milliseconds = ((double)this._stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;
            //double nanoseconds = (this.stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000_000_000;
            Trace.WriteLine($"Profiler {this._title} : {milliseconds} ms");
        }
    }
}

