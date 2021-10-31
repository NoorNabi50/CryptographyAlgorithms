using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptographyAlgorithms
{
  public  class VigenerCipher
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

        private int keyVal{ get; set; }
        private char newChar { get; set; }
        public int ApplyModuluesTheorem(int val)
        {
            if (val < 0) return val + 26;

            else return val % 26;
        }



        public string EncryptText(string data, string keys)
        {
            string EncryptedText = "";

            for(int i=0;i<data.Length;i++)
            {
                if (string.IsNullOrWhiteSpace(data[i].ToString()))
                {
                    EncryptedText += data[i];
                }
                else
                {
                    if(!keys.All(char.IsDigit))
                    {
                        keyVal = Array.IndexOf(UpperCaseAlphabats, keys[i]);
                    }
                    else
                    {
                        keyVal = keys[i];
                    }
                    if (char.IsUpper(data[i]))
                    {  
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, data[i]) + keyVal));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats, data[i]) + keyVal));
                    }
                    EncryptedText += newChar;
                }
            }
            return EncryptedText;
        }


        public string DecryptText(string data, string keys)
        {
            string DeccryptedText = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(data[i].ToString()))
                {
                    DeccryptedText += data[i];
                }
                else
                {
                    if (!keys.All(char.IsDigit))
                    {
                        keyVal = Array.IndexOf(UpperCaseAlphabats, keys[i]);
                    }
                    else
                    {
                        keyVal = keys[i];
                    }
                    if (char.IsUpper(data[i]))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, data[i]) - keyVal));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats, data[i]) - keyVal));
                    }
                    DeccryptedText += newChar;
                }
            }
            return DeccryptedText;
        }







    }
}
