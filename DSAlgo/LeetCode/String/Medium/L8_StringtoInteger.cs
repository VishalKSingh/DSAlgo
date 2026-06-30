using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L8_StringtoInteger
    {
        public int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int i = 0;
            // Skip leading whitespaces
            while (i < s.Length && s[i] == ' ')
                i++;
            // If we have reached the end of the string, return 0
            if (i == s.Length)
                return 0;
            // Check for sign
            int sign = 1;
            if (s[i] == '+' || s[i] == '-')
            {
                sign = s[i] == '-' ? -1 : 1;
                i++;
            }
            long result = 0;
            while (i < s.Length && char.IsDigit(s[i]))
            {
                result = result * 10 + (s[i] - '0');
                // Check for overflow and underflow
                if (result * sign > int.MaxValue)
                    return int.MaxValue;
                if (result * sign < int.MinValue)
                    return int.MinValue;
                i++;
            }
            return (int)(result * sign);
        }
    }
}
