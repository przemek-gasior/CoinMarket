using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public interface IMarketService
    {
        Task<Market> GetMarketDataAsync();
    }
}
