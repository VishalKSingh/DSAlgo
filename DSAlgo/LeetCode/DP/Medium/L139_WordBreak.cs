using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L139_WordBreak
    {
        public L139_WordBreak() { }

        // This method checks if the input string can be segmented into a space-separated sequence of one or more dictionary words.
        // It uses a dynamic programming approach where we create a boolean array dp of size n+1, where n is the length of the input string.
        // The dp[i] represents whether the substring s[0..i-1] can be segmented into valid words from the dictionary.
        // We initialize dp[0] to true, indicating that an empty string can be segmented.
        // We then iterate through the string and for each position i, we check all previous positions j (from 0 to i-1).
        // If dp[j] is true and the substring s[j..i-1] is in the word dictionary, we set dp[i] to true and break out of the inner loop.
        // Finally, we return dp[n], which indicates whether the entire string can be segmented.
        public bool WordBreak(string s, IList<string> wordDict)
        {
            int n = s.Length;
            bool[] dp = new bool[n + 1];
            dp[0] = true; // Base case: empty string can be segmented
            
            for (int i = 1; i <= n; i++)
            {
                // Check all previous positions to see if we can segment the string up to position i
                for (int j = 0; j < i; j++)
                {
                    
                    if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break; // No need to check further if we found a valid segmentation
                    }
                }
            }
            return dp[n];
        }

        // This is a recursive approach with memoization to solve the Word Break problem.
        // The function takes an input string and a list of words as the dictionary.
        // It uses a dictionary to store the results of previously calculated substrings to avoid redundant calculations.
        // The function checks if the current substring is empty, in which case it returns true.
        // It then iterates through the list of words in the dictionary and checks if the current substring starts with any of the words.
        // If it does, it recursively calls itself with the remaining substring after removing the matched word.
        // If any of the recursive calls return true, it means the current substring can be segmented, and we store this result in the memoization dictionary before returning true.
        // If none of the words match or if all recursive calls return false, we store the result as false in the memoization dictionary and return false.
        public bool WordBreakRecursive(string s, IList<string> wordDict)
        {
            Dictionary<string, bool> memo = new Dictionary<string, bool>();
            return WordBreakHelper(s, wordDict, memo);
        }

        private bool WordBreakHelper(string s, IList<string> wordDict, Dictionary<string, bool> memo)
        {
            if (s.Length == 0) return true; // Base case: empty string can be segmented
            if (memo.ContainsKey(s)) return memo[s]; // Check if result is already computed
            foreach (var word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    string remaining = s.Substring(word.Length);
                    if (WordBreakHelper(remaining, wordDict, memo))
                    {
                        memo[s] = true; // Store the result in the memoization dictionary
                        return true;
                    }
                }
            }
            memo[s] = false; // Store the result as false if no valid segmentation is found
            return false;
        }
    }
}
