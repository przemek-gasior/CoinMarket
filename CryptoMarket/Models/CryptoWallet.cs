using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public class CryptoWallet
    {
        
        public virtual int WalletId { get; set; }
       // public virtual int CurrencyId { get; set; }
        public virtual List<UserCurrency> Currencies { get; set; }

        public CryptoWallet()
        {
            Currencies = new();
        }

    }
}