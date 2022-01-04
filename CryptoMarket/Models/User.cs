using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public float UsdBalance { get; set; }
        public CryptoWallet Wallet { get; set; }

        public User()
        {
            UsdBalance = 1000;
            Wallet = new();
        }
    }
}
