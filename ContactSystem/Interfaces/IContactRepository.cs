using ContactSystem.Models;

namespace ContactSystem.Interfaces;

public interface IContactRepository
{
    ContactModel Add(ContactModel contact);
    List<ContactModel> GetAll(int userId);
    ContactModel GetById(int id);
    ContactModel Update(ContactModel contact);
    bool Delete(int id);
}
