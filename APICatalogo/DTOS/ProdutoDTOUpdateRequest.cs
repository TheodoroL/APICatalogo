using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOS;

public class ProdutoDTOUpdateRequest : IValidatableObject
{
    [Range(1, 99999, ErrorMessage = "O campo {0} deve ser maior que {1} e menor que {2}")]
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DataCadastro <= DateTime.Now.Date)
        {
            yield return new ValidationResult("A data de cadastro não pode ser menor que a data atual.", new[] { nameof(DataCadastro) });
        }
    }
}
