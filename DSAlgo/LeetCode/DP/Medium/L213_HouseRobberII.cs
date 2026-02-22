using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    public class L213_HouseRobberII
    {
        // This is a variation of the House Robber problem where the houses are arranged in a circle.
        // The solution involves two cases:
        // 1. Rob houses from 0 to n-2 (excluding the last house)
        // 2. Rob houses from 1 to n-1 (excluding the first house)
        // The final result is the maximum of the two cases.
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // This method calculates the maximum amount of money we can rob from the houses
        // arranged in a circle, given that we cannot rob two adjacent houses.

        public int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            return Math.Max(RobHelper(nums, 0, nums.Length - 2), RobHelper(nums, 1, nums.Length - 1));
        }

        private int RobHelper(int[] nums, int start, int end)
        {
            int prev = 0;
            int curr = 0;

            for (int i = start; i <= end; i++)
            {
                int temp = curr;
                curr = Math.Max(prev + nums[i], curr);
                prev = temp;
            }

            return curr;
        }
    }
}
