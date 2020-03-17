namespace Domain.User.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public DataAccess.Entities.User ToDto()
        {
            var user = new DataAccess.Entities.User
            {
                Id = UserId,
                Username = Username,
                Name = Name,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Password = Password
            };

            return user;
        }
    }
}
