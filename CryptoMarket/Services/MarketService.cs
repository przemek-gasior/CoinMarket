using AutoMapper;
using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class MarketService : IMarketService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly IMapper _mapper;
        private MarketDTO marketDTO = new MarketDTO();
        private string API_KEY= "d64c2c9d-1e8e-4298-8b88-31e45c93d258";
        private string uri = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?limit=50&convert=USD";

        public MarketService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<MarketDTO> GetMarketDataAsync()
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
                
                return marketDTO;
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
           

        }
    }
}
