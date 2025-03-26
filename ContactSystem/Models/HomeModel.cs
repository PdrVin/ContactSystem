using System;

namespace ContactSystem.Models;

public class HomeModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public HomeModel
    (
        string name,
        string email,
        string phone
    )
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

}
