using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyAlgorithms
{
  public class ShiftCipher
    { 
        private char[] LowerCaseAlphabats
        {
            get
            {
                char[] loweralpha = new char[30];
                int i = 0;
                for (char c = 'a'; c <= 'z'; c++)
                {
                    loweralpha.SetValue(c, i);
                    i++;

                }

                return loweralpha;
            }
        }

        private char[] UpperCaseAlphabats
        {
            get
            {
                char[] upperalpha = new char[30];
                int i = 0;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    upperalpha.SetValue(c, i);
                    i++;

                }

                return upperalpha;
            }
        }
        public string EncryptText(string data, int shift)
        {

            string EncryptedText = "";
            foreach (var item in data)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                { EncryptedText += item; }
                else
                {
                    char newChar;
                    if (char.IsUpper(item))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, item) + shift));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats, item) + shift));
                    }
                    EncryptedText += newChar;
                }
            }

            return EncryptedText;
        }

        public int ApplyModuluesTheorem(int val)
        {
            if (val < 0) 
            { return val + 26; }

            else
            {
                return val % 26;
            }
        }

        public string DecryptText(string data, int shift)
        {
            string DecryptText = "";
            foreach (var item in data)
            {
                if (String.IsNullOrWhiteSpace(item.ToString()))
                { DecryptText += item; }
                else
                {
                    char newChar;
                    if (char.IsUpper(item))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, item) - shift));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats ,item) - shift));

                    }
                    DecryptText += newChar;
                }
            }

            return DecryptText;
        }

    }
}
