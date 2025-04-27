using Domain.Models;

namespace Application.Interfaces;

public interface IUserRepository
{
    UserModel GetByLogin(string login);
    UserModel GetByLoginAndEmail(string login, string email);
    UserModel Add(UserModel user);
    List<UserModel> GetAll();
    UserModel GetById(int id);
    UserModel Update(UserModel user);
    UserModel UpdatePassword(EditPasswordModel editPassword);
    bool Delete(int id);
}
