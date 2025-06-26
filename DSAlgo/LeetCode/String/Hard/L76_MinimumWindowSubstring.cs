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

            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            int required = charCount.Count;
            int left = 0, right = 0, formed = 0;
            Dictionary<char, int> windowCounts = new Dictionary<char, int>();
            int minLength = int.MaxValue;
            int minLeft = 0;

            while (right < s.Length)
            {
                char c = s[right];
                if (windowCounts.ContainsKey(c))
                    windowCounts[c]++;
                else
                    windowCounts[c] = 1;

                if (charCount.ContainsKey(c) && windowCounts[c] == charCount[c])
                    formed++;

                while (left <= right && formed == required)
                {
                    c = s[left];
                    if (right - left + 1 < minLength)
                    {
                        minLength = right - left + 1;
                        minLeft = left;
                    }

                    windowCounts[c]--;
                    if (charCount.ContainsKey(c) && windowCounts[c] < charCount[c])
                        formed--;

                    left++;
                }
                right++;
            }

            return minLength == int.MaxValue ? "" : s.Substring(minLeft, minLength);
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
