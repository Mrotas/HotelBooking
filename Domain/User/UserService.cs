using DataAccess.Dao;
using DataAccess.Dao.Interfaces;
using Domain.User.Models;

namespace Domain.User
{
    public class UserService : IUserService
    {
        private IUserDao _userDao;

        public UserService() : this(new UserDao())
        {

        }

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public UserModel GetUserByUsername(string username)
        {
            DataAccess.Entities.User user = _userDao.GetUserByUsername(username);

            var userModel = new UserModel
            {
                UserId = user.Id,
                Username = user.Username,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password
            };

            return userModel;
        }

        public void AddUser(UserModel userModel)
        {
            DataAccess.Entities.User user = userModel.ToDto();

            _userDao.Insert(user);
        }
    }
}
