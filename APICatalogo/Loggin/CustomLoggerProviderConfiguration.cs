namespace APICatalogo.Loggin;

public class CustomLoggerProviderConfiguration
{
    // Define o nivel minimo de log que será registrado. O padrão é LogLevel.Warning, mas você pode alterar para LogLevel.Information, LogLevel.Debug, etc., conforme necessário.
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    // Define o ID do evento de log, com padrão sendo zero
    public int EventId { get; set; } = 0;
}
