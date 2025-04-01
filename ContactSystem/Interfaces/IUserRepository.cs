using ContactSystem.Models;

namespace ContactSystem.Interfaces;

public interface IUserRepository
{
    UserModel Add(UserModel user);
    List<UserModel> GetAll();
    UserModel GetById(int id);
    UserModel Update(UserModel user);
    bool Delete(int id);
}
