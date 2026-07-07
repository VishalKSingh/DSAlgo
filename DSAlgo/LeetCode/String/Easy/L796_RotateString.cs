using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    public class L796_RotateString
    {

        // This problem is about determining if one string can be rotated to form another string
        // A string A can be rotated to form string B if B is a substring of A concatenated with itself (A + A)
        // Time Complexity: O(N) where N is the length of the strings, since we need to check if B is a substring of A + A
        // Space Complexity: O(N) for the concatenated string A + A
        public static bool RotateString(string A, string B)
        {
            if (A.Length != B.Length) return false; // If lengths are different, they cannot be rotations
            string concatenated = A + A; // Concatenate A with itself
            return concatenated.Contains(B); // Check if B is a substring of the concatenated string
        }

        // Alternative approach using left shift
        // Time Complexity: O(N^2) in the worst case, where N is the length of the strings, since we may need to perform N left shifts and each shift takes O(N) time
        public bool RotateString2(string s, string goal)
        {
            foreach (char c in s)
            {
                if (s == goal)
                {
                    return true;
                }
                s = LeftShift(s);
            }
            return false;
        }

        private string LeftShift(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            return s.Substring(1) + s[0];
        }

        public bool RotateStringOptimized(string s, string goal)
        {
            if (s.Length != goal.Length) return false;
            if (s == goal) return true;

            // Try alignment at every possible starting index of s
            for (int i = 0; i < s.Length; i++)
            {
                int j = 0;
                // Check if goal matches s starting from index i
                while (j < goal.Length && s[(i + j) % s.Length] == goal[j])
                {
                    j++;
                }
                // If we successfully matched the entire length of goal
                if (j == goal.Length) return true;
            }

            return false;
        }

    }
}
