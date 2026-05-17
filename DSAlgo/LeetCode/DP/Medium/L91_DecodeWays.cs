using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L91_DecodeWays
    {
        // This problem is about counting the number of ways to decode a string of digits where 'A' = 1, 'B' = 2, ..., 'Z' = 26
        // The function takes a string of digits and returns the number of ways to decode it.

        // Dynamic Programming approach
         public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0; // If the string is empty or starts with '0', there are no valid decodings
            int n = s.Length;
            int[] dp = new int[n + 1]; // Create a dp array to store the number of decodings up to each index
            dp[0] = 1; // Base case: there is one way to decode an empty string
            dp[1] = 1; // Base case: there is one way to decode a single digit (if it's not '0')
            for (int i = 2; i <= n; i++)
            {
                // Check if the current digit forms a valid single digit decoding
                if (s[i - 1] != '0')
                {
                    dp[i] += dp[i - 1]; // If valid, add the number of decodings up to the previous index
                }
                // Check if the last two digits form a valid two-digit decoding
                int twoDigit = int.Parse(s.Substring(i - 2, 2)); // Get the last two digits as an integer
                if (twoDigit >= 10 && twoDigit <= 26)
                {
                    dp[i] += dp[i - 2]; // If valid, add the number of decodings up to the index before the last two digits
                }
            }
            return dp[n]; // The final result is the number of decodings for the entire string
        }

        // Recursive approach with memoization
        public int NumDecodingsRecursive(string s)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>(); // Create a dictionary to store the results of previously calculated indices
            return NumDecodingsHelper(s, 0, memo); // Start the recursive helper function from the first index
        }

        private int NumDecodingsHelper(string s, int index, Dictionary<int, int> memo)
        {
            if (index >= s.Length) return 1; // Base case: if we have reached the end of the string, there is one valid decoding
            if (s[index] == '0') return 0; // If the current digit is '0', there are no valid decodings
            
            if (memo.ContainsKey(index)) return memo[index]; // If the result for this index has already been calculated, return it from the memo dictionary
            
            int count = NumDecodingsHelper(s, index + 1, memo); // Calculate the number of decodings by considering the current digit as a single digit

            // Check if the current and next digits form a valid two-digit decoding
            if (index + 1 < s.Length)
            {
                int twoDigit = int.Parse(s.Substring(index, 2)); // Get the current and next digits as an integer
                if (twoDigit >= 10 && twoDigit <= 26)
                {
                    count += NumDecodingsHelper(s, index + 2, memo); // If valid, add the number of decodings by considering the current and next digits as a two-digit number
                }
            }
            memo[index] = count; // Store the result in the memo dictionary before returning
            return count; // Return the total count of decodings for this index
        }

    }
}
