using System;
using JWTAuth.IRepositories;
using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;
        public UserRepository(AuthDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            var user = await _context.Users.Where(user => user.UserName == username && user.Password == password).FirstOrDefaultAsync();

            return user;
        }
    }
}

