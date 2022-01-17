using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyAlgorithms
{
     public class DiffieHellmankey
    {

        public static bool IsPrime(int? p = 0)
        {
            if (p == 0)
                return true;

            bool PrimeIs = false;
            for(int i = 2 ; i < p; i++)
            {
                 if (p % i == 0)
                {
                    PrimeIs = true;
                    break;
                }
                PrimeIs = false;
            }

            return PrimeIs;
        }


        public static Tuple<int,int> FindPublicKeysForBoth(int? p =0,int? g=0,int? a = 0,int? b = 0)
        {
            //Formulae A = g^a *mod p
            int A = (int)(Convert.ToInt32(Math.Pow(Convert.ToDouble(g), Convert.ToDouble(a))) % p);

            //Formulae A = g^b *mod p

            int B = (int)(Convert.ToInt32(Math.Pow(Convert.ToDouble(g), Convert.ToDouble(b))) % p);

            return Tuple.Create(A, B);
            
        }

        public static Tuple<int,int> FindPrivateKeysForBoth(int A , int B , int? a =0,int? b=0,int? p=0)
        {
            //formulae K = B ^ a mod p
            int BobKey = (int)(Convert.ToInt32(Math.Pow(Convert.ToDouble(B), Convert.ToDouble(a))) % p);
            //formulae K = A ^ b mod p

            int AliceKey = (int)(Convert.ToInt32(Math.Pow(Convert.ToDouble(A), Convert.ToDouble(b))) % p);

            return Tuple.Create(BobKey, AliceKey);
        }
    }
}
