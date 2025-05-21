using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L153_FindMinimumInRotatedsortedArray
    {
        // This problem is about finding the minimum element in a rotated sorted array
        // The array is sorted in ascending order and then rotated at some pivot
        // The minimum element is the point where the rotation occurs
        // The binary search approach is used to find the minimum element in logarithmic time
        // Time Complexity: O(log n) where n is the number of elements in the array
        // Space Complexity: O(1) as we are using only a few variables
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                // Check if mid is greater than right, which means the minimum is in the right half
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return nums[left];
        }
    }
}
