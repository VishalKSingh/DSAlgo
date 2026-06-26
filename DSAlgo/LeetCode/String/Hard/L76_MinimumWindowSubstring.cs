using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Hard
{
    internal class L76_MinimumWindowSubstring
    {
        // This problem is to find the minimum window substring in a given string that contains all characters of another string.
        // The approach is to use a sliding window technique with two pointers and a hash map to keep track of character counts.
        // Time Complexity: O(n + m) where n is the length of the input string and m is the length of the target string
        // Space Complexity: O(m) for the hash map

        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

            Dictionary<char, int> charCount_t = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (charCount_t.ContainsKey(c))
                    charCount_t[c]++;
                else
                    charCount_t[c] = 1;
            }

            int required = charCount_t.Count; // Number of unique characters in t that need to be present in the window
            int left = 0, formed = 0; // formed is the number of unique characters in the current window that match the required count in t
            Dictionary<char, int> charCounts = new Dictionary<char, int>(); // To keep track of character counts in the current window
            int minLength = int.MaxValue;
            int startIndexOfMinWindow = 0;// To store the starting index of the minimum window

            // Expand the window by moving the right pointer
            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                if (charCounts.ContainsKey(c))
                    charCounts[c]++;
                else
                    charCounts[c] = 1;
                // If the current character's count matches the required count in t, we increment the formed count
                if (charCount_t.ContainsKey(c) && charCounts[c] == charCount_t[c])
                    formed++;

                // Try to contract the window until it ceases to be 'desirable'
                // When we have a valid window, we try to minimize it by moving the left pointer
                // While the current window has all the required characters, we try to shrink it from the left
                 while (left <= right && formed == required)
                {
                    c = s[left];
                    if (right - left + 1 < minLength)
                    {
                        minLength = right - left + 1;
                        startIndexOfMinWindow = left;
                    }

                    charCounts[c]--; // Decrease the count of the character at the left pointer
                    // If the character at the left pointer is part of t and its count in the current window is now less than required, we decrement formed
                    if (charCount_t.ContainsKey(c) && charCounts[c] < charCount_t[c])
                        formed--;

                    left++;
                }
            }

            return minLength == int.MaxValue ? "" : s.Substring(startIndexOfMinWindow, minLength);
        }

        // Brute force solution:
        // This solution checks all possible substrings and counts the characters to find the minimum window.
        // Time Complexity: O(n^2 * m) where n is the length of the input string and m is the length of the target string
        // Space Complexity: O(m) for the hash map

        public string MinWindowBruteForce(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

            int minLength = int.MaxValue; // the minimum length of the substring found
            string result = "";

            // Iterate through all possible substrings of s
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                    string substring = s.Substring(i, j - i);

                    // Check if the substring contains all characters of t
                    if (ContainsAllChars(substring, t) && substring.Length < minLength)
                    {
                        minLength = substring.Length;
                        result = substring;
                    }
                }
            }

            return result;
        }
        private bool ContainsAllChars(string substring, string t)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            // Count characters in t
            foreach (char c in t)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            // Remove characters from the count based on the substring
            foreach (char c in substring)
            {
                // If the character is in the count, decrement its count
                if (charCount.ContainsKey(c))
                {
                    charCount[c]--;
                    // If the count reaches zero, remove it from the dictionary
                    if (charCount[c] == 0)
                        charCount.Remove(c);
                }
            }

            return charCount.Count == 0;
        }
    }
}
