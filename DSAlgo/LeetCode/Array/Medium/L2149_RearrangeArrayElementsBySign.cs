using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L2149_RearrangeArrayElementsBySign
    {
        // This problem is to rearrange the elements of an array such that positive and negative numbers alternate.
        // The first element should be positive, and the second should be negative, and so on.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(n) for storing the result

        public int[] RearrangeArray(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int posIndex = 0, negIndex = 1;

            foreach (int num in nums)
            {
                if (num > 0)
                {
                    result[posIndex] = num;
                    posIndex += 2; // Move to the next position for positive numbers
                }
                else
                {
                    result[negIndex] = num;
                    negIndex += 2; // Move to the next position for negative numbers
                }
            }

            return result;
        }
    }
}
