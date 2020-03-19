using DataAccess.Dao.Interfaces;
using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Dao
{
    public class UserDao : IUserDao
    {
        public User GetUserByUsername(string username)
        {
            using (var db = new HotelBookingDb())
            {
                User user = db.User.Where(x => x.Username == username).FirstOrDefault();
                return user;
            }
        }

        public void Insert(User user)
        {
            using (var db = new HotelBookingDb())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }
    }
}
