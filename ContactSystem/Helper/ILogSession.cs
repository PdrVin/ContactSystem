using ContactSystem.Models;

namespace ContactSystem.Helper;

public interface ILogSession
{
    UserModel SearchUserSession();
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
}
