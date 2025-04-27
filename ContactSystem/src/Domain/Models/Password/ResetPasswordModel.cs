using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ResetPasswordModel
{
    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Email { get; set; }
}