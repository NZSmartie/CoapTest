﻿#define DEBUG

using Splat;

namespace OICExplorer.Services
{
    internal class MyDebugLogger : ILogger
    {
        public LogLevel Level { get; set; }

        public void Write([Localizable(false)] string message, LogLevel logLevel)
        {
            if ((int)logLevel < (int)Level) return;
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}