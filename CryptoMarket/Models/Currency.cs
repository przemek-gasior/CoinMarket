namespace CryptoMarket.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public float PriceInUsd { get; set; }
        public float PercentChange1h { get; set; }
        public float PercentChange24h { get; set; }
        public float PercentChange7d { get; set; }
        public float MarketCapUSD { get; set; }

    }
}