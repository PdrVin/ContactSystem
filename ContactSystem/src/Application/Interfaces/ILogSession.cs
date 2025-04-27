using Domain.Models;

namespace Application.Interfaces;

public interface ILogSession
{
    UserModel SearchUserSession();
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
}
