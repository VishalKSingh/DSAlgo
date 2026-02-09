using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Medium
{
    internal class L503_NextGreaterElementII
    {
        public L503_NextGreaterElementII() { }
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 2 * n - 1; i >= 0; i--)
            {
                int currentNum = nums[i % n];
                while (stack.Count > 0 && stack.Peek() <= currentNum)
                {
                    stack.Pop();
                }
                result[i % n] = stack.Count > 0 ? stack.Peek() : -1;
                stack.Push(currentNum);
            }
            return result;
        }
    }
}
