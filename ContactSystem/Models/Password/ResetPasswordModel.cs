using System.ComponentModel.DataAnnotations;

namespace ContactSystem.Models;

public class ResetPasswordModel
{
    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Email { get; set; }
}