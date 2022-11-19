using System;
using JWTAuth.Models;

namespace JWTAuth.IRepositories
{
    public interface IUserRepository
    {
        public User? GetUser(string username, string password);
    }
}

