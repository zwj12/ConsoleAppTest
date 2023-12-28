using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleAppTest.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        public byte[] Encrypt(byte[] bytesUnprotected, byte[] entropy = null)
        {
            byte[] bytesProtected = ProtectedData.Protect(bytesUnprotected, entropy, DataProtectionScope.CurrentUser);
            return bytesProtected;
        }

        public byte[] Decrypt(byte[] bytesProtected, byte[] entropy = null)
        {
            byte[] bytesUnprotected = ProtectedData.Unprotect(bytesProtected, entropy, DataProtectionScope.CurrentUser);
            return bytesUnprotected;
        }

        public string Encrypt(string strUnprotected, byte[] entropy = null)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strUnprotected)));
        }

        public string Decrypt(string strProtected, byte[] entropy = null)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strProtected)));
        }

    }
}
