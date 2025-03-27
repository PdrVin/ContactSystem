using ContactSystem.Context;
using ContactSystem.Interfaces;
using ContactSystem.Models;

namespace ContactSystem.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly SystemDbContext _context;
    public ContactRepository(SystemDbContext context) =>
        _context = context;

    public ContactModel Add(ContactModel contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }

    public List<ContactModel> GetAll() =>
        _context.Contacts.ToList();

    public ContactModel GetById(int id) =>
        _context.Contacts.FirstOrDefault(x => x.Id == id) ??
            throw new Exception("NotFound");

    public ContactModel Update(ContactModel contact)
    {
        ContactModel entity = GetById(contact.Id) ?? throw new Exception("NotFound");
        entity.Name = contact.Name;
        entity.Email = contact.Email;
        entity.Phone = contact.Phone;

        _context.Contacts.Update(entity);
        _context.SaveChanges();
        return contact;
    }

    public bool Delete(int id)
    {
        ContactModel entity = GetById(id) ?? throw new Exception("NotFound");
        
        _context.Contacts.Remove(entity);
        _context.SaveChanges();
        return true;
    }
}
