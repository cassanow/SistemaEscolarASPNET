using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscolar.Models;

public class Aluno
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o nome do Aluno")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o RA do aluno")]
    [MaxLength(5)]
    public string RA { get; set; }
    
    [Required(ErrorMessage = "Por favor, digite o email do Aluno")]
    public string Email { get; set; }
    
}