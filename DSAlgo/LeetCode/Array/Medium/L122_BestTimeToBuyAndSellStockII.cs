using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    public class L122_BestTimeToBuyAndSellStockII
    {
        /// This problem is about finding the maximum profit from stock prices
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            // Iterate through the prices array
            // If the current price is greater than the previous price,add the difference to maxProfit
            // This simulates buying at the previous price and selling at the current price
            // This is a greedy approach where we take every opportunity to make a profit by buying and selling on every upward trend

            // Time Complexity: O(n) where n is the number of  prices
            // Space Complexity: O(1) as we are using only a few variables
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }
    }
}
