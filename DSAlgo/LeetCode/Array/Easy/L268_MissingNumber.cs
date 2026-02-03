using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L268_MissingNumber
    {
        // This problem is to find the missing number in an array containing n distinct numbers taken from 0 to n.
        // The approach is to use the formula for the sum of the first n natural numbers and subtract the sum of the array elements.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(1) since we are using a constant amount of space

        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2; // Sum of first n natural numbers
            int actualSum = nums.Sum(); // Sum of elements in the array
            return expectedSum - actualSum; // The difference is the missing number
        }
    }
}
