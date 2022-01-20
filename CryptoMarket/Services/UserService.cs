using AutoMapper;
using CryptoMarket.Helpers;
using CryptoMarket.Models;
using CryptoMarket.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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

        public async Task<UserDto> GetUser(string token)
        {
            var id = RetrieveUserDataFromToken(token);
            return await _userRepository.GetUserByIdAsDto(Guid.Parse(id));            
        }

        public string RetrieveUserDataFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            return decodedToken.Claims.FirstOrDefault(x => x.Type == "UserID").Value;
        }
    }
}
