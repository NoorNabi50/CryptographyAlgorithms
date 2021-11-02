using CryptographyAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaerserCipherAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypteddata;
            string decryptedata;
            Console.WriteLine("***********************************************CryptoGraphy Algorithms In C# By Noor Nabi************************************************");
            Console.WriteLine("Here Are Algorithms to use : \n1 FOR SHIFT CIPHER\n2 FOR VIGENER CIPHER\n");
            Console.WriteLine("Enter Above Options To Use ALGORITHM :\n");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Key to Encrypt");
                int key = Convert.ToInt32(Console.ReadLine());
                encrypteddata = new ShiftCipher().EncryptText(encrypteddata, key);
                decryptedata = new ShiftCipher().DecryptText(encrypteddata, key);
                Console.WriteLine("\nEncrypt Data = " + encrypteddata + "\n");
                Console.WriteLine("Original Message Decrypt =" + decryptedata + "\n");
                Console.ReadLine();
            }

            else if (option == "2")
            {
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Keys to Encrypt: NOTE IF Keys are Digits then use separated comma between each key");
                string Getkeys = Console.ReadLine();
                int[] Digitkeys = new int[26];
                string testKeys = Getkeys;
                testKeys = testKeys.Replace(",","");
                if (!testKeys.All(char.IsDigit))
                {
                    Digitkeys = Getkeys.Select(x => Array.IndexOf(new VigenerCipher().UpperCaseAlphabats, x)).ToArray();
                    encrypteddata = new VigenerCipher().EncryptText(encrypteddata, Digitkeys);
                }
                else
                {
                    Digitkeys = Getkeys.Split(',').Select(int.Parse).ToArray();
                    encrypteddata = new VigenerCipher().EncryptText(encrypteddata, Digitkeys);
                }


                Console.WriteLine("\nEncrypt Data = " + encrypteddata + "\n");

            }

            else
            {
                Console.WriteLine("Invalid Option Selected");
            }


            //0,24,20,18,7




        }
    }
}
