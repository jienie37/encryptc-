using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{
    public static class CipherOptions
    {
        private static string Option()
        {
            string action;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("");
                Console.Write("Choose action (1. Encrypt, 2. Decrypt): ");
                action = Console.ReadLine();
                Console.ResetColor();
                if (action == "1" || action == "2")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid action. Please choose 1 or 2.");
                    Console.ResetColor();
                }
            }
            return action;
        }

        private static string ValidateInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(prompt);
                input = Console.ReadLine();
                Console.ResetColor();
                if (!string.IsNullOrEmpty(input))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty.");
                    Console.ResetColor();
                }
            }
            return input;
        }

        private static string ValidateInputLetters(string prompt)
        {
            string input;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(prompt);
                input = Console.ReadLine();
                Console.ResetColor();
                if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter letters only.");
                    Console.ResetColor();
                }
            }
            return input;
        }
        /*==================================================================================================================*/
        public static void MonoalphabeticOption()
        {
            CipherInfo.Monoalphabetic_Info();
            string action = Option();
            Console.WriteLine("||===================================================================================||");
            if (action == "1")
            {
                string plaintext = ValidateInputLetters("Enter text to encrypt: ");
                string ciphertext = Encryption_Decryption.Monoalphabetic_Encrypt(plaintext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Encrypted text: {ciphertext}");
                Console.ResetColor();
            }
            else if (action == "2")
            {
                string ciphertext = ValidateInputLetters("Enter text to decrypt: ");
                string plaintext = Encryption_Decryption.Monoalphabetic_Decrypt(ciphertext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Decrypted text: {plaintext}");
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void CaesarOption()
        {
            CipherInfo.Caesar_Info();
            string action = Option();

            if (action == "1")
            {
                string plaintext = ValidateInputLetters("Enter text to encrypt: ");
                int key;
                while (true)
                {
                    string keyInput = ValidateInput("Enter key (1-26): ");
                    if (int.TryParse(keyInput, out key) && key >= 1 && key <= 26)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 26.");
                        Console.ResetColor();
                    }
                }

                string input_text = Encryption_Decryption.CaesarAlgo_Encryption(plaintext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encrypted Text: " + input_text);
                Console.ResetColor();
            }
            else if (action == "2")
            {
                string ciphertext = ValidateInputLetters("Enter text to decrypt: ");
                int key;
                while (true)
                {
                    string keyInput = ValidateInput("Enter key (1-26): ");
                    if (int.TryParse(keyInput, out key) && key >= 1 && key <= 26)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 26.");
                        Console.ResetColor();
                    }
                }

                string input_text = Encryption_Decryption.CaesarAlgo_Decryption(ciphertext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Decrypted Text: " + input_text);
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void TranspositionOption()
        {
            CipherInfo.Transposition_Info();
            string action = Option();

            if (action == "1")
            {
                string plaintext = ValidateInput("Enter text to encrypt: ");
                string key = ValidateInput("Enter key (String): ");
                string input_text = Encryption_Decryption.Transposition_Encryption(plaintext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encrypted Text: " + input_text);
                Console.ResetColor();
            }
            else if (action == "2")
            {
                string ciphertext = ValidateInput("Enter text to decrypt: ");
                string key = ValidateInput("Enter key (String): ");
                string input_text = Encryption_Decryption.Transposition_Decryption(ciphertext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Decrypted Text: " + input_text);
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void PiSubstitutionOption()
        {
            CipherInfo.PiSubstitution_Info();
            string action = Option();

            if (action == "1")
            {
                string plaintext;
                while (true)
                {
                    plaintext = ValidateInput("Enter text to encrypt (letters and spaces only): ");
                    if (plaintext.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter letters and spaces only.");
                        Console.ResetColor();
                    }
                }

                string ciphertext = Encryption_Decryption.Pi_Substitution_Encrypt(plaintext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Encrypted text: {ciphertext}");
                Console.ResetColor();
            }
            else if (action == "2")
            {
                string ciphertext;
                while (true)
                {
                    ciphertext = ValidateInput("Enter text to decrypt (numbers only, length divisible by 4): ");
                    if (ciphertext.All(char.IsDigit) && ciphertext.Length % 4 == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter numbers only and ensure the length is divisible by 4.");
                        Console.ResetColor();
                    }
                }

                string plaintext = Encryption_Decryption.Pi_Substitution_Decrypt(ciphertext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Decrypted text: {plaintext}");
                Console.ResetColor();
            }
        }
    }
}
