using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L33_SearchInRotatedSortedArray
    {
        // This problem is about searching for a target value in a rotated sorted array
        // The array is sorted in ascending order and then rotated at some pivot
        // The binary search approach is used to find the target value in logarithmic time
        // Time Complexity: O(log n) where n is the number of elements in the array
        // Space Complexity: O(1) as we are using only a few variables
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                // Check if the left half is sorted
                if (nums[left] <= nums[mid])
                {
                    // Left half is sorted
                    // Check if the target is in the left half
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else // Right half is sorted
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1; // Target not found
        }
    }
}
