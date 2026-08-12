
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

public class Categoria : IValidatableObject
{
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Produto> Produtos { get; set; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrWhiteSpace(Nome))
        {
            var primeiraLetra = Nome[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new ValidationResult("A primeira letra do nome da categoria deve ser maiúscula.", new[] { nameof(Nome) });
            }
        }
    }
}
