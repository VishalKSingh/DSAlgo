using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium.BinarySearch
{
    internal class L162_FindPeakElement
    {
        // A peak element is an element that is strictly greater than its neighbors.
        // Given an integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
        //Time Complexity: O(log n)
        //Space Complexity: O(1)
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                // If the middle element is less than its right neighbor, then the peak must be in the right half of the array.
                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }
    }
}
