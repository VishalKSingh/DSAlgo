using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L12_IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            // Define the mapping of integer values to Roman numerals
            if (num <= 0 || num > 3999)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(symbols[i]);
                }
            }
            return sb.ToString();
        }
    }
}
