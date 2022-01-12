using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController : Controller
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        
        [HttpGet]
        public async Task<ICollection<Currency>> GetMarket()
        {
            await _marketService.GetMarketDataAsync(); //calling this method here just to seed db with market data
            return await _marketService.FetchMarketData();
        }

        [Authorize]
        [HttpPost]
        public async Task BuyCrypto([FromBody] CryptoTransaction transaction)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            await _marketService.CryptoPurchase(transaction, token);
        }
    }
}
