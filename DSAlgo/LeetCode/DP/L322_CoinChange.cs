using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP
{
    public class L322_CoinChange
    {
        /// https://leetcode.com/problems/coin-change/
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1]; // dp[i] will be storing the minimum number of coins needed to make amount i
            Array.Fill(dp, amount + 1); // Initialize all dp values to a large number (amount + 1)
            dp[0] = 0; // Base case: 0 coins are needed to make amount 0

            // Iterate through all amounts from 1 to amount and for each amount, iterate through all coins
            // to find the minimum number of coins needed

            for (int i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    // If the coin is less than or equal to the current amount
                    if (i - coin >= 0)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1); // Update dp[i] with the minimum number of coins needed
                    }
                }
            }
            // If dp[amount] is still amount + 1, it means we cannot make that amount with the given coins
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }
        /// Time Complexity: O(n * m) where n is the amount and m is the number of coins
        /// Space Complexity: O(n) for the dp array
        /// This method calculates the minimum number of coins needed to make a given amount
        ///  
    }
}
