using System;
using JWTAuth.IRepositories;
using JWTAuth.Models;

namespace JWTAuth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository()
        {
            _users = new List<User>()
            {
                new User()
                {
                    UserName= "Admin",
                    Password = "Password"
                },
                new User()
                {
                    UserName= "Admin2",
                    Password = "Password"
                },

            };
        }

        public User? GetUser(string username, string password)
        {
            var user = _users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

            return user;
        }
    }
}

