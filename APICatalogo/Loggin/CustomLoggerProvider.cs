using System.Collections.Concurrent;

namespace APICatalogo.Loggin;

public class CustomLoggerProvider : ILoggerProvider
{
    private readonly CustomLoggerProviderConfiguration _loggersConfiguration;
    private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new();
    public CustomLoggerProvider(CustomLoggerProviderConfiguration loggersConfiguration)
    {
        _loggersConfiguration = loggersConfiguration;

    }

    public ILogger CreateLogger(string categoryName)
    {
        return (ILogger)_loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggersConfiguration));
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
