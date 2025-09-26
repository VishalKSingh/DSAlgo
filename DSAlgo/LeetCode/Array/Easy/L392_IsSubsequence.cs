using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L392_IsSubsequence
    {
        public L392_IsSubsequence()
        {
        }
        // This problem is to determine if string s is a subsequence of string t.
        // A subsequence is a sequence that can be derived from another sequence by deleting some elements without changing the order of the remaining elements.
        // The approach is to use two pointers, one for each string, and iterate through both strings to check if all characters of s appear in t in the same order.
        // Time Complexity: O(n) where n is the length of string t
        // Space Complexity: O(1) since we are using constant space
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return true;
            if (string.IsNullOrEmpty(t)) return false;
            int sIndex = 0, tIndex = 0;
            while (tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                    if (sIndex == s.Length) return true; // All characters in s have been found in t
                }
                tIndex++;
            }
            return false; // Not all characters in s were found in t
        }
    }
}
