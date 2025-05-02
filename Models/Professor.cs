using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscolar.Models;

public class Professor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o nome do Professor")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o email do Professor")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o telefone do Professor")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite a disciplina do Professor")]
    public string Disciplina { get; set; }
}