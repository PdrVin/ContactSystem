using System.ComponentModel.DataAnnotations;
using ContactSystem.Enums;

namespace ContactSystem.Models;

public class UserModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    public Profile Profile { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
