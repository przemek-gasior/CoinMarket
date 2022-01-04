using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(UserLogin user);
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> GetUserByNameAsync(string Name);
        void CreateUserAsync(User user);
    }
}
