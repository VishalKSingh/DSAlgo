using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    internal class L496_NextGreaterElement
    {
        public L496_NextGreaterElement() { }
        // The Next Greater Element problem can be solved using a stack to keep track of the elements for which we haven't found
        // the next greater element yet. We can traverse the second array (nums2) from right to left, and for each element,
        // we pop elements from the stack until we find a greater element or the stack is empty.
        // We can store the next greater element in a dictionary for quick lookup when we process the first array (nums1).
        // Time Complexity: O(n + m), where n is the length of nums1 and m is the length of nums2. We traverse nums2 once and nums1 once.
        // Space Complexity: O(m), where m is the length of nums2, due to the stack and the dictionary used to store the next greater elements.
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> nextGreaterMap = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            // Traverse nums2 from right to left
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                int currentNum = nums2[i];
                // Pop elements from the stack until we find a greater element
                while (stack.Count > 0 && stack.Peek() <= currentNum)
                {
                    stack.Pop();
                }
                // If the stack is empty, there is no greater element
                nextGreaterMap[currentNum] = stack.Count > 0 ? stack.Peek() : -1;
                // Push the current number onto the stack
                stack.Push(currentNum);
            }
            // Prepare the result for nums1 based on the next greater map
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = nextGreaterMap[nums1[i]];
            }
            return result;
        }
    }
}
