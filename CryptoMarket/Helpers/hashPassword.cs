using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Helpers
{
    public static class hashPassword
    {
        public static string sha256(string processedString)
        {
            var sHA256 = new SHA256Managed();
            var encryptedStr = new StringBuilder();
            byte[] hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(processedString));
            foreach (var theByte in hash)
            {
                encryptedStr.Append(theByte.ToString("x2"));
            }
            return encryptedStr.ToString();
        }
    }
}
