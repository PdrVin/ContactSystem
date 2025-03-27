using ContactSystem.Models;

namespace ContactSystem.Interfaces;

public interface IContactRepository
{
    ContactModel Add(ContactModel contact);
    List<ContactModel> GetAll();
}
