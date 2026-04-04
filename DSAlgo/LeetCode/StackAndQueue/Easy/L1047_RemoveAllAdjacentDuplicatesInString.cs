using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    internal class L1047_RemoveAllAdjacentDuplicatesInString
    {
        public L1047_RemoveAllAdjacentDuplicatesInString() { }
        public string RemoveDuplicates(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop(); // Remove the duplicate character
                }
                else
                {
                    stack.Push(c); // Add the current character to the stack
                }
            }
            // Build the resulting string from the characters in the stack
            StringBuilder result = new StringBuilder();
            foreach (char c in stack.Reverse())
            {
                result.Append(c);
            }
            return result.ToString();
        }
    }
}
