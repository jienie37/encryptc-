using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using encryptc_;

namespace encryptc_
{
    public static class CipherInfo
    {
        private static void Info(string title, string description, string example, string pros, string cons)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("||===================================================================================||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{title}:");
            Console.WriteLine(description);
            Console.WriteLine($"Example: {example}");
            Console.WriteLine();
            Console.WriteLine("Pros:");
            Console.WriteLine(pros);
            Console.WriteLine();
            Console.WriteLine("Cons:");
            Console.WriteLine(cons);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("||===================================================================================||");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Monoalphabetic_Info()
        {
            Info(
                "Monoalphabetic Cipher",
                "A monoalphabetic cipher is a substitution cipher where each letter in the plaintext is replaced\nby a letter with a fixed relationship to it.",
                "A -> Q, B -> W, C -> E, etc.",
                "- Easy to implement and understand.\n- Provides a basic level of security.",
                "- Can be cracked by looking at letter patterns.\n- Once the substitution pattern is known, the cipher can be easily broken."
            );
        }

        public static void Caesar_Info()
        {
            Info(
                "Caesar Cipher",
                "Caesar cipher is the same as the monoalphabetic cipher in which a each letter is substituted to another letter allocated by a number(key) where each letter in the plaintext is shifted a certain\nnumber of places down the alphabet.",
                "With a shift(key) of 3, A -> D, B -> E, C -> F, etc.",
                "- Simple to implement and understand.\n- Provides a basic level of security.",
                "- Vulnerable to frequency analysis attacks.\n- Limited number of possible keys (26), making it easy to brute-force."
            );
        }

        public static void Transposition_Info()
        {
            Info(
                "Transposition Cipher",
                "A transposition cipher is a method of encryption where the positions of the characters\nin the plaintext are shifted according to a regular system.",
                "Using a key, the characters are rearranged in a grid and read column by column.",
                "- More secure than simple substitution ciphers.\n- Preserves the frequency distribution of the characters.",
                "- Requires a key for encryption and decryption.\n- More complex to implement and understand compared to substitution ciphers."
            );
        }

        public static void PiSubstitution_Info()
        {
            Info(
                "Pi Substitution Cipher",
                "The Pi substitution cipher uses the digits of Pi to create a substitution cipher, where each letter\n is replaced by its position in the Pi decimal sequence.",
                "A -> 0011 (001 = the position it first appeared, 1 = digits needed to be extracted)\n B -> 0061\n C -> 0091 ",
                "- Uses Pi’s digits, making it harder to guess.\n- More secure than simple ciphers.",
                "- Harder to implement and understand.\n- You need Pi’s digits to encode and decode messages."
            );
        }
    }
}
