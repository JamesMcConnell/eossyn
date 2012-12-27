using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Eossyn.Core.Encryption
{
    public class HasherService : IHasherService
    {
        #region IHasherService Members
        public string ComputeHash(string valueToHash, string salt)
        {
            string hash = Sha256Hex(salt + valueToHash);
            return salt + hash;
        }

        public string GenerateSalt()
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            random.GetBytes(salt);
            return BytesToHex(salt);
        }
        #endregion

        #region Private Helper Methods
        private static string BytesToHex(byte[] toConvert)
        {
            StringBuilder sb = new StringBuilder(toConvert.Length * 2);
            foreach (byte b in toConvert)
            {
                sb.Append(b.ToString("x2", CultureInfo.CurrentCulture));
            }
            return sb.ToString();
        }

        private static string Sha256Hex(string toHash)
        {
            SHA256Managed hash = new SHA256Managed();
            byte[] utf8 = UTF8Encoding.UTF8.GetBytes(toHash);
            return BytesToHex(hash.ComputeHash(utf8));
        }
        #endregion
    }
}
