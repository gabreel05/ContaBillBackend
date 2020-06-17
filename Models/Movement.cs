using System;
using System.ComponentModel.DataAnnotations;

namespace ContaBill.Models
{
  public class Movement
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve ter no máximo 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public Type Type { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public Category Category { get; set; }
  }
}
