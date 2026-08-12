namespace APICatalogo.Loggin;

public class CustomLogger : ILogger
{
    private readonly string _loggerName;
    private readonly CustomLoggerProviderConfiguration _loggersConfiguration;

    // Objeto estático usado para sincronizar a escrita no arquivo entre todas as instâncias do logger
    private static readonly object _lock = new object();

    public CustomLogger(string name, CustomLoggerProviderConfiguration loggersConfiguration)
    {
        _loggerName = name;
        _loggersConfiguration = loggersConfiguration;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= _loggersConfiguration.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        // Formata a mensagem incluindo detalhes da exceção, se houver
        string mensagem = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {logLevel} - {_loggerName} - {formatter(state, exception)}";

        EscreverTextoNoArquivo(mensagem);
    }

    private void EscreverTextoNoArquivo(string mensagem)
    {
        // O caminho idealmente deveria vir da sua configuração (_loggersConfiguration)
        string caminhoArquivo = @"d:\dados\log\log.txt";

        // Garante que a pasta exista antes de tentar criar o arquivo
        string? diretorio = Path.GetDirectoryName(caminhoArquivo);
        if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
        {
            Directory.CreateDirectory(diretorio);
        }

        // O 'lock' impede que duas requisições usem o StreamWriter ao mesmo tempo
        lock (_lock)
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
            {
                writer.WriteLine(mensagem);
                // Não precisa de writer.Close() aqui, o 'using' cuida disso.
            }
        }
    }
}