using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public Profile? Profile { get; set; }
}
