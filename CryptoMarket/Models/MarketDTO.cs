using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class MarketDTO
    {
        public List<Currency> CurrenciesMarket { get; set; }

        public MarketDTO()
        {
            CurrenciesMarket = new List<Currency>();
        }
    }
}
