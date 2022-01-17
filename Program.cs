using CryptographyAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaerserCipherAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypteddata;
            string decrypteddata;
            int? g = null;
            int? p = null;
            int? a = null;
            int? b = null;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***********************************************CryptoGraphy Algorithms In C# By Noor Nabi*******************************************");
            Console.WriteLine("Here Are Algorithms to use : \n1 FOR SHIFT CIPHER\n2 FOR VIGENER CIPHER\n3 FOR AFFINE CIPHER \n4 For Peforming Deffie Hellman Key Exchange Method");
            Console.WriteLine("Enter Above Options To Use ALGORITHM :\n");
            string option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                Console.WriteLine("                                         CAESAR CIPHER ");
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Key to Encrypt");
                int key = Convert.ToInt32(Console.ReadLine());
                encrypteddata = new ShiftCipher().EncryptText(encrypteddata, key);
                decrypteddata = new ShiftCipher().DecryptText(encrypteddata, key);
                Console.WriteLine("\nEncrypt Data = " + encrypteddata + "\n");
                Console.WriteLine("Original Message Decrypt =" + decrypteddata + "\n");
                Console.ReadLine();
            }

            else if (option == "2")
            {

                Console.WriteLine("                                         Vigener CIPHER ");
                Console.WriteLine("\nEnter Plain Text to Encrypt:");
                encrypteddata = Console.ReadLine();
                Console.WriteLine("Enter Keys to Encrypt: NOTE IF Keys are Digits then use separated comma between each key");
                string Getkeys = Console.ReadLine();
                int[] Keys = new int[26];
                string testKeys = Getkeys;
                testKeys = testKeys.Replace(",", "");
                if (!testKeys.All(char.IsDigit))
                {
                    Keys = Getkeys.Select(x => Array.IndexOf(new VigenerCipher().UpperCaseAlphabats, x)).ToArray();
                    encrypteddata = new VigenerCipher().EncryptText(encrypteddata, Keys);
                    decrypteddata = new VigenerCipher().DecryptText(encrypteddata, Keys);
                }
                else
                {
                    Keys = Getkeys.Split(',').Select(int.Parse).ToArray();
                    encrypteddata = new VigenerCipher().EncryptText(encrypteddata, Keys);
                    decrypteddata = new VigenerCipher().DecryptText(encrypteddata, Keys);
                }
                Console.WriteLine("\nCipher Data = " + encrypteddata + "\n");
                Console.WriteLine("\nDecrypted Data = " + decrypteddata + "\n");

            }

            else if (option == "4")
            {

                Console.WriteLine("                                         Diffie Hellman Key ");
                Console.WriteLine("Please Provide Public parameters for :\n");
                Console.WriteLine("Enter Value of P [It should be a prime Number : ]");
                p = Convert.ToInt32(Console.ReadLine());
                //check it is prime number or not
                if (DiffieHellmankey.IsPrime(p))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Given Number Is not a Prime Number !!!!");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nEnter Value of G : [It should be a natural number ,preferably not zero or one : ] \n");
                g = Convert.ToInt32(Console.ReadLine());
                if (g == 0 || g == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Given Number Should be greater than 0 and 1 !!!! Try Again..");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please Select Secrets for Bob & Alic: \n");
                Console.Write("Bob [a] : Enter value of a : ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nAlice [b] : Enter value of b : ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("BOB                                                     | ALICE\n\n");
                Console.WriteLine("A = g ^ a mod p                                         | B = g ^ b mod p");
                Console.WriteLine("A = " + g.ToString() + " ^ " + a.ToString() + " MOD " + p.ToString()+"                                       | B = "+ g.ToString()+" ^ "+b.ToString()+ " MOD " + p.ToString());
                var PublicKey = DiffieHellmankey.FindPublicKeysForBoth(p, g, a, b);
                Console.WriteLine("A = " + PublicKey.Item1.ToString() +"                                                   | B = " +PublicKey.Item2.ToString());
                Console.WriteLine("Exchanging public key ..Please Wait....");
                Task.Delay(4000);
                Console.WriteLine("Key = B ^ a mod p                                       | Key = A ^ b mod p");
                var PrivateKey = DiffieHellmankey.FindPrivateKeysForBoth(PublicKey.Item1, PublicKey.Item2, a, b, p);
                Console.WriteLine("key = " + PublicKey.Item2.ToString() + " ^ " + a.ToString() + " MOD " + p.ToString() + "                                     | Key = " + PublicKey.Item1.ToString() + " ^ " + b.ToString() + " MOD " + p.ToString());
                Console.WriteLine("Key = " + PrivateKey.Item1.ToString() + "                                                  | Key = " + PrivateKey.Item2.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
               
                Console.WriteLine("\n                                              KEY = " + PrivateKey.Item1);
                Console.ForegroundColor = ConsoleColor.White;

            }

            else
            {
                Console.WriteLine("Invalid Option Selected");
            }


            //0,24,20,18,7




        }
    }
}
