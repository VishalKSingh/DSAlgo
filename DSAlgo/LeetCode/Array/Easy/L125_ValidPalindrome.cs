using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L125_ValidPalindrome
    {
        // This problem is to determine if a given string is a palindrome, considering only alphanumeric characters and ignoring cases.
        // The approach is to use two pointers, one starting from the beginning and the other from the end of the string, and move towards the center while comparing characters.
        // Time Complexity: O(n) where n is the length of the string
        // Space Complexity: O(1) since we are using constant space
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }
        // Alternative approach using LINQ to filter and check for palindrome
        // Time Complexity: O(n) where n is the length of the string
        // Space Complexity: O(n) for the filtered character array
        public bool IsPalindromeLinq(string s)
        {
            var filteredChars = s.Where(c => char.IsLetterOrDigit(c)).Select(c => char.ToLower(c)).ToArray();
            return filteredChars.SequenceEqual(filteredChars.Reverse());
        }

    }
}
