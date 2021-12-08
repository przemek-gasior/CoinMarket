using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class USD
    {
        public float Price { get; set; }
        public float Percent_Change_1h { get; set; }
        public float Percent_Change_24h { get; set; }
        public float Percent_Change_7d { get; set; }
        public float Market_Cap { get; set; }
    }
}
