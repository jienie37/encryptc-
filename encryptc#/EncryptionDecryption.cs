using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{
    public static class Encryption_Decryption
    {
        /* ================== Monoalphabetic Encryption and Decryption ================== */
        public static string Monoalphabetic_Encrypt(string plaintext)
        {
            var encryptionMap = new Dictionary<char, char>
                {
                    {'a', 'q'}, {'b', 'w'}, {'c', 'e'}, {'d', 'r'}, {'e', 't'},
                    {'f', 'y'}, {'g', 'u'}, {'h', 'i'}, {'i', 'o'}, {'j', 'p'},
                    {'k', 'a'}, {'l', 's'}, {'m', 'd'}, {'n', 'f'}, {'o', 'g'},
                    {'p', 'h'}, {'q', 'j'}, {'r', 'k'}, {'s', 'l'}, {'t', 'z'},
                    {'u', 'x'}, {'v', 'c'}, {'w', 'v'}, {'x', 'b'}, {'y', 'n'},
                    {'z', 'm'}
                };

            StringBuilder ciphertext = new StringBuilder();
            plaintext = plaintext.ToLower();

            foreach (char c in plaintext)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (encryptionMap.ContainsKey(c))
                {
                    ciphertext.Append(encryptionMap[c]);
                }
                else
                {
                    ciphertext.Append(c);
                }
            }
            return ciphertext.ToString();
        }

        public static string MonoalphabeticDecrypt(string ciphertext)
        {
            var decryptionMap = new Dictionary<char, char>
                {
                    {'q', 'a'}, {'w', 'b'}, {'e', 'c'}, {'r', 'd'}, {'t', 'e'},
                    {'y', 'f'}, {'u', 'g'}, {'i', 'h'}, {'o', 'i'}, {'p', 'j'},
                    {'a', 'k'}, {'s', 'l'}, {'d', 'm'}, {'f', 'n'}, {'g', 'o'},
                    {'h', 'p'}, {'j', 'q'}, {'k', 'r'}, {'l', 's'}, {'z', 't'},
                    {'x', 'u'}, {'c', 'v'}, {'v', 'w'}, {'b', 'x'}, {'n', 'y'},
                    {'m', 'z'}
                };

            StringBuilder plaintext = new StringBuilder();
            ciphertext = ciphertext.ToLower();

            foreach (char c in ciphertext)
            {
                if (decryptionMap.ContainsKey(c))
                {
                    plaintext.Append(decryptionMap[c]);
                }
                else
                {
                    plaintext.Append(c);
                }
            }
            return plaintext.ToString();
        }


        /* ================== Caesar Cipher Encryption and Decryption ================== */
        public static string CaesarAlgoEncryption(string text, int key)
        {
            text = text.ToUpper();
            string result = "";

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    continue;
                }
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

        public static string CaesarAlgoDecryption(string ciphertext, int key)
        {
            ciphertext = ciphertext.ToUpper();
            string result = "";

            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c)) // to check whether input is a letter, if space or other, disregard
                {
                    char shifted = (char)(c - key);

                    if (shifted < 'A')
                    {
                        shifted = (char)(shifted + 26);
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



























































































        /* ================== Pi Substitution Cipher Encryption and Decryption ================== */
        private static readonly string pi_decimal = "141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930381964428810975665933446128475648233786783165271201909145648566923460348610454326648213393607260249141273724587006606315588174881520920962829254091715364367892590360011330530548820466521384146951941511609433057270365759591953092186117381932611793105118";

        public static string PiSubstitutionEncrypt(string plaintext)
        {
            plaintext = plaintext.ToUpper(); 
            string ciphertext = "";

            foreach (char c in plaintext)
            {
                if (char.IsWhiteSpace(c))
                {
                    // ignores spaces
                    continue;
                }

                if (char.IsLetter(c))
                {
                    // get the letter's number (A = 1, B = 2, ..., Z = 26)
                    int letter_number = c - 'A' + 1;

                    // find the index of the letter in the pi_decimal string
                    int index = pi_decimal.IndexOf(letter_number.ToString());

                    if (index != -1)
                    {
                        // Add the index to the ciphertext (1-based position)
                        string indexStr = (index + 1).ToString();

                        // digit count per letter
                        int digit_count;
                        if (letter_number >= 1 && letter_number <= 9) 
                        {
                            digit_count = 1;
                        }
                        else 
                        {
                            digit_count = 2;
                        }

                        // Format the index string with the correct digit count
                        if (indexStr.Length == 1)
                        {
                            ciphertext += "00" + indexStr; 
                        }
                        else if (indexStr.Length == 2)
                        {
                            ciphertext += "0" + indexStr; 
                        }
                        else
                        {
                            ciphertext += indexStr; 
                        }

                        
                        ciphertext += digit_count.ToString();
                    }
                    else
                    {
                        // If the number is not found, add a placeholder (e.g., 000)
                        ciphertext += "0000"; // 000 + digit count (0)
                    }
                }
                else
                {
                    // Non-letter characters are ignored or added as-is
                    ciphertext += c.ToString();
                }
            }

            return ciphertext;
        }




        // Decrypt ciphertext
        public static string PiSubstitutionDecrypt(string ciphertext)
        {
            string decryptedText = "";
            int i = 0;

            while (i < ciphertext.Length)
            {
                // Extract the next 4 characters (3 digits for the index and 1 digit for the digit count)
                string group = ciphertext.Substring(i, 4);
                i += 4;

                // Extract the index and digit count from the group
                string numberStr = group.Substring(0, 3);
                int digit_count = int.Parse(group.Substring(3, 1));

                if (int.TryParse(numberStr, out int index))
                {
                    // Check if the number is valid and within the pi_decimal string's range
                    if (index > 0 && index + digit_count <= pi_decimal.Length)
                    {
                        // Get the number at the specified index (0-based)
                        string piSubStr = pi_decimal.Substring(index - 1, digit_count);

                        // Convert the number back to a letter (A = 1, B = 2, ..., Z = 26)
                        if (int.TryParse(piSubStr, out int letter_number) && letter_number >= 1 && letter_number <= 26)
                        {
                            char decryptedChar = (char)('A' + letter_number - 1);
                            decryptedText += decryptedChar;
                        }
                        else
                        {
                            // If it's not in the valid range, append a placeholder (e.g., '?')
                            decryptedText += "?";
                        }
                    }
                    else
                    {
                        // Handle invalid indices (e.g., 000)
                        decryptedText += "?";
                    }
                }
                else
                {
                    // Handle non-numeric characters (e.g., spaces, punctuation)
                    decryptedText += numberStr;
                }
            }

            return decryptedText;
        }
    }
    
}
