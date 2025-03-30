using System.ComponentModel.DataAnnotations;

namespace ContactSystem.Models;

public class ContactModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Campo Obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    [Phone(ErrorMessage = "Telefone inválido.")]
    public string Phone { get; set; }
}
