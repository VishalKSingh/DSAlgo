using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Hard
{
    internal class L115_DistinctSubsequences
    {
        // This problem is about counting the number of distinct subsequences of a string s that equal another string t
        public int NumDistinct(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[,] dp = new int[m + 1, n + 1]; // Create a dp array to store the number of distinct subsequences up to each index
            for (int i = 0; i <= m; i++)
            {
                dp[i, 0] = 1; // Base case: there is one way to match an empty string t (by deleting all characters from s)
            }
            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = 0; // Base case: there are no ways to match a non-empty string t with an empty string s
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j]; // If the characters match, we can either use this character or skip it
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j]; // If the characters do not match, we can only skip this character in s
                    }
                }
            }
            return dp[m, n]; // The final result is the number of distinct subsequences of s that equal t

        }

        // Recursive approach with memoization
        public int NumDistinctRecursive(string s, string t)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>(); // Create a dictionary to store the results of previously calculated indices
            return NumDistinctHelper(s, t, s.Length, t.Length, memo); // Start the recursive helper function from the end of both strings
        }

        private int NumDistinctHelper(string s, string t, int i, int j, Dictionary<(int, int), int> memo)
        {
            if (j == 0) return 1; // Base case: there is one way to match an empty string t (by deleting all characters from s)
            if (i == 0) return 0; // Base case: there are no ways to match a non-empty string t with an empty string s
            
            if (memo.ContainsKey((i, j))) return memo[(i, j)]; // If the result for this pair of indices has already been calculated, return it from the memo dictionary

            // Check if the current characters of s and t match
            if (s[i - 1] == t[j - 1])
            {
                memo[(i, j)] = NumDistinctHelper(s, t, i - 1, j - 1, memo) + NumDistinctHelper(s, t, i - 1, j, memo); // If the characters match, we can either use this character or skip it
            }
            else
            {
                memo[(i, j)] = NumDistinctHelper(s, t, i - 1, j, memo); // If the characters do not match, we can only skip this character in s
            }
            return memo[(i, j)]; // Return the calculated result for this pair of indices
        }
    }
}
