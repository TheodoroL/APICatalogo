using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APICatalogo.Validations;

namespace APICatalogo.Models;

public class Produto
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
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco
    {
        get; set;
    }
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; } = string.Empty;
    public float Estoque { get; set; }
    // Relacionamento com a categoria
    public int CategoriaId { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
