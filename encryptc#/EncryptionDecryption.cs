using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{
    public static class Encryption_Decryption
    {
        /*====================================== Monoalphabetic Algorithm ======================================*/
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
            return ciphertext.ToString().ToUpper();
        }

        public static string Monoalphabetic_Decrypt(string ciphertext)
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
                if (c == ' ')
                {
                    continue;
                }
                if (decryptionMap.ContainsKey(c))
                {
                    plaintext.Append(decryptionMap[c]);
                }
                else
                {
                    plaintext.Append(c);
                }
            }
            return plaintext.ToString().ToUpper();
        }


        /*====================================== Caesar Cipher Algorithm ======================================*/
        public static string CaesarAlgo_Encryption(string text, int key)
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

        public static string CaesarAlgo_Decryption(string ciphertext, int key)
        {
            ciphertext = ciphertext.ToUpper();
            string result = "";

            foreach (char c in ciphertext)
            {
                if (c == ' ')
                {
                    continue;
                }
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


        /*====================================== Transposition Cipher Algorithm ======================================*/
        public static string Transposition_Encryption(string plaintext, string key)
        {
            key = key.Replace(" ", "");

            int[] keyOrder = Get_Key_Order(key);
            int columns = key.Length;
            int rows = (int)Math.Ceiling((double)plaintext.Length / columns);
            char[,] grid = new char[rows, columns];

            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (index < plaintext.Length)
                    {
                        grid[r, c] = plaintext[index++];
                    }
                    else
                    {
                        grid[r, c] = '\0';
                    }
                }
            }

            string result = "";
            for (int i = 0; i < columns; i++)
            {
                int col = keyOrder[i];
                for (int r = 0; r < rows; r++)
                {
                    if (grid[r, col] != '\0')
                    {
                        result += grid[r, col];
                    }
                }
            }
            return result;
        }

        public static string Transposition_Decryption(string ciphertext, string key)
        {
            int[] keyOrder = Get_Key_Order(key);
            int columns = key.Length;
            int rows = (int)Math.Ceiling((double)ciphertext.Length / columns);
            char[,] grid = new char[rows, columns];

            int index = 0;
            for (int i = 0; i < columns; i++)
            {
                int col = keyOrder[i];
                for (int r = 0; r < rows; r++)
                {
                    if (index < ciphertext.Length)
                        grid[r, col] = ciphertext[index++];
                }
            }

            string result = "";
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    result += grid[r, c];
                }
            }
            return result.TrimEnd('X');
        }

        public static int[] Get_Key_Order(string key)
        {
            char[] sortedKey = key.OrderBy(c => c).ToArray();
            int[] order = new int[key.Length];
            bool[] assigned = new bool[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (!assigned[j] && key[j] == sortedKey[i])
                    {
                        order[i] = j;
                        assigned[j] = true;
                        break;
                    }
                }
            }
            return order;
        }

        /*====================================== Pi Substitution Cipher Algorithm ======================================*/
        public static string pi_decimal = "141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930381964428810975665933446128475648233786783165271201909145648566923460348610454326648213393607260249141273724587006606315588174881520920962829254091715364367892590360011330530548820466521384146951941511609433057270365759591953092186117381932611793105118";

        public static string Pi_Substitution_Encrypt(string plaintext)
        {
            plaintext = plaintext.ToUpper(); 
            string ciphertext = "";

            foreach (char c in plaintext)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (char.IsLetter(c))
                {
                    // get the letter's number (A = 1, B = 2, ..., Z = 26)
                    int letter_number = c - 'A' + 1;

                    // find the index of the letter in the pi_decimal string
                    int index = pi_decimal.IndexOf(letter_number.ToString());

                    
                    // add the index to the ciphertext
                    string index_string = (index + 1).ToString();

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

                    // add 0s to the index if it's less than 3 digits
                    if (index_string.Length == 1)
                    {
                        ciphertext += "00" + index_string; 
                    }
                    else if (index_string.Length == 2)
                    {
                        ciphertext += "0" + index_string; 
                    }
                    else
                    {
                        ciphertext += index_string; 
                    }

                        
                    ciphertext += digit_count.ToString();
                    
                }
                else
                {
                    ciphertext += c.ToString();
                }
            }

            return ciphertext;
        }




        public static string Pi_Substitution_Decrypt(string ciphertext)
        {
            string plaintext = "";
            int i = 0;

            while (i < ciphertext.Length)
            {
                // gets 4 digits at a time (3 from the index, 1 for the digit count)
                string group = ciphertext.Substring(i, 4);
                i += 4;

                string index_string = group.Substring(0, 3); // index number
                int digit_count = int.Parse(group.Substring(3, 1));// digit count

                if (int.TryParse(index_string, out int index))
                {                    
                    // get number from pi_decimal string, digit_count is the numeber of digits to get
                    string pi_string = pi_decimal.Substring(index - 1, digit_count);

                    // turn the number back to a letter
                    if (int.TryParse(pi_string, out int letter_number) && letter_number >= 1 && letter_number <= 26)
                    {
                        char decrypted_char = (char)('A' + letter_number - 1);
                        plaintext += decrypted_char;
                    }
                    else
                    {
                        // If it's not in the valid range, append a placeholder (e.g., '?')
                        plaintext += "?";
                    }
                    
                }
                else
                {
                    plaintext += index_string;
                }
            }

            return plaintext;
        }
    }
    
}
