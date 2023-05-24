using System;
using Microsoft.Extensions.Logging;

namespace SelfieAWookie.Core.Infrastructure.Loggers
{
    public class CustomMessageLogger : ILogger
    {
        public CustomMessageLogger()
        {
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.Trace;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"[{DateTime.Now}]: #{logLevel.ToString()}#  {formatter(state, exception)}");
        }
    }
}

