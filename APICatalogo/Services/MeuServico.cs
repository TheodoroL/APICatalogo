namespace APICatalogo.Services;

public class MeuServico : IMeuServicoe
{
    public string Saudacao(string nome)
    {
        return $"{DateTime.UtcNow}-- Olá, {nome}! Bem-vindo ao nosso serviço.";
    }
}
