using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    public static class L796_RotateString
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
    }
}
