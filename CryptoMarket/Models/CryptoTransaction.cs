using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class CryptoTransaction
    {
        public string CryptoName { get; set; }
        public float CryptoQuantity { get; set; }
        public float TransactionCost { get; set; }
    }
}
