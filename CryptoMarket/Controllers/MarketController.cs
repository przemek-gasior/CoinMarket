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
            return await _marketService.FetchMarketData();
        }

        [Authorize]
        [HttpPost]
        [Route("/Buy")]
        public async Task BuyCrypto([FromBody] BuyCrypto transaction)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            await _marketService.CryptoPurchase(transaction, token);
        }   
        
        [Authorize]
        [HttpPost]
        [Route("/Sell")]
        public async Task<IActionResult> SellCrypto([FromBody] SellCrypto transaction)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            try
            {
                await _marketService.SellCrypto(transaction, token);
                return Ok();
            }
            catch
            {
                return StatusCode(422, "Insufficient founds.");
            }
            
        }
    }
}
