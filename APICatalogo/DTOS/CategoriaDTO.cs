using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOS;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; } = string.Empty;
}
