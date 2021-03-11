using System;
using System.Collections.Generic;

namespace RomesNumb
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = IntToRoman(3999);
            Console.WriteLine(s);
        }

        public static string IntToRoman(int num)
        {
            Dictionary<int, string[]> dictionary = GetRomeNumbersDictonary();
            string result = string.Empty;
            int digitCapacity = 10000;

            for (int iterator = 10000; iterator >= 10; iterator /= 10)
            {
                digitCapacity /= 10;
                int numeral = (num % iterator) / digitCapacity;
                if (numeral > 0)
                {
                    result += AddSymbol(numeral, dictionary[digitCapacity]);
                }
            }
            return result;
        }

        private static string AddSymbol(int numeral, string[] dictionary)
        {
            string result = string.Empty;
            if (numeral >= 5)
            {
                if (numeral == 9)
                {
                    return dictionary[3];
                }
                else
                {
                    result += dictionary[2];
                    for (int i = 5; i < numeral; ++i)
                    {
                        result += dictionary[0];
                    }
                }
            }
            else
            {
                if (numeral == 4) return dictionary[1];
                for (int i = 0; i < numeral; ++i)
                {
                    result += dictionary[0];
                }
            }
            return result;
        }

        private static Dictionary<int, string[]> GetRomeNumbersDictonary()
        {
            Dictionary<int, string[]> romeNumbs = new Dictionary<int, string[]>();

            romeNumbs.Add(1000, new string[] { "M" });
            romeNumbs.Add(100, new string[] { "C", "CD", "D", "CM" });
            romeNumbs.Add(10, new string[] { "X", "XL", "L", "XC" });
            romeNumbs.Add(1, new string[] { "I", "IV", "V", "IX" });

            return romeNumbs;
        }
    }
}

