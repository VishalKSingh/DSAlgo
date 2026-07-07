using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L516LongestPalindromicSubsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];
            // Every single character is a palindrome of length 1
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }
            // Build the dp array
            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    if (s[i] == s[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[0, n - 1];
        }

        
        public int LongestPalindromeSubseqOptimized(string s)
        {
            int n = s.Length;
            int[] dp = new int[n];// dp[j] will hold the length of the longest palindromic subsequence in s[i..j]
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i] = 1; // Every single character is a palindrome of length 1
                int prev = 0; // This will hold the value of dp[i + 1][j - 1]
                for (int j = i + 1; j < n; j++)
                {
                    int temp = dp[j]; // Store the current value before updating it
                    if (s[i] == s[j])
                    {
                        dp[j] = prev + 2;
                    }
                    else
                    {
                        dp[j] = Math.Max(dp[j], dp[j - 1]);
                    }
                    prev = temp; // Update prev to the old value of dp[j]
                }
            }
            return dp[n - 1];
        }

        // Recursive approach
        // Time complexity: O(2^n) in the worst case, where n is the length of the string.
        // Space complexity: O(n) for the recursion stack.
        public int LongestPalindromeSubseqRecursive(string s)
        {
            int n = s.Length;
            return LongestPalindromeSubseqHelper(s, 0, n - 1);
        }

        public int LongestPalindromeSubseqHelper(string s, int left, int right)
        {
            if (left > right) return 0;
            if (left == right) return 1;
            if (s[left] == s[right])
            {
                return 2 + LongestPalindromeSubseqHelper(s, left + 1, right - 1);
            }
            else
            {
                return Math.Max(LongestPalindromeSubseqHelper(s, left + 1, right), LongestPalindromeSubseqHelper(s, left, right - 1));
            }
        }


    }
}
