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
        public static string CaesarAlgoEncryption(string text, int key)
        {
            text = text.ToUpper();
            string result = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c)) // to check whether input is a letter, if space or other, disregard
                {
                    char shifted = (char)(c + key);

                    if (shifted > 'Z')
                    {
                        shifted = (char)(shifted - 26);
                    }
                    result += shifted;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
        public static string CaesarAlgoDecryption(string text)
        {

            text = "DECRYPTION";
            return text;
        }
    }

}
