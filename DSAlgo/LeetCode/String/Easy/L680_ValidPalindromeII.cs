using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    internal class L680_ValidPalindromeII
    {
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(1) since we are using only a few integer variables
        public bool ValidPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    // If characters don't match, check by skipping either left or right character
                    return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
                }
                left++;
                right--;
            }
            return true; // The string is a palindrome
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
