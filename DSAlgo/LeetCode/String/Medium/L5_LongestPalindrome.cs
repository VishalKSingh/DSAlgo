using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L5_LongestPalindrome
    {
        public L5_LongestPalindrome() { }

        // This method finds the longest palindromic substring in the given string s.
        // It uses the "expand around center" technique, which checks for palindromes
        // by expanding outwards from each character (and between characters for even-length palindromes).
        // Time Complexity: O(n^2) in the worst case, where n is the length of the string.
        // Space Complexity: O(1) for the variables used, but O(n) for the output string in the worst case.
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            int start = 0, maxLength = 1;
            for (int i = 0; i < s.Length; i++)
            {
                // Odd length palindromes
                ExpandAroundCenter(s, i, i, ref start, ref maxLength);
                // Even length palindromes
                ExpandAroundCenter(s, i, i + 1, ref start, ref maxLength);
            }
            return s.Substring(start, maxLength);
        }
        private void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxLength)
        {
            // Expand as long as the characters at left and right are the same and within bounds
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            // After the loop, left and right are one step beyond the palindrome boundaries, so we calculate the length of the palindrome
            int length = right - left - 1;
            // Update the start index and max length if a longer palindrome is found
            if (length > maxLength)
            {
                start = left + 1;
                maxLength = length;
            }
        }
    }
}
