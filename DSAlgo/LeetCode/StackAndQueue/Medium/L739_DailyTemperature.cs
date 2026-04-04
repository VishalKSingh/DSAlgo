using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Medium
{
    internal class L739_DailyTemperature
    {
        public L739_DailyTemperature() { }
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            // We traverse the array from right to left, and for each temperature, we pop elements from the stack until we find a warmer temperature or the stack is empty.
            // We store the number of days until a warmer temperature in the result array.
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count > 0 ? stack.Peek() - i : 0; // Calculate the number of days until a warmer temperature
                stack.Push(i); // Push the current index onto the stack
            }
            return result;
        }
    }
}
