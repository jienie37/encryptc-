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
                string ciphertext = Encryption_Decryption.Monoalphabetic_Encrypt(plaintext);
                Console.WriteLine($"Encrypted text: {ciphertext}");
            }
            else if (action == "2")
            {
                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();
                string plaintext = Encryption_Decryption.MonoalphabeticDecrypt(ciphertext);
                Console.WriteLine($"Decrypted text: {plaintext}");
            }
            else
            {
                Console.WriteLine("Invalid action.");
            }
        }



        public static void CaesarCipherOption()
        {
            Console.Write("Choose action (1. Encrypt, 2. Decrypt): ");
            string action = Console.ReadLine();

            if (action == "1")
            {
                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();

                Console.Write("Enter key (Integer): ");
                int key;
                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("Enter key: ");
                }

                string inputText = Encryption_Decryption.CaesarAlgoEncryption(plaintext, key);
                Console.WriteLine("Encrypted Text: " + inputText);
            }
            else if (action == "2")
            {

                Console.Write("Enter text to decrypt: ");
                string ciphertext = Console.ReadLine();

                Console.Write("Enter key (Integer): ");
                int key;
                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("Enter key: (Integer) ");
                }

                string inputText = Encryption_Decryption.CaesarAlgoDecryption(ciphertext, key);
                Console.WriteLine("Encrypted Text: " + inputText);
            }
            else
            {
                Console.WriteLine("Invalid action. Please choose 1 or 2");

            }
        }


        public static void PiSubstitutionCipherOption()
        {
            Console.Write("Choose action (1. Encrypt, 2. Decrypt): ");
            string action = Console.ReadLine();

            if (action == "1")
            {
                string plaintext;
                while (true)
                {
                    Console.Write("Enter text to encrypt (letters and spaces only): ");
                    plaintext = Console.ReadLine();

                    if (plaintext.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter letters and spaces only.");
                    }
                }

                string ciphertext = Encryption_Decryption.PiSubstitutionEncrypt(plaintext);
                Console.WriteLine($"Encrypted text: {ciphertext}");
            }
            else if (action == "2")
            {
                string ciphertext;
                while (true)
                {
                    Console.Write("Enter text to decrypt (numbers only, length divisible by 4): ");
                    ciphertext = Console.ReadLine();

                    if (ciphertext.All(char.IsDigit) && ciphertext.Length % 4 == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter numbers only and ensure the length is divisible by 4.");
                    }
                }

                string plaintext = Encryption_Decryption.PiSubstitutionDecrypt(ciphertext);
                Console.WriteLine($"Decrypted text: {plaintext}");
            }
            else
            {
                Console.WriteLine("Invalid action. Please choose 1 or 2.");
            }
        }
    }
}
