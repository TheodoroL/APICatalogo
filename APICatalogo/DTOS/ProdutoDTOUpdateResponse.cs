using APICatalogo.Models;

namespace APICatalogo.DTOS;

public class ProdutoDTOUpdateResponse
{
    public int ProdutoId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal Preco
    {
        get; set;
    }
    public string ImageUrl { get; set; } = string.Empty;
    public float Estoque { get; set; }
    // Relacionamento com a categoria
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public DateTime DataCadastro { get; set; }
}
