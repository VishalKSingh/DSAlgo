using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    internal class L58_LengthOfLastWord
    {
        // This problem is to find the length of the last word in a given string.
        // The approach is to split the string by spaces and return the length of the last word.
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(1) since we are not using any additional data structures

        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            var words = s.Trim().Split(' ');
            return words.Length > 0 ? words.Last().Length : 0;
        }
    }
}
