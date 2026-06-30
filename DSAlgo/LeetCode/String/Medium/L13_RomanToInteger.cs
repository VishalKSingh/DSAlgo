using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L13_RomanToInteger
    {
        public int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            Dictionary<char, int> romanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // If the current value is less than the next value, subtract it from the total
                if (i < s.Length - 1 && romanMap[s[i]] < romanMap[s[i + 1]])
                {
                    total -= romanMap[s[i]];
                }
                else
                {
                    total += romanMap[s[i]];
                }
            }
            return total;
        }
    }
}
