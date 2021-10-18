using System;
using System.Collections.Generic;

namespace CaerserCipherAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypteddata = new Program().EncryptText("Noor Nabi", 3);
            string decryptedata = new Program().DecryptText(encrypteddata, 3);

            Console.WriteLine("Encrypt Data = "+encrypteddata + "\n");
            Console.WriteLine("Original String Decrypt ="+decryptedata + "\n");
            Console.ReadLine();
        }


        public string EncryptText(string data, int shift)
        {

            string EncryptedText = "";
            foreach (var item in data)
            {
                if (String.IsNullOrWhiteSpace(item.ToString()))
                { EncryptedText += item; }
                else
                {
                    char newChar;
                    if (char.IsUpper(item))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue((Array.IndexOf(UpperCaseAlphabats, item) + shift) % 26);
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue((Array.IndexOf(LowerCaseAlphabats, item) + shift) % 26);
                    }
                    EncryptedText += newChar;
                }
            }

            return EncryptedText;
        }

        public string DecryptText(string data, int shift)
        {

            string DecryptText = "";
            foreach (var item in data)
            {   if (String.IsNullOrWhiteSpace(item.ToString()))
                { DecryptText += item; }
                else
                {
                    char newChar;
                    if (char.IsUpper(item))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue((Array.IndexOf(UpperCaseAlphabats, item) - shift) % 26);
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue((Array.IndexOf(LowerCaseAlphabats, item) - shift) % 26);

                    }
                    DecryptText += newChar;
                }
            }

            return DecryptText;
        }

        public char[] LowerCaseAlphabats
        {
            get
            {
                char[] loweralpha = new char[26];
                int i = 0;
                for(char c='a';c<='z';c++)
                {
                    loweralpha.SetValue(c,i);
                    i++;

                }

                return loweralpha;
            }
        }

        public char[] UpperCaseAlphabats
        {
            get
            {
                char[] upperalpha = new char[26];
                int i = 0;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    upperalpha.SetValue(c, i);
                    i++;

                }

                return upperalpha;
            }
        }

    }
}
