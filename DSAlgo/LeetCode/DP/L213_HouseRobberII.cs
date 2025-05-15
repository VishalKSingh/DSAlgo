﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP
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
        // The idea is to use a bottom-up dynamic programming approach to solve the problem.
        // We maintain two variables, prev1 and prev2, which represent the maximum amount of money we can rob
        // up to the previous house and the house before that, respectively.
        // For each house, we have two choices: either rob it or skip it.
        // If we rob the current house, we add its value to prev2 (the maximum amount we can rob up to the house before the previous one).
        // If we skip it, we take the maximum amount we can rob up to the previous house (prev1).
        // We update prev1 and prev2 accordingly and continue until we reach the last house.
        // The final result is stored in prev1, which represents the maximum amount we can rob from all houses.

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
