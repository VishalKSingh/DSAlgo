using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L22_GenerateParentheses
    {
        // The time complexity is O(4^n / sqrt(n)) because we are generating all possible combinations of parentheses, which is a Catalan number.
        // The space complexity is O(n) because we are using a recursion stack that can go up to n levels deep.
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            GenerateParenthesisHelper(result, "", 0, 0, n);
            return result;
        }

        private void GenerateParenthesisHelper(List<string> result, string current, int open, int close, int max)
        {
            // If the current string has reached the maximum length, add it to the result list
            if (current.Length == max * 2)
            {
                result.Add(current);
                return;
            }
            // If the number of open parentheses is less than the maximum, add an open parenthesis and recurse
            if (open < max)
            {
                GenerateParenthesisHelper(result, current + "(", open + 1, close, max);
            }
            // If the number of close parentheses is less than the number of open parentheses, add a close parenthesis and recurse
            if (close < open)
            {
                GenerateParenthesisHelper(result, current + ")", open, close + 1, max);
            }
        }

        // optimized version using StringBuilder
        // time complexity: O(4^n / sqrt(n)), space complexity: O(n)
        // Space complexity is O(n) because we are using a StringBuilder to build the current string, which can have a maximum length of 2n. The recursion stack can also go up to n levels deep, but since we are using a StringBuilder, we are not creating new strings at each level of recursion, which saves space.
        public IList<string> GenerateParenthesisOptimized(int n)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            GenerateParenthesisHelperOptimized(result, current, 0, 0, n);
            return result;
        }

        private void GenerateParenthesisHelperOptimized(List<string> result, StringBuilder current, int open, int close, int max)
        {
            if (current.Length == max * 2)
            {
                result.Add(current.ToString());
                return;
            }
            // If the number of open parentheses is less than the maximum, add an open parenthesis and recurse
            if (open < max)
            {
                current.Append('(');
                GenerateParenthesisHelperOptimized(result, current, open + 1, close, max);
                current.Length--; // Backtrack
            }
            // If the number of close parentheses is less than the number of open parentheses, add a close parenthesis and recurse
            if (close < open)
            {
                current.Append(')');
                GenerateParenthesisHelperOptimized(result, current, open, close + 1, max);
                current.Length--; // Backtrack
            }
        }
    }
}
