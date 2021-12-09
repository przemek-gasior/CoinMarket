using CryptoMarket.Models;
using CryptoMarket.Services;
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

        [Authorize]
        [HttpGet]
        public async Task<MarketDTO> GetMarket()
        {
            return await _marketService.GetMarketDataAsync();
        }
    }
}
