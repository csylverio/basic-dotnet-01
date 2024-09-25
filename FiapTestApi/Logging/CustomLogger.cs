using System;

namespace FiapTestApi.Logging;

public class CustomLogger : ILogger
{
    private readonly string _name;
    private readonly CustomLoggerProviderConfiguration _loggerConfig;

    public CustomLogger(string name, CustomLoggerProviderConfiguration loggerConfig)
    {
        _name = name;
        _loggerConfig = loggerConfig;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = $"Log de execução: {logLevel}: {eventId} -  {formatter(state, exception)}";

        Console.WriteLine(message);
    }
}
