using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Repositories
{
    public interface IMarketRepository
    {
        void SaveMarketData(MarketDTO marketData);
        Task<ICollection<Currency>> FetchMarketData();
    }
}
