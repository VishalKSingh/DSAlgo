using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    public class L121_BestTimeToBuyAndSellStock
    {
        // The idea is to keep track of the minimum price seen so far and the maximum profit that can be made.
        // For each price in the array, we check if it is less than the minimum price seen so far.
        // If it is, we update the minimum price. Otherwise, we calculate the profit that can be made by selling at the current price
        // and update the maximum profit if the calculated profit is greater than the maximum profit seen so far.
        // The final result is the maximum profit that can be made.
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // This method calculates the maximum profit that can be made by buying and selling a stock
        // given an array of prices where prices[i] is the price of the stock on the ith day.
        //[7,1,5,3,6,4]

        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (int price in prices)
            {
                if (price < minPrice)
                {
                    minPrice = price;
                }
                else if (price - minPrice > maxProfit)
                {
                    maxProfit = price - minPrice;
                }
            }

            return maxProfit;
        }
    }
}
