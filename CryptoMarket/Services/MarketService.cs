using AutoMapper;
using CryptoMarket.Helpers;
using CryptoMarket.Models;
using CryptoMarket.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class MarketService : IMarketService
    {
        private readonly IMapper _mapper;
        private readonly IMarketRepository _marketRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new HttpClient();

        public MarketService(IMapper mapper, IMarketRepository marketRepository, IConfiguration config, IUserRepository userRepository, IUserService userService)
        {
            _mapper = mapper;
            _marketRepository = marketRepository;
            _config = config;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task CryptoPurchase(CryptoTransaction transaction, string token)
        {
            var id = _userService.RetrieveUserDataFromToken(token);

            // Getting user for transaction
            var user = await _userRepository.GetUserByIdAsync(Guid.Parse(id));

            // get coin information for transaction
            var coin = await _marketRepository.GetCryptoByNameAsync(transaction.CryptoName);

            if (coin != null)
            {
                // calculate the transaction cost
                var transactionValue = coin.PriceInUsd * transaction.CryptoQuantity;

                var transactionToProcess = new CryptoTransactionModel
                {
                    CryptoName = transaction.CryptoName,
                    CryptoQuantity = transaction.CryptoQuantity,
                    Value = transactionValue
                };

                //check for the User Balance and proceed with transaction
                if (user.UsdBalance >= transactionToProcess.Value)
                {
                    await _marketRepository.UpdateUserWalletPurchase(user, transactionToProcess);
                }
                else
                {
                    throw new AppException("non-sufficient funds");
                }
            }
            else
            {
                throw new KeyNotFoundException("Crypto not found");
            }
        }

        public async Task<ICollection<Currency>> FetchMarketData()
        {
            return await _marketRepository.FetchMarketData();
        }

        public async Task GetMarketDataAsync()
        {
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _config["MarketApi:Key"]);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                
                var marketResponse = await client.GetFromJsonAsync<Market>(_config["MarketApi:Uri"]);
                var marketDTO = new MarketDTO();

                foreach (var item in marketResponse.Data)
                {
                   var mappedData = _mapper.Map<Data, Currency>(item);
                   marketDTO.CurrenciesMarket.Add(mappedData);
                }

                await _marketRepository.SaveMarketData(marketDTO);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);               
            }
           

        }

        public async Task SellCrypto(CryptoTransaction transaction, string token)
        {
            // decode token to grab a user

            var id = _userService.RetrieveUserDataFromToken(token);

            // Getting user for transaction
            var user = await _userRepository.GetUserByIdAsync(Guid.Parse(id));

            //get coin information for transaction
            var coin = await _marketRepository.GetCryptoByNameAsync(transaction.CryptoName);

            if(coin != null)
            {
                //calculate transaction value
                var transactionValue = coin.PriceInUsd * transaction.CryptoQuantity;
                var transactionToProcess = new CryptoTransactionModel
                {
                    CryptoName = transaction.CryptoName,
                    CryptoQuantity = transaction.CryptoQuantity,
                    Value = transactionValue
                };

                //proceed
                await _marketRepository.UpdateUserWalletSell(user, transactionToProcess);
            }
            else
            {
                throw new KeyNotFoundException("Crypto not found");
            } 
        }
    }
}
