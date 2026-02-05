using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    public class L123_BestTimeToBuyAndSellStockIII
    {
        //This problem is to find the maximum profit you can make by making at most two transactions.
        //You can buy and sell the stock at most twice.

        //The idea is to calculate the maximum profit for one transaction from the left and one from the right.
        //Then combine both profits to get the maximum profit with two transactions.

        //We can use two arrays to store the maximum profit for one transaction from the left and one from the right.
        //The leftProfits array stores the maximum profit for one transaction from the left.
        //The rightProfits array stores the maximum profit for one transaction from the right.
        //We can then combine both profits to get the maximum profit with two transactions.

        //Time Complexity: O(n)
        //Space Complexity: O(n)

        // Input: prices = [3,3,5,0,0,3,1,4]
        // Output: 6

        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n < 2) return 0;

            int[] leftProfits = new int[n];
            int[] rightProfits = new int[n];

            // Calculate max profit for one transaction from the left
            int minPrice = prices[0];
            for (int i = 1; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]); // this is the minimum price we can buy at up to day i
                leftProfits[i] = Math.Max(leftProfits[i - 1], prices[i] - minPrice); // this is the max profit we can get by selling at prices[i] after buying at minPrice
            }

            // Calculate max profit for one transaction from the right
            int maxPrice = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                rightProfits[i] = Math.Max(rightProfits[i + 1], maxPrice - prices[i]);
            }

            // Combine both profits to get the maximum profit with two transactions
            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, leftProfits[i] + rightProfits[i]);
            }

            return maxProfit;
        }

 


    }
}
