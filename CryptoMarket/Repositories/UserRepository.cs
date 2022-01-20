using CryptoMarket.Configs;
using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptoMarket.Helpers;
using AutoMapper;

namespace CryptoMarket.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userContext;
        private readonly IMapper _mapper;

        public UserRepository(UserDbContext userDbContext, IMapper mapper)
        {
            _userContext = userDbContext;
            _mapper = mapper;
        }
        public User Authenticate(UserLogin user)
        {
            var currentUser = _userContext.Users.FirstOrDefault(o => o.Name == user.Name &&  o.Password == hashPassword.sha256(user.Password));

            if (currentUser != null)
            {
                return currentUser;
            }
            else
            {
                throw new AppException("Invalid credentials");
            }

        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            var user = await _userContext.Users.Include(x => x.Wallet).FirstOrDefaultAsync(x => x.Id == Id);

            if (user != null)
            { 
                return user;
            }
            else
            {
                throw new AppException("Invalid credentials");
            }

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


        public async Task<UserDto> GetUserByIdAsDto(Guid Id)
        {
            var user = await _userContext.Users.Include(x => x.Wallet)
                .ThenInclude(x => x.Currencies).FirstAsync(x=> x.Id == Id);

            if (user != null)
            {
                return _mapper.Map<UserDto>(user); ;
            }
            else
            {
                throw new AppException("Invalid credentials");
            }
        }
    }
}
