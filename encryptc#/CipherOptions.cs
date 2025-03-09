using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{
    public static class CipherOptions
    {
        public static void MonoalphabeticOption()
        {
            Console.Write("Choose action (1. Encrypt, 2. Decrypt): ");
            string action = Console.ReadLine();

            if (action == "1")
            {
                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();
                string encryptedText = EncryptionDecryption.MonoalphabeticEncrypt(plaintext);
                Console.WriteLine($"Encrypted text: {encryptedText}");
            }
            else if (action == "2")
            {
                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();
                string decryptedText = EncryptionDecryption.MonoalphabeticDecrypt(ciphertext);
                Console.WriteLine($"Decrypted text: {decryptedText}");
            }
            else
            {
                Console.WriteLine("Invalid action.");
            }
        }
    }
}
