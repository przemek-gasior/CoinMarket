using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public interface IMarketService
    {
        Task GetMarketDataAsync();
        Task<ICollection<Currency>> FetchMarketData();

        Task CryptoPurchase(BuyCrypto transaction, string token);
        Task SellCrypto(SellCrypto transaction, string token);
    }
}
