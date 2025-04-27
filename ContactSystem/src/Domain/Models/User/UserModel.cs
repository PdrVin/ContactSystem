using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Extension;

namespace Domain.Models;

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

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public Profile? Profile { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório.")]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public virtual List<ContactModel> Contacts { get; set; }

    public bool IsPasswordValid(string password) =>
        Password == password.GenerateHash();

    public void SetHashPassword() =>
        Password = Password.GenerateHash();

    public void SetNewPassword(string newPassword) =>
        Password = newPassword.GenerateHash();

    public string GenerateNewPassword()
    {
        string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
        Password = newPassword.GenerateHash();
        return newPassword;
    }
}
