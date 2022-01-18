using CryptoMarket.Helpers;
using CryptoMarket.Models;
using CryptoMarket.Repositories;
using System;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(UserLogin user)
        {
            if (await _userRepository.GetUserByNameAsync(user.Name) != null)
            {
                throw new AppException("User already exist");
            }
            else
            {
                var hashedPassword = hashPassword.sha256(user.Password);
                var newUser = new User
                {
                     Name = user.Name,
                     Password = hashedPassword
                 };

                _userRepository.CreateUserAsync(newUser);
            }
           
        }
    }
}
