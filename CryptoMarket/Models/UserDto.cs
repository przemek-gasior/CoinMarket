using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        public float UsdBalance { get; set; }
        public List<UserCurrencyDto> Currencies { get; set; }
    }
}
