using AutoMapper;
using CryptoMarket.Models;
using CryptoMarket.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class MarketService : IMarketService
    {
        private readonly IMapper _mapper;
        private readonly IMarketRepository _marketRepository;
        private readonly IConfiguration _config;
        private readonly HttpClient client = new HttpClient();

        public MarketService(IMapper mapper, IMarketRepository marketRepository, IConfiguration config)
        {
            _mapper = mapper;
            _marketRepository = marketRepository;
            _config = config;
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
    }
}
