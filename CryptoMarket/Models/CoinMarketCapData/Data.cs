using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Quote Quote { get; set; }
    }
}
