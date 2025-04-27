using Application.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly SystemDbContext _context;
    public ContactRepository(SystemDbContext context) =>
        _context = context;

    public List<ContactModel> GetAll(int userId) =>
        _context.Contacts.Where(c => c.UserId == userId).ToList();

    public ContactModel GetById(int id) =>
        _context.Contacts.FirstOrDefault(x => x.Id == id) ??
            throw new Exception("NotFound");

    public ContactModel Add(ContactModel contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }

    public ContactModel Update(ContactModel contact)
    {
        ContactModel entity = GetById(contact.Id) ??
            throw new Exception("NotFound");
            
        entity.Name = contact.Name;
        entity.Email = contact.Email;
        entity.Phone = contact.Phone;

        _context.Contacts.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(int id)
    {
        ContactModel entity = GetById(id) ??
            throw new Exception("NotFound");

        _context.Contacts.Remove(entity);
        _context.SaveChanges();
        return true;
    }
}
