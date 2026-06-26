using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L567_PermutationInString
    {
        // Time Complexity: O(n) where n is the length of s2
        // Space Complexity: O(1) since we are using fixed-size arrays for character counts
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;
            int[] s1Count = new int[26]; // Array to count characters in s1
            int[] s2Count = new int[26]; // Array to count characters in the current window of s2

            // Count the characters in s1 and the first window of s2
            for (int i = 0; i < s1.Length; i++)
            {
                s1Count[s1[i] - 'a']++;
                s2Count[s2[i] - 'a']++;
            }

            // Slide the window over s2
            // For each new character added to the window, we remove the leftmost character and add the new character
            for (int i = 0; i < s2.Length - s1.Length; i++)
            {
                // Check if the current window matches the character count of s1
                if (Matches(s1Count, s2Count)) return true;
                // Slide the window: remove the count of the leftmost character and add the count of the new character
                s2Count[s2[i] - 'a']--;
                s2Count[s2[i + s1.Length] - 'a']++;
            }
            return Matches(s1Count, s2Count);
        }

        // Helper function to check if two character count arrays match
        private bool Matches(int[] s1Count, int[] s2Count)
        {
            for (int i = 0; i < 26; i++)
            {
                if (s1Count[i] != s2Count[i]) return false;
            }
            return true;
        }
    }
}
