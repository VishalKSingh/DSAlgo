using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Medium
{
    internal class L394_DecodeString
    {
        public L394_DecodeString() { }
        public L394_DecodeString(string s)
        {
            Console.WriteLine(DecodeString(s));
        }

        public string DecodeString(string s)
        {
            Stack<int> counts = new Stack<int>(); // Stack to keep track of the repeat counts
            Stack<string> strings = new Stack<string>(); // Stack to keep track of the strings built so far
            StringBuilder currentString = new StringBuilder();// StringBuilder to build the current string segment
            int currentNum = 0;

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    currentNum = currentNum * 10 + (c - '0'); // build multi-digit numbers
                }
                else if (c == '[')
                {
                    counts.Push(currentNum);
                    strings.Push(currentString.ToString());
                    currentString.Clear();
                    currentNum = 0;
                }
                else if (c == ']')
                {
                    int repeatCount = counts.Pop();
                    string prevString = strings.Pop();

                    // Build the repeated segment safely (no string ctor expecting a char)
                    string repeated = repeatCount > 0
                        ? string.Concat(Enumerable.Repeat(currentString.ToString(), repeatCount))
                        : string.Empty;

                    currentString.Clear();
                    currentString.Append(prevString);
                    currentString.Append(repeated);
                }
                else
                {
                    currentString.Append(c);
                }
            }

            return currentString.ToString();
        }
    }
}
