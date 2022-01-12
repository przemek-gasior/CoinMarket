using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Repositories
{
    public interface IMarketRepository
    {
        Task SaveMarketData(MarketDTO marketData);
        Task<ICollection<Currency>> FetchMarketData();

        Task<Currency> GetCryptoByNameAsync(string name);

        Task UpdateUserWallet(User user, CryptoTransaction transaction);
    }
}
