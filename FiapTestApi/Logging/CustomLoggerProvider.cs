using System;
using System.Collections.Concurrent;

namespace FiapTestApi.Logging;

public class CustomLoggerProvider : ILoggerProvider
{
    private readonly CustomLoggerProviderConfiguration _loggerConfig;
    private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();

    public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig) {
        _loggerConfig = loggerConfig;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
