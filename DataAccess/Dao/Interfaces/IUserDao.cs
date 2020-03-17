using DataAccess.Entities;

namespace DataAccess.Dao.Interfaces
{
    public interface IUserDao
    {
        User GetUserByUsername(string username);
        void Insert(User user);
    }
}
