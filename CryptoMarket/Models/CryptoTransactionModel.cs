using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class CryptoTransactionModel
    {
        public string CryptoName { get; set; }
        public float CryptoQuantity { get; set; }
        public float Value { get; set; }
    }
}
