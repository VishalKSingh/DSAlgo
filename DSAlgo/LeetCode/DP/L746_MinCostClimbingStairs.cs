using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP
{
    public class L746_MinCostClimbingStairs
    {
        // You are given an integer array cost where cost[i] is the cost of ith step on a staircase.
        // You want to climb to the top of the staircase and you can either start from step 0 or step 1.
        // In each step, you can either climb one or two steps. You need to pay the cost of the step you are on.
        // Return the minimum cost to reach the top of the floor.

        // Example 1:
        // Input: cost = [10,15,20]
        // Output: 15
        // Explanation: Cheapest is start on cost[1], pay that cost and go to the top.
        // Example 2:
        // Input: cost = [1,100,1]
        // Output: 1
        // Explanation: Cheapest is start on cost[0], and pay that cost, and go to the top.


        // Dynamic Programming approach
        // Time Complexity: O(n)
        // Space Complexity: O(n)
        // This method calculates the minimum cost to reach the top of the staircase
        // using a bottom-up dynamic programming approach.
        // It uses an array to store the minimum cost to reach each step,
        // and iteratively calculates the minimum cost to reach the current step
        // by considering the cost of the last two steps.
        // The result is stored in the last element of the array.
        // The minimum cost to reach the top of the staircase is the minimum of the last two steps.
        // The result is stored in the last element of the array.
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n + 1]; // dp[i] represents the minimum cost to reach step i
            dp[0] = 0; // No cost to reach step 0
            dp[1] = 0; // No cost to reach step 1

            for (int i = 2; i <= n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            return dp[n];
        }
        public int MinCostClimbingStairsOptimized(int[] cost)
        {
            int n = cost.Length;
            int prev1 = 0, prev2 = 0;

            for (int i = 2; i <= n; i++)
            {
                int current = Math.Min(prev1 + cost[i - 1], prev2 + cost[i - 2]);
                prev2 = prev1;
                prev1 = current;
            }

            return prev1;
        }
    }
}
