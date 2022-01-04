using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class WalletCurrency
    {
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int WalletId { get; set; }
        public CryptoWallet Wallet { get; set; }
    }
}
