using System.ComponentModel.DataAnnotations;
using APICatalogo.Validations;

namespace APICatalogo.DTOS;

public class ProdutoDTO
{
    public int ProdutoId { get; set; }

    [Required]
    [PrimeiraLetraMaicuscula]
    [StringLength(80)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public decimal Preco
    {
        get; set;
    }
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; } = string.Empty;

    public int CategoriaId { get; set; }
}
