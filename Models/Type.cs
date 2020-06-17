using System.ComponentModel.DataAnnotations;

namespace ContaBill.Models
{
  public class Type
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve ter no máximo 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
  }
}
