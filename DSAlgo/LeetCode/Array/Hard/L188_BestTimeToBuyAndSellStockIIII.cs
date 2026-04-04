using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    internal class L188_BestTimeToBuyAndSellStockIIII
    {
        // This problem is about finding the maximum profit from at most k transactions
        // The function should return the maximum profit possible
        // Time Complexity: O(n * k) where n is the number of days and k is the number of transactions
        // Space Complexity: O(n * k) for the DP table

        public int MaxProfit(int k, int[] prices)
        {
            if (prices.Length == 0 || k == 0) return 0;
            // If k is greater than or equal to half the number of days, we can perform as many transactions as we want
            if (k >= prices.Length / 2)
            {
                int maxProfit = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        maxProfit += prices[i] - prices[i - 1];
                    }
                }
                return maxProfit;
            }

            int[,] dp = new int[k + 1, prices.Length];

            for (int i = 1; i <= k; i++)
            {
                int maxDiff = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[i - 1, j] - prices[j]);
                }
            }

            return dp[k, prices.Length - 1];
        }

        // optimized version using 1D array
        // This optimized version reduces the space complexity to O(n) by using a single array to store the maximum profit for each day
        // The maxDiff variable is used to keep track of the maximum profit that can be made by buying at a previous day and selling at the current day
        // Time Complexity: O(n * k) where n is the number of days and k is the number of transactions
        // Space Complexity: O(n) for the DP array
        public int MaxProfitOptimized(int k, int[] prices)
        {
            if (prices.Length == 0 || k == 0) return 0;

            // If k is greater than or equal to half the number of days, we can perform as many transactions as we want
            if (k >= prices.Length / 2)
            {
                int maxProfit = 0;
                // Calculate the maximum profit by summing up all positive price differences
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        maxProfit += prices[i] - prices[i - 1];
                    }
                }
                return maxProfit;
            }

            // Using a 1D array to store the maximum profit for each day
            int[] dp = new int[prices.Length];
            // Initialize the dp array to 0, as no profit can be made initially
            dp[0] = 0;// The dp array will store the maximum profit that can be made up to day j with at most i transactions
            // Iterate through the number of transactions allowed
            for (int i = 1; i <= k; i++)
            {
                // maxDiff is used to keep track of the maximum profit that can be made by buying at a previous day and selling at the current day
                //(prev day profit -> dp[0] = 0 -> maxDiff = 0 - pricses[0] 
                int maxDiff = -prices[0]; // Initialize maxDiff to the negative price of the first day
                // Iterate through the prices starting from the second day
                for (int j = 1; j < prices.Length; j++)
                {
                    int prevProfit = dp[j]; // Store the profit from the previous day before updating it
                    // Update the dp array for day j by taking the maximum of not selling on day j (dp[j - 1]) or selling on day j (prices[j] + maxDiff)
                    dp[j] = Math.Max(dp[j - 1], prices[j] + maxDiff); // Calculate the maximum profit for day j
                    maxDiff = Math.Max(maxDiff, prevProfit - prices[j]); // Update maxDiff to the maximum of its current value or the profit from the previous day minus the current price
                }
            }

            return dp[prices.Length - 1];
        }
    }
}
