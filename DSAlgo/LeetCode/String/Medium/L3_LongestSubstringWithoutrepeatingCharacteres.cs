using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L3_LongestSubstringWithoutrepeatingCharacteres
    {
        // Brute force solution
        // This approach uses a nested loop to check all possible substrings and track the longest one without repeating characters.
        // Time Complexity: O(n^2) where n is the length of the input string
        // Space Complexity: O(min(n, m)) where m is the size of the character set

        public int LengthOfLongestSubstringBruteForce(string s)
        {
            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var charSet = new HashSet<char>(); // Initialize a hash set to track characters in the current substring
                for (int j = i; j < s.Length; j++)
                {
                    if (charSet.Contains(s[j]))
                    {
                        break;
                    }
                    charSet.Add(s[j]);
                    maxLength = Math.Max(maxLength, j - i + 1);
                }
            }

            return maxLength;
        }

        // This problem is to find the length of the longest substring without repeating characters.
        // The approach is to use a sliding window technique with a hash set to track characters in the current substring.
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(min(n, m)) where m is the size of the character set

        public int LengthOfLongestSubstring(string s)
        {
            var charSet = new HashSet<char>();
            int left = 0, maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left]);
                    left++;
                }
                charSet.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}
