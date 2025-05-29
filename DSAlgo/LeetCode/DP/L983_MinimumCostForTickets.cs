namespace DSAlgo.LeetCode.DP
{
    using System;
    public class L983_MinimumCostForTickets
    {
        // This is a dynamic programming solution to the problem of finding the minimum cost for tickets.
        // The function takes an array of days and an array of costs for 1-day, 7-day, and 30-day tickets.
        // It uses a bottom-up approach to fill a dp array where dp[i] represents the minimum cost to cover the first i days.
        // The function iterates through each day and checks the cost of each ticket type (1-day, 7-day, 30-day).
        // It calculates the previous day that can be covered by each ticket type and updates the dp array accordingly.
        // Finally, it returns the minimum cost to cover all days.
        // Time Complexity: O(n * m) where n is the number of days and m is the number of ticket types (3 in this case)
        // Space Complexity: O(n) for the dp array
        public int MincostTickets(int[] days, int[] costs)
        {
            int n = days.Length; // Number of days
            int[] dp = new int[n + 1]; // dp[i] represents the minimum cost to cover the first i days
            dp[0] = 0; // Base case: no cost for 0 days

            // Iterate through each day
            // and calculate the minimum cost for each ticket type
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue; // Initialize to a large value
                // Iterate through each ticket type (1-day, 7-day, 30-day)
                for (int j = 0; j < costs.Length; j++)
                {
                    int duration = j == 0 ? 1 : (j == 1 ? 7 : 30); // duration of the ticket
                    int prevDay = days[i - 1] - duration; // previous day that can be covered by the ticket
                    int prevIndex = Array.BinarySearch(days, prevDay); // find the index of the previous day
                    if (prevIndex < 0) prevIndex = ~prevIndex - 1; // if not found, get the last index
                    dp[i] = Math.Min(dp[i], dp[prevIndex + 1] + costs[j]); // update the minimum cost
                }
            }

            return dp[n];
        }

        // This is a recursive solution to the problem of finding the minimum cost for tickets.
        // The function takes an array of days and an array of costs for 1-day, 7-day, and 30-day tickets.
        // It uses memoization to store the results of previously calculated days to avoid redundant calculations.
        // The function iterates through each day and checks the cost of each ticket type (1-day, 7-day, 30-day).
        // It calculates the next day that can be covered by each ticket type and recursively calls the function for the next day.
        // Finally, it returns the minimum cost to cover all days.
        // Time Complexity: O(n * m) where n is the number of days and m is the number of ticket types (3 in this case)
        // Space Complexity: O(n) for the memoization dictionary
        public int MincostTicketsRecursive(int[] days, int[] costs)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return MincostTicketsHelper(days, costs, 0, memo);
        }
        private int MincostTicketsHelper(int[] days, int[] costs, int index, Dictionary<int, int> memo)
        {
            if (index >= days.Length) return 0;

            if (memo.ContainsKey(index)) return memo[index];

            int minCost = int.MaxValue;
            for (int i = 0; i < costs.Length; i++)
            {
                int duration = i == 0 ? 1 : (i == 1 ? 7 : 30);
                int nextIndex = index;
                while (nextIndex < days.Length && days[nextIndex] < days[index] + duration)
                {
                    nextIndex++;
                }
                minCost = Math.Min(minCost, costs[i] + MincostTicketsHelper(days, costs, nextIndex, memo));
            }

            memo[index] = minCost;
            return minCost;
        }

        // This is a recursive solution to the problem of finding the minimum cost for tickets.
        // The function takes an array of days and an array of costs for 1-day, 7-day, and 30-day tickets.
        // It uses memoization to store the results of previously calculated days to avoid redundant calculations.
        // The function iterates through each day and checks the cost of each ticket type (1-day, 7-day, 30-day).
        // It calculates the next day that can be covered by each ticket type and recursively calls the function for the next day.
        // Finally, it returns the minimum cost to cover all days.
        // Time Complexity: O(n * m) where n is the number of days and m is the number of ticket types (3 in this case)
        // Space Complexity: O(n) for the memoization dictionary
        public int MincostTicketsRecursiveMemo(int[] days, int[] costs)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return MincostTicketsHelper1(days, costs, 0, memo);
        }
        private int MincostTicketsHelper1(int[] days, int[] costs, int index, Dictionary<int, int> memo)
        {
            if (index >= days.Length) return 0;

            if (memo.ContainsKey(index)) return memo[index];

            int minCost = int.MaxValue;
            for (int i = 0; i < costs.Length; i++)
            {
                int duration = i == 0 ? 1 : (i == 1 ? 7 : 30);
                int nextIndex = index;
                while (nextIndex < days.Length && days[nextIndex] < days[index] + duration)
                {
                    nextIndex++;
                }
                minCost = Math.Min(minCost, costs[i] + MincostTicketsHelper1(days, costs, nextIndex, memo));
            }

            memo[index] = minCost;
            return minCost;
        }
    }
}
