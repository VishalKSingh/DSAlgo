using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L75_SortColors
    {
        // This problem is to sort an array containing 0s, 1s, and 2s in a single pass.
        // The approach is to use the Dutch National Flag algorithm.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(1) since we are sorting in place

        public void SortColors(int[] nums)
        {
            // The Dutch National Flag algorithm uses three pointers:
            // low: points to the next position for 0
            // mid: current element being processed
            // high: points to the next position for 2

            int low = 0, mid = 0, high = nums.Length - 1;

            // Process elements until mid pointer exceeds high pointer
            while (mid <= high)
            {
                // If the current element is 0, swap it with the element at low pointer
                if (nums[mid] == 0)
                {
                    Swap(nums, low, mid);
                    low++;
                    mid++;
                }
                else if (nums[mid] == 1) // If the current element is 1, just move the mid pointer
                {
                    mid++;
                }
                else
                {
                    Swap(nums, mid, high); // If the current element is 2, swap it with the element at high pointer
                    high--;
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

    }
}
