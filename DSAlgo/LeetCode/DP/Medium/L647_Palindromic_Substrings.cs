using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L647_Palindromic_Substrings
    {
        public L647_Palindromic_Substrings() { }
        public L647_Palindromic_Substrings(string s)
        {
            Console.WriteLine(CountSubstrings(s));
        }

        public L647_Palindromic_Substrings(string s, int expected)
        {
            int result = CountSubstrings(s);
            Console.WriteLine($"Input: {s}, Expected: {expected}, Result: {result}");
        }

        public int CountSubstrings(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int count = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    if (s[i] == s[j] && (j - i < 3 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                        count++;
                    }
                }
            }
            return count;
        }

        // Another approach using expand around center
        public int CountSubstringsExpandAroundCenter(string s)
        {
            int n = s.Length;
            int count = 0;
            for (int center = 0; center < 2 * n - 1; center++)
            {
                int left = center / 2;
                int right = left + center % 2;
                while (left >= 0 && right < n && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }
            return count;
        }
        }
}
