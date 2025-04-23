using ContactSystem.Context;
using ContactSystem.Interfaces;
using ContactSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactSystem.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SystemDbContext _context;

    public UserRepository(SystemDbContext context) =>
        _context = context;

    public UserModel GetByLogin(string login) =>
        _context.Users.FirstOrDefault(user =>
            user.Login.ToUpper() == login.ToUpper()) ??
                throw new Exception("NotFound");

    public UserModel GetByLoginAndEmail(string login, string email) =>
        _context.Users.FirstOrDefault(user =>
            user.Login.ToUpper() == login.ToUpper() &&
            user.Email.ToUpper() == email.ToUpper()) ??
                throw new Exception("NotFound");

    public List<UserModel> GetAll() =>
        _context.Users.Include(u => u.Contacts).ToList();

    public UserModel GetById(int id) =>
        _context.Users.FirstOrDefault(x => x.Id == id) ??
            throw new Exception("NotFound");

    public UserModel Add(UserModel user)
    {
        user.CreatedAt = DateTime.Now;
        user.SetHashPassword();

        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public UserModel Update(UserModel user)
    {
        UserModel entity = GetById(user.Id) ??
            throw new Exception("NotFound");

        entity.Name = user.Name;
        entity.Login = user.Login;
        entity.Email = user.Email;
        entity.Profile = user.Profile;
        entity.UpdatedAt = DateTime.Now;

        _context.Users.Update(entity);
        _context.SaveChanges();
        return user;
    }

    public UserModel UpdatePassword(EditPasswordModel editPassword)
    {
        UserModel user = GetById(editPassword.Id) ??
            throw new Exception("NotFound");

        if (!user.IsPasswordValid(editPassword.CurrentPassword))
            throw new Exception("Senha Inválida.");

        if (user.IsPasswordValid(editPassword.NewPassword))
            throw new Exception("Nova Senha deve ser diferente da Atual.");

        user.SetNewPassword(editPassword.NewPassword);
        user.UpdatedAt = DateTime.Now;

        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    public bool Delete(int id)
    {
        UserModel entity = GetById(id) ??
            throw new Exception("NotFound");

        _context.Users.Remove(entity);
        _context.SaveChanges();
        return true;
    }
}
