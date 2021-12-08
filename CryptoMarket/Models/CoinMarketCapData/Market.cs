using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Market
    {
        public ICollection<Data> Data { get; set; }
    }
}
