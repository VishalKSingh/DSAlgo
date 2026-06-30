using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L32_LongestValidParentheses
    {
        // This method finds the length of the longest valid (well-formed) parentheses substring.
        // The time complexity is O(n) where n is the length of the input string.
        // The space complexity is O(n) due to the stack used to store indices of characters.
        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int maxLength = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1); // Base for valid substring
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);// Push the index of '(' onto the stack
                }
                else
                {
                    stack.Pop();// Pop the last index from the stack
                    // If the stack is empty, push the current index as a base for the next valid substring
                    if (stack.Count == 0)
                    {
                        stack.Push(i); // Update base for next valid substring
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek()); // Calculate the length of the current valid substring
                    }
                }
            }
            return maxLength;
        }

        // This method finds the length of the longest valid (well-formed) parentheses substring using a two-pass approach.
        // The time complexity is O(n) where n is the length of the input string.
        // The space complexity is O(1) as we are using only a few integer variables.
        public int LongestValidParenthesesTwoPass(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int open = 0, close = 0, maxLength = 0;
            // First pass: left to right
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;
                if (open == close)
                    maxLength = Math.Max(maxLength, 2 * close);
                else if (close > open)
                    open = close = 0; // Reset counters when more ')' than '('
            }
            open = close = 0;
            // Second pass: right to left
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;
                if (open == close)
                    maxLength = Math.Max(maxLength, 2 * close);
                else if (open > close)
                    open  = close = 0; // Reset counters when more '(' than ')'
            }
            return maxLength;
        }
    }
}
