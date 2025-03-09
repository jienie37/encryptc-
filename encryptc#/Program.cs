using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using encryptc_;

class Program
{
    static void DisplayMenu()
    {
        Console.WriteLine("1. Monoalphabetic Cipher");
        Console.WriteLine("2. Polyalphabetic Cipher (Vigenère)");
        Console.WriteLine("3. Exit");
    }

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMenu();
            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CipherOptions.MonoalphabeticOption();
            }
            else if (choice == "2")
            {
                CipherOptions.PolyalphabeticOption();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }
        }
    }
}