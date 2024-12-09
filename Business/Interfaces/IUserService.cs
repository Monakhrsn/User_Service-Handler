using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    bool AddUser(BaseUser user);
    BaseUser? GetUserById(int id);
    IEnumerable<BaseUser> GetAllUsers();
}