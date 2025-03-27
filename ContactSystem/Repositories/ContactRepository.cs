using ContactSystem.Context;
using ContactSystem.Interfaces;
using ContactSystem.Models;

namespace ContactSystem.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly SystemDbContext _context;
    public ContactRepository(SystemDbContext context)
    {   
        _context = context;
    }
    public ContactModel Add(ContactModel contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }

    public List<ContactModel> GetAll()
    {
        return _context.Contacts.ToList();
    }
}
