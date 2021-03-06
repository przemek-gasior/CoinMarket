using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserLogin user);

        Task<UserDto> GetUser(string token);
        string RetrieveUserDataFromToken(string token);
    }
}
