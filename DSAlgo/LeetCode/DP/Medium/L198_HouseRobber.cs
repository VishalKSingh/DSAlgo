using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    public class L198_HouseRobber
    {
        // This is a dynamic programming problem where we want to maximize the amount of money we can rob from houses arranged in a line,
        // given that we cannot rob two adjacent houses.
        // The idea is to use a bottom-up approach to build up the solution iteratively.
        // We maintain two variables, prev1 and prev2, which represent the maximum amount of money we can rob up to the previous house and the house
        // before that, respectively.
        // For each house, we have two choices: either rob it or skip it.
        // If we rob the current house, we add its value to prev2.
        // If we skip it, we take the maximum amount we can rob up to the previous house (prev1).
        // We update prev1 and prev2 accordingly and continue until we reach the last house.
        // The final result is stored in prev1, which represents the maximum amount we can rob from all houses.
        // Time Complexity: O(n) where n is the number of houses
        // Space Complexity: O(1) since we are using only a constant amount of space
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int prevHouse = 0; // Maximum amount we can rob up to the previous house
            int houseBeforePrev = 0; // Maximum amount we can rob up to the house before the previous one

            foreach (var house in nums)
            {
                int temp = prevHouse;
                prevHouse = Math.Max(houseBeforePrev + house, prevHouse);
                houseBeforePrev = temp;
            }

            return prevHouse;
        }

        // This is a recursive approach with memoization
        // The function takes an array of house values and an index representing the current house.
        // It uses a dictionary to store the results of previously calculated houses to avoid redundant calculations.
        // The function checks if the current house is the last one or if it has already been calculated.
        // If not, it calculates the maximum amount we can rob by either robbing the current house and skipping the next one,
        // or skipping the current house and robbing the next one.
        // The final result is stored in the dictionary and returned.
        // Time Complexity: O(n) where n is the number of houses
        // Space Complexity: O(n) for the memoization dictionary
        public int RobRecursive(int[] nums)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return RobHelper(nums, 0, memo);
        }
        private int RobHelper(int[] nums, int index, Dictionary<int, int> memo)
        {
            if (index >= nums.Length) return 0;
            if (memo.ContainsKey(index)) return memo[index];

            // Calculate the maximum amount we can rob by either robbing the current house or skipping it
            int rob = nums[index] + RobHelper(nums, index + 2, memo);
            int skip = RobHelper(nums, index + 1, memo);

            // Store the result in the memo dictionary
            memo[index] = Math.Max(rob, skip);
            return memo[index];
        }

        // This is a recursive approach without memoization
        // The function takes an array of house values and an index representing the current house.
        // It checks if the current house is the last one.
        // If not, it calculates the maximum amount we can rob by either robbing the current house and skipping the next one,
        // or skipping the current house and robbing the next one.
        // Time Complexity: O(2^n) where n is the number of houses
        // Space Complexity: O(n) for the recursion stack
        public int RobRecursiveNoMemo(int[] nums)
        {
            return RobHelperNoMemo(nums, 0);

        }
        private int RobHelperNoMemo(int[] nums, int index)
        {
            // Base case: if we have gone through all the houses, return 0
            if (index >= nums.Length) return 0;

            // Calculate the maximum amount we can rob by either robbing the current house or skipping it
            int rob = nums[index] + RobHelperNoMemo(nums, index + 2);
            int skip = RobHelperNoMemo(nums, index + 1);

            return Math.Max(rob, skip);
        }

        // This is a tabulation approach using bottom-up approach.
        // It uses an array to store the maximum amount we can rob up to each house.
        // The first two houses are initialized with their respective values.
        // For each subsequent house, we calculate the maximum amount we can rob by either robbing the current house and adding it to the maximum amount we can rob up to the house before the previous one,
        // or skipping the current house and taking the maximum amount we can rob up to the previous house.
        // The final result is stored in the last element of the array.
        // Time Complexity: O(n) where n is the number of houses
        // Space Complexity: O(n) for the dp array
        public int RobTabulation(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int n = nums.Length;
            int[] dp = new int[n]; // dp[i] represents the maximum amount we can rob up to house i
            dp[0] = nums[0]; // Initialize the first house
            dp[1] = Math.Max(nums[0], nums[1]);

            // Iterate through the houses and calculate the maximum amount we can rob
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }

            return dp[n - 1];
        }
    }
}
