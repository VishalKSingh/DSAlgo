using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L714_BestTimetoBuyandSellStockwithTransactionFee
    {
        public L714_BestTimetoBuyandSellStockwithTransactionFee()
        {
        }
        public L714_BestTimetoBuyandSellStockwithTransactionFee(int[] prices, int fee)
        {
            int maxProfit = MaxProfit(prices, fee);
            Console.WriteLine($"Maximum profit: {maxProfit}");
        }

        public int MaxProfit(int[] prices, int fee)
        {
            int n = prices.Length;
            if (n == 0) return 0;
            // This problem is about finding the maximum profit from stock trading with a transaction fee.
            // The idea is to use dynamic programming to keep track of the maximum profit at each day.
            // We maintain two variables: buy and sell.
            // buy represents the maximum profit on day i if we buy stock on that day.
            // sell represents the maximum profit on day i if we sell stock on that day.
            // The transition is as follows:

            int buy = -prices[0]; // Initial state, we buy stock on day 0
            int sell = 0; // Initial state, we don't sell stock on day 0
            for (int i = 1; i < n; i++)
            {
                int temp = sell; // Store the previous day's sell profit
                sell = Math.Max(sell, buy + prices[i] - fee); // Update the current day's sell profit
                buy = Math.Max(buy, temp - prices[i]); // Update the current day's buy profit
            }
            return sell;
        }
    }
}
