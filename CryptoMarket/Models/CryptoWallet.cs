using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public class CryptoWallet
    {
        public ICollection<Currency> Currencies { get; set; }
        public float ValueInUsd { get; set; }
    }
}