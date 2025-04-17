using System.ComponentModel.DataAnnotations;

namespace ContactSystem.Models;

public class EditPasswordModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string CurrentPassword { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    [Compare("NewPassword", ErrorMessage = "Senha não confere.")]
    public string ConfirmNewPassword { get; set; }
}