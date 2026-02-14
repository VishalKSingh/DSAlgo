using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    internal class L28_FindndexoftheFirst_Occurrence
    {
        // This method finds the index of the first occurrence of the substring 'needle' in the string 'haystack'.
        // It uses the built-in string method 'IndexOf' to perform the search.
        // Time Complexity: O(n*m) in the worst case, where n is the length of 'haystack' and m is the length of 'needle'.
        // Space Complexity: O(1) for the variables used, but O(m) for the substring being compared in the worst case.
        public L28_FindndexoftheFirst_Occurrence() { }
        public int StrStr(string haystack, string needle)
        {
            // If 'needle' is an empty string, we return 0 as per the problem statement
            if (string.IsNullOrEmpty(needle)) return 0;
            // Use the built-in 'IndexOf' method to find the first occurrence of 'needle' in 'haystack'
            return haystack.IndexOf(needle);
        }

        public int StrStr2(string haystack, string needle)
        {
            // If 'needle' is an empty string, we return 0 as per the problem statement
            if (string.IsNullOrEmpty(needle)) return 0;
            // Loop through 'haystack' and check for the substring 'needle'
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                // Check if the substring of 'haystack' starting at index 'i' matches 'needle'
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i; // Return the index of the first occurrence
                }
            }
            return -1; // Return -1 if 'needle' is not found in 'haystack'
        }
    }
}
