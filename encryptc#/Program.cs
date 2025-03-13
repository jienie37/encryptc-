using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using encryptc_;

namespace encryptc_
{
    class Program
    {
        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Monoalphabetic Cipher");
            Console.WriteLine("2. Caesar Cipher");
            Console.WriteLine("3. Transposition Cipher");
            Console.WriteLine("4. Pi Substitution Cipher");
            Console.WriteLine("5. Exit");
        }

        static void Main()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    CipherOptions.MonoalphabeticOption();
                    TryAgain();
                }
                else if (choice == "2")
                {

                    CipherOptions.CaesarCipherOption();
                    TryAgain();

                }
                else if (choice == "3")
                {
                    CipherOptions.TranspositionOption();
                    TryAgain();
                }
                else if (choice == "4")
                {
                    CipherOptions.PiSubstitutionCipherOption();
                    TryAgain();
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void TryAgain()
        {
            Console.WriteLine("||===================================================================================||");
            Console.Write("Would you like to try again? [Y]es, [N]o, or [C]lear the console and try again: ");
            while (true)
            {
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.WriteLine("||===================================================================================||");
                    Console.WriteLine("");
                    Main();
                }
                else if (input == "C")
                {
                    Console.Clear();
                    Main();
                }
                else if (input == "N")
                {
                    Console.WriteLine("Exiting...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.Write("Invalid action. Pick between Y, N, or C: ");
                }
            }
        }
    }
}