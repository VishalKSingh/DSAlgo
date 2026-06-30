using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L678_ValidParenthesisString
    {
        public bool CheckValidString(string s)
        {
            int low = 0, high = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    low++;
                    high++;
                }
                else if (c == ')')
                {
                    low--;
                    high--;
                }
                else // c == '*'
                {
                    low--; // Treat '*' as ')'
                    high++; // Treat '*' as '('
                }
                if (high < 0) return false; // Too many ')'
                low = Math.Max(low, 0); // Ensure low doesn't go below 0
            }
            return low == 0; // Valid if all '(' are matched
        }
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(1) since we are using only a few integer variables
    }
}
