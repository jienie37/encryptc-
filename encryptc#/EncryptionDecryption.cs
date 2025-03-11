using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{

    public static class EncryptionDecryption
    {
        private static Dictionary<char, char> encryptionMap = new Dictionary<char, char>
    {
        {'a', 'q'}, {'b', 'w'}, {'c', 'e'}, {'d', 'r'}, {'e', 't'},
        {'f', 'y'}, {'g', 'u'}, {'h', 'i'}, {'i', 'o'}, {'j', 'p'},
        {'k', 'a'}, {'l', 's'}, {'m', 'd'}, {'n', 'f'}, {'o', 'g'},
        {'p', 'h'}, {'q', 'j'}, {'r', 'k'}, {'s', 'l'}, {'t', 'z'},
        {'u', 'x'}, {'v', 'c'}, {'w', 'v'}, {'x', 'b'}, {'y', 'n'},
        {'z', 'm'}
    };

        private static Dictionary<char, char> decryptionMap = new Dictionary<char, char>
    {
        {'q', 'a'}, {'w', 'b'}, {'e', 'c'}, {'r', 'd'}, {'t', 'e'},
        {'y', 'f'}, {'u', 'g'}, {'i', 'h'}, {'o', 'i'}, {'p', 'j'},
        {'a', 'k'}, {'s', 'l'}, {'d', 'm'}, {'f', 'n'}, {'g', 'o'},
        {'h', 'p'}, {'j', 'q'}, {'k', 'r'}, {'l', 's'}, {'z', 't'},
        {'x', 'u'}, {'c', 'v'}, {'v', 'w'}, {'b', 'x'}, {'n', 'y'},
        {'m', 'z'}
    };

        public static string MonoalphabeticEncrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();
            plaintext = plaintext.ToLower(); 

            foreach (char c in plaintext)
            {
                if (c == ' ')
                {
                    continue; 
                }
                if (encryptionMap.ContainsKey(c))
                {
                    encryptedText.Append(encryptionMap[c]);
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
            ciphertext = ciphertext.ToLower(); 

            foreach (char c in ciphertext)
            {
                if (decryptionMap.ContainsKey(c))
                {
                    decryptedText.Append(decryptionMap[c]);
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
