using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    internal class L20_ValidParenthesis
    {
        public L20_ValidParenthesis() { }

        //Input: s = "([)]"
        //Output: false

        // Input: s = "()[]{}"
        //Output: true

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> parenthesesMap = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };
            foreach (char c in s)
            {
                if (parenthesesMap.ContainsKey(c))
                {
                    char topElement = stack.Count > 0 ? stack.Pop() : '#';
                    if (topElement != parenthesesMap[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }

        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(n) in the worst case when all characters are opening brackets

    }
}
