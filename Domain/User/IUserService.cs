using Domain.User.Models;

namespace Domain.User
{
    public interface IUserService
    {
        UserModel GetUserByUsername(string username);
        void AddUser(UserModel userModel);
    }
}
