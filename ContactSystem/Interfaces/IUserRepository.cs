using ContactSystem.Models;

namespace ContactSystem.Interfaces;

public interface IUserRepository
{
    UserModel GetByLogin(string login);
    UserModel Add(UserModel user);
    List<UserModel> GetAll();
    UserModel GetById(int id);
    UserModel Update(UserModel user);
    bool Delete(int id);
}
