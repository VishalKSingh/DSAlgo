using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    internal class L14_LongestCommonPrefix
    {
        // This method finds the longest common prefix string amongst an array of strings.
        // The time complexity is O(n * m) where n is the number of strings and m is the length of the shortest string.
        // The space complexity is O(m) where m is the length of the longest common prefix.
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;
            // Find the minimum length string in the array
            int minLength = strs.Min(s => s.Length);
            StringBuilder prefix = new StringBuilder();
            for (int i = 0; i < minLength; i++)
            {
                char currentChar = strs[0][i];
                // Check if this character is the same in all strings
                if (strs.All(s => s[i] == currentChar))
                {
                    prefix.Append(currentChar);
                }
                else
                {
                    break; // Stop if a mismatch is found
                }
            }
            return prefix.ToString();
        }
    }
}
