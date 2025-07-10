using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L189_RotateArray
    {
        // This problem is about rotating an array to the right by k steps
        // The function should modify the array in-place
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are modifying the array in place

        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n; // Handle cases where k is greater than n

            Reverse(nums, 0, n - 1); // Reverse the entire array
            Reverse(nums, 0, k - 1); // Reverse the first k elements
            Reverse(nums, k, n - 1); // Reverse the remaining n-k elements
        }

        // This helper function reverses a portion of the array from start to end indices
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}
