using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class UserCurrency
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public virtual int CurrencyId { get; set; }
        public virtual List<CryptoWallet> CryptoWallets { get; set; }
    }
}
