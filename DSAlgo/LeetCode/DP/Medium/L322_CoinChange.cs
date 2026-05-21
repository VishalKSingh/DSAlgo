namespace DSAlgo.LeetCode.DP.Medium
{
    using System;
    public class L322_CoinChange
    {
        /// https://leetcode.com/problems/coin-change/
        /// // This problem is about finding the minimum number of coins needed to make a given amount using a set of coin denominations.
        /// // The function should return the minimum number of coins needed to make the amount, or -1 if it is not possible to make that amount with the given coins.
        /// // Time Complexity: O(n * m) where n is the amount and m is the number of coins, due to the nested loops
        /// // Space Complexity: O(n) for the dp array
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


        // The recursive approach with memoization
        // This method uses a helper function to recursively calculate the minimum number of coins needed for a given amount, while using a dictionary to store previously calculated results to avoid redundant calculations.
        // Time Complexity: O(n * m) where n is the amount and m is the number of coins, due to the recursive calls and memoization
        // Space Complexity: O(n) for the memoization dictionary and the recursive call stack
        public int CoinChangeRecursive(int[] coins, int amount)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>(); // Create a dictionary to store the results of previously calculated amounts
            return CoinChangeHelper(coins, amount, memo);
        }

        /// This helper method recursively calculates the minimum number of coins needed for a given amount.
        private int CoinChangeHelper(int[] coins, int amount, Dictionary<int, int> memo)
        {
            if (amount < 0) return -1; // Base case: if the amount is negative, return -1 (not possible)
            if (amount == 0) return 0; // Base case: if the amount is 0, return 0 (no coins needed)
            
            if (memo.ContainsKey(amount)) return memo[amount]; // If the result for this amount has already been calculated, return it from the memo dictionary
            
            int minCoins = int.MaxValue; // Initialize minCoins to a large number
            // Iterate through all coins and recursively calculate the minimum coins needed for the remaining amount
            foreach (var coin in coins)
            {
                int res = CoinChangeHelper(coins, amount - coin, memo); // Recursive call for the remaining amount
                // If the result is valid (not -1), update minCoins with the minimum value found
                if (res >= 0 && res < minCoins)
                {
                    minCoins = res + 1; // Update minCoins if a valid solution is found
                }
            }
            memo[amount] = (minCoins == int.MaxValue) ? -1 : minCoins; // Store the result in the memo dictionary
            return memo[amount]; // Return the minimum number of coins needed for this amount
        }
    }
}
