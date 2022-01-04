using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public class CryptoWallet
    {
        
        public int WalletId { get; set; }
        public ICollection<WalletCurrency> Currencies { get; set; }

    }
}