using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Encryption
{
    public interface IEncryptionService
    {
        byte[] Encrypt(byte[] bytesUnprotected, byte[] entropy = null);

        byte[] Decrypt(byte[] bytesProtected, byte[] entropy = null);

    }
}
