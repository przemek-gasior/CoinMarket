using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _userContext = new List<User>
        {
            new User
            {
                Id = new Guid(),
                Name = "Przemek",
                UsdBalance = 1000,
                Password = "password",
                Wallet = new CryptoWallet()
            }           
        };


        public User Authenticate(UserLogin user)
        {
            var currentUser = _userContext.FirstOrDefault(o => o.Name == user.Name &&  o.Password == user.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
            
    
        }
    }
}
