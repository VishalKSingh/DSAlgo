using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L686_RepeatedStringMatch
    {
        // Time Complexity: O(n * m), where n is the length of string a and m is the length of string b.
        // Space Complexity: O(n), where n is the length of string a.
        public int RepeatedStringMatch(string a, string b)
        {
            int count = 1;
            // Create a StringBuilder to build the repeated string
            StringBuilder sb = new StringBuilder(a);
            // Keep appending 'a' to the StringBuilder until its length is at least the length of 'b'
            while (sb.Length < b.Length)
            {
                sb.Append(a);
                count++;
            }
            // Check if the current repeated string contains 'b'
            if (sb.ToString().Contains(b))
                return count;
            sb.Append(a); // Append 'a' one more time to check for overlap cases
            if (sb.ToString().Contains(b))
                return count + 1;
            return -1;
        }
    }
}
