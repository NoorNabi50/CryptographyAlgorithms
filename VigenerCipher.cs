using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptographyAlgorithms
{
  public  class VigenerCipher
    {
        public char[] LowerCaseAlphabats
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
        public char[] UpperCaseAlphabats
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



        public string EncryptText(string data, dynamic keys)
        {
            string EncryptedText = "";

            for (int i = 0, j = 0; i <= data.Length && j != -1; i++, j++)
            {
                if (data.Length == i)
                {
                    break;
                }
                else if (keys.Length == j)
                {
                    j = 0;
                }
                
                if (string.IsNullOrWhiteSpace(data[i].ToString()))
                {
                    EncryptedText += data[i];
                }
                else
                {
                    if (char.IsUpper(data[i]))
                    {  
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, data[i]) + Convert.ToInt32(keys[j])));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats, data[i]) + Convert.ToInt32(keys[j])));
                    }
                    EncryptedText += newChar;
                }
            }
            return EncryptedText;
        }


        public string DecryptText(string data, dynamic keys)
        {
            string DeccryptedText = "";

            for (int i = 1,j=1; i <= data.Length && j<0; i++,j++)
            {
                if(keys.Length==j)
                {
                    j = 0;
                }
                else if(data.Length==i)
                {
                    j = -1;

                }
                if (string.IsNullOrWhiteSpace(data[i].ToString()))
                {
                    DeccryptedText += data[i];
                }
                else
                {
                    if (char.IsUpper(data[i]))
                    {
                        newChar = (char)UpperCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(UpperCaseAlphabats, data[i]) - keys[j]));
                    }
                    else
                    {
                        newChar = (char)LowerCaseAlphabats.GetValue(ApplyModuluesTheorem(Array.IndexOf(LowerCaseAlphabats, data[i]) - keys[j]));
                    }
                    DeccryptedText += newChar;
                }
               
                

            }
            return DeccryptedText;
        }







    }
}
