using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L31_NextPermutation
    {
        // This problem is to find the next lexicographical permutation of a given array of integers.
        // The approach is to find the rightmost pair of consecutive elements where the left element is smaller than the right one,
        // then swap it with the smallest element on its right side that is larger than it, and finally reverse the elements to the right of that position.
        // Time Complexity: O(n) where n is the number of elements in the input array
        // Space Complexity: O(1) since we are modifying the array in place
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2;
            // Step 1: Find the first decreasing element from the end
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                // Step 2: Find the element just larger than nums[i] to swap with
                int j = n - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                // Swap elements at i and j
                Swap(nums, i, j);
            }
            // Step 3: Reverse the elements to the right of index i
            Reverse(nums, i + 1, n - 1);
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                Swap(nums, start, end);
                start++;
                end--;
            }
        }
    }
}
