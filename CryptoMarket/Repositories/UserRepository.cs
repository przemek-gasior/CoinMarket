using CryptoMarket.Configs;
using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptoMarket.Helpers;

namespace CryptoMarket.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userContext = userDbContext;
        }
        public User Authenticate(UserLogin user)
        {
            var currentUser = _userContext.Users.FirstOrDefault(o => o.Name == user.Name &&  o.Password == hashPassword.sha256(user.Password));

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
            
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await _userContext.Users.Include(x => x.Wallet).FirstOrDefaultAsync(u => u.Id == Id);
        }

        public void CreateUserAsync(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public async Task<User> GetUserByNameAsync(string Name)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.Name == Name);
        }
    }
}
