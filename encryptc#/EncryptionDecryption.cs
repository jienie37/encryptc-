using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{

    public static class EncryptionDecryption
    {
        public static string MonoalphabeticEncrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();
            foreach (char c in plaintext)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(c + 3);
                    if ((char.IsLower(c) && shifted > 'z') || (char.IsUpper(c) && shifted > 'Z'))
                    {
                        shifted = (char)(c - 23);
                    }
                    encryptedText.Append(shifted);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }
            return encryptedText.ToString();
        }

        public static string MonoalphabeticDecrypt(string ciphertext)
        {
            StringBuilder decryptedText = new StringBuilder();
            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(c - 3);
                    if ((char.IsLower(c) && shifted < 'a') || (char.IsUpper(c) && shifted < 'A'))
                    {
                        shifted = (char)(c + 23);
                    }
                    decryptedText.Append(shifted);
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();
        }
    }

}
