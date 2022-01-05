using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMarket.Models
{
    //DB model to store market data
    public class Currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float PriceInUsd { get; set; }
        public float PercentChange1h { get; set; }
        public float PercentChange24h { get; set; }
        public float PercentChange7d { get; set; }
        public float MarketCapUSD { get; set; }
        public float? Quantity { get; set; }

        public ICollection<WalletCurrency> Wallets { get; set; }

    }
}