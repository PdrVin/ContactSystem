namespace ContactSystem.Models;

public class ContactModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ContactModel
    (
        int id,
        string name,
        string email,
        string phone
    )
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
}
