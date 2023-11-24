using System;

namespace pw3z5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для шифрования:");
            string input = Console.ReadLine();

            Console.WriteLine("Введите сдвиг:");
            int shift = int.Parse(Console.ReadLine());

            CaesarCipher cipher = new CaesarCipher();
            string encryptedText = cipher.Encrypt(input, shift);
            Console.WriteLine($"Зашифрованный текст: {encryptedText}");

            string decryptedText = cipher.Decrypt(encryptedText, shift);
            Console.WriteLine($"Расшифрованный текст: {decryptedText}");
        }
    }

    public class CaesarCipher
    {
        private const int AlphabetSize = 26;

        public string Encrypt(string input, int shift)
        {
            string encryptedText = "";

            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    char encryptedChar = EncryptCharacter(character, shift);
                    encryptedText += encryptedChar;
                }
                else
                {
                    encryptedText += character;
                }
            }

            return encryptedText;
        }

        public string Decrypt(string input, int shift)
        {
            return Encrypt(input, -shift);
        }

        private char EncryptCharacter(char character, int shift)
        {
            char baseChar = char.IsUpper(character) ? 'A' : 'a';
            int offset = shift % AlphabetSize;
            char encryptedChar = (char)((((character + offset) - baseChar) % AlphabetSize) + baseChar);
            return encryptedChar;
        }
    }
}