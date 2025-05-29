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
        public int MaxProfitOptimized(int k, int[] prices)
        {
            if (prices.Length == 0 || k == 0) return 0;

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

            int[] dp = new int[prices.Length];
            for (int i = 1; i <= k; i++)
            {
                int maxDiff = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    dp[j] = Math.Max(dp[j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[j] - prices[j]);
                }
            }

            return dp[prices.Length - 1];
        }
    }
}
