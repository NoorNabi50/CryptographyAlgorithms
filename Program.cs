using CryptographyAlgorithms;
using System;
using System.Collections.Generic;

namespace CaerserCipherAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************************CryptoGraphy Algorithms In C# By Noor Nabi************************************************");
            Console.WriteLine("Here Are Algorithms to use : \n1 FOR SHIFT CIPHER\n2 FOR VIGENER CIPHER\n");
            Console.WriteLine("Enter Above Options To Use ALGORITHM :\n");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                string encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Key to Encrypt");
                int key = Convert.ToInt32(Console.ReadLine());
                encrypteddata = new ShiftCipher().EncryptText(encrypteddata, key);
                string decryptedata = new ShiftCipher().DecryptText(encrypteddata, key);
                Console.WriteLine("\nEncrypt Data = " + encrypteddata + "\n");
                Console.WriteLine("Original Message Decrypt =" + decryptedata + "\n");
                Console.ReadLine();
            }

            else if (option == "2")
            {
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                string encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Keys to Encrypt:");
                string keys = Console.ReadLine();
                encrypteddata = new VigenerCipher().DecryptText(encrypteddata, keys);


            }

            else
            {
                Console.WriteLine("Invalid Option Selected");
            }

        }


    }
}
