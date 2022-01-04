using AutoMapper;
using CryptoMarket.Models;
using CryptoMarket.Repositories;
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


        private readonly HttpClient client = new HttpClient();
        private MarketDTO marketDTO = new MarketDTO();
        private string API_KEY= "d64c2c9d-1e8e-4298-8b88-31e45c93d258";
        private string uri = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?limit=50&convert=USD";

        public MarketService(IMapper mapper, IMarketRepository marketRepository)
        {
            _mapper = mapper;
            _marketRepository = marketRepository;
        }

        public async Task<ICollection<Currency>> FetchMarketData()
        {
            return await _marketRepository.FetchMarketData();
        }

        public async Task GetMarketDataAsync()
        {
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            try
            {
                
                var marketResponse = await client.GetFromJsonAsync<Market>(uri);

                foreach (var item in marketResponse.Data)
                {
                   var mappedData = _mapper.Map<Data, Currency>(item);
                   marketDTO.CurrenciesMarket.Add(mappedData);
                }

                _marketRepository.SaveMarketData(marketDTO);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);               
            }
           

        }
    }
}
