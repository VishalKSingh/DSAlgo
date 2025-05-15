using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L309_BestTimeToBuyAndSellStockWithCooldown
    {
        // This problem is about finding the maximum profit from stock trading with a cooldown period.
        // The idea is to use dynamic programming to keep track of the maximum profit at each day.
        // We maintain two arrays: buy and sell.
        // buy[i] represents the maximum profit on day i if we buy stock on that day.
        // sell[i] represents the maximum profit on day i if we sell stock on that day.
        // The transition is as follows:
        // buy[i] = max(buy[i-1], sell[i-2] - prices[i])
        // sell[i] = max(sell[i-1], buy[i-1] + prices[i])
        // The final result is the maximum profit on the last day when we sell stock.
        // Time Complexity: O(n)
        // Space Complexity: O(n)
      
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;

            int[] buy = new int[n];
            int[] sell = new int[n];

            buy[0] = -prices[0]; // Initial state, we buy stock on day 0
            sell[0] = 0; // Initial state, we don't sell stock on day 0

            // Fill the buy and sell arrays
            for (int i = 1; i < n; i++)
            {
                buy[i] = Math.Max(buy[i - 1], i> 1 ? sell[i - 2] - prices[i] : -prices[i]); // Update the current day's buy profit
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]); // Update the current day's sell profit
            }

            return sell[n - 1];
        }

        // Optimized Space Complexity
        // We can reduce the space complexity to O(1) by using two variables instead of arrays.
        public int MaxProfitOptimized(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;

            int buy = -prices[0]; // Initial state, we buy stock on day 0
            int sell = 0; // Initial state, we don't sell stock on day 0
            int prevSell = 0; // Previous day's sell profit

            // Fill the buy and sell variables
            for (int i = 1; i < n; i++)
            {
                int temp = sell; // Store the previous day's sell profit
                sell = Math.Max(sell, buy + prices[i]); // Update the current day's sell profit
                buy = Math.Max(buy, prevSell - prices[i]); // Update the current day's buy profit
                prevSell = temp; // Update the previous day's sell profit
            }

            return sell;
        }
    }
}
