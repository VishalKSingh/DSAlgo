using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L209_MinimumSizeSubarraySum
    {
        // This problem is to find the minimum length of a contiguous subarray of which the sum is at least target.
        // The approach is to use a sliding window technique to find the minimum length.

        // The sliding window technique is used to maintain a window of elements that satisfies the condition of the sum being at least target.
        // The left pointer is used to shrink the window when the sum is greater than or equal to target.
        // The right pointer is used to expand the window by adding elements to the sum.
        // The minimum length is updated whenever a valid subarray is found.
        // The final result is returned as the minimum length of the subarray that satisfies the condition.
        // The sliding window technique is a common approach to solve problems involving subarrays or substrings with certain conditions.

        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1) since we are using constant space


        //target = 7, nums = [2,3,1,2,4,3]
        public int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0, sum = 0, minLength = int.MaxValue;

            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];

                while (sum >= target)
                {
                    minLength = Math.Min(minLength, right - left + 1);
                    sum -= nums[left++];
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }

        // Brute force solution:
        // This solution checks all possible subarrays and calculates their sums to find the minimum length.
        // Time Complexity: O(n^2) where n is the number of elements in the array
        // Space Complexity: O(1) since we are using constant space

        public int MinSubArrayLenBruteForce(int target, int[] nums)
        {
            int minLength = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum >= target)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        break; // No need to check further as we found a valid subarray
                    }
                }
            }
            return minLength == int.MaxValue ? 0 : minLength;
        }

    }
}
