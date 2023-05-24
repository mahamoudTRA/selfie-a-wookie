using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace SelfieAWookie.Core.Infrastructure.Loggers
{
    public class CustomLoggerProvider : ILoggerProvider
    {

        private ConcurrentDictionary<string, CustomMessageLogger> _loggers = new();

        public ILogger CreateLogger(string categoryName)
        {
            _loggers.GetOrAdd(categoryName, key => new CustomMessageLogger());
            return _loggers[categoryName];
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}

