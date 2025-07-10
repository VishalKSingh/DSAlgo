using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L136SingleNumber
    {
        // This problem is to find the single number in an array where every other number appears twice.
        // The approach is to use the XOR operation, which has the property that a ^ a = 0 and a ^ 0 = a.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(1) since we are using a constant amount of space

        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result ^= num; // XOR all numbers together
            }
            return result; // The result will be the single number
        }
    }
}
