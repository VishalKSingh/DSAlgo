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
                minPrice = Math.Min(minPrice, prices[i]);
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

        // The above solution uses O(n) space for the leftProfits and rightProfits arrays.
        // We can optimize the space complexity to O(1) by using two variables to keep track of the maximum profits.
        public int MaxProfitOptimized(int[] prices)
        {
            int n = prices.Length;
            if (n < 2) return 0;

            int leftMaxProfit = 0;
            int rightMaxProfit = 0;
            int minPrice = prices[0];
            int maxPrice = prices[n - 1];

            // Calculate max profit for one transaction from the left
            for (int i = 1; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                leftMaxProfit = Math.Max(leftMaxProfit, prices[i] - minPrice);
            }

            // Calculate max profit for one transaction from the right
            for (int i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                rightMaxProfit = Math.Max(rightMaxProfit, maxPrice - prices[i]);
            }

            return leftMaxProfit + rightMaxProfit;
        }

        // approach of the above solution
        // 1. Initialize two variables to keep track of the maximum profit for one transaction from the left and one from the right.
        // 2. Iterate through the prices array from left to right to calculate the maximum profit for one transaction from the left.
        // 3. Iterate through the prices array from right to left to calculate the maximum profit for one transaction from the right.
        // 4. Combine both profits to get the maximum profit with two transactions.
        // 5. Return the maximum profit.

        // Example usage
        //public static void Main(string[] args)
        //{
        //    L123_BestTimeToBuyAndSellStockIII solution = new L123_BestTimeToBuyAndSellStockIII();
        //    int[] prices = { 3, 2, 6, 5, 0, 3 };
        //    int maxProfit = solution.MaxProfit(prices);
        //    Console.WriteLine($"Maximum profit with two transactions: {maxProfit}");
        //}


    }
}
