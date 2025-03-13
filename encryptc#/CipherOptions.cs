using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptc_
{
    public static class CipherOptions
    {
        private static string GetAction()
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

        /*==================================================================================================================*/
        public static void MonoalphabeticOption()
        {
            string action = GetAction();
            Console.WriteLine("||===================================================================================||");
            if (action == "1")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();
                Console.ResetColor();
                string ciphertext = Encryption_Decryption.Monoalphabetic_Encrypt(plaintext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Encrypted text: {ciphertext}");
                Console.ResetColor();
            }
            else if (action == "2")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();
                Console.ResetColor();
                string plaintext = Encryption_Decryption.MonoalphabeticDecrypt(ciphertext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Decrypted text: {plaintext}");
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void CaesarCipherOption()
        {
            string action = GetAction();

            if (action == "1")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter key (Integer): ");
                int key;
                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter key: ");
                }
                Console.ResetColor();

                string input_text = Encryption_Decryption.CaesarAlgoEncryption(plaintext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encrypted Text: " + input_text);
                Console.ResetColor();
            }
            else if (action == "2")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter key (Integer): ");
                int key;
                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter key: (Integer) ");
                }
                Console.ResetColor();

                string input_text = Encryption_Decryption.CaesarAlgoDecryption(ciphertext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encrypted Text: " + input_text);
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void TranspositionOption()
        {
            string action = GetAction();

            if (action == "1")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter key (String): ");
                string key = Console.ReadLine();
                Console.ResetColor();

                string input_text = Encryption_Decryption.TranspositionEncryption(plaintext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encrypted Text: " + input_text);
                Console.ResetColor();
            }
            else if (action == "2")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter key (String): ");
                string key = Console.ReadLine();
                Console.ResetColor();

                string input_text = Encryption_Decryption.TranspositionDecryption(ciphertext, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Decrypted Text: " + input_text);
                Console.ResetColor();
            }
        }

        /*==================================================================================================================*/
        public static void PiSubstitutionCipherOption()
        {
            string action = GetAction();

            if (action == "1")
            {
                string plaintext;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter text to encrypt (letters and spaces only): ");
                    plaintext = Console.ReadLine();
                    Console.ResetColor();

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

                string ciphertext = Encryption_Decryption.PiSubstitutionEncrypt(plaintext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Encrypted text: {ciphertext}");
                Console.ResetColor();
            }
            else if (action == "2")
            {
                string ciphertext;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter text to decrypt (numbers only, length divisible by 4): ");
                    ciphertext = Console.ReadLine();
                    Console.ResetColor();

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

                string plaintext = Encryption_Decryption.PiSubstitutionDecrypt(ciphertext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Decrypted text: {plaintext}");
                Console.ResetColor();
            }
        }
    }
}
