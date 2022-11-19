using System;
using JWTAuth.Models;

namespace JWTAuth.IRepositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string username, string password);
    }
}

