using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP
{
    public class L70_ClimbingStairs
    {
        // Dynamic Programming approach
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // This method calculates the number of distinct ways to climb to the nth step
        // using a bottom-up dynamic programming approach.
        // It uses two variables to keep track of the number of ways to reach
        // the last two steps, and iteratively calculates the number of ways
        // to reach the current step by summing the ways to reach the last two steps.
        // The result is stored in the variable 'current'.
        public int ClimbStairs(int n)
        {
            if (n <= 2) return n;

            // Initialize the first two steps
            int first = 1, second = 2, current = 0;

            for (int i = 3; i <= n; i++)
            {
                current = first + second; // sum of the last two steps
                first = second;// update first to the last step
                second = current;// update second to the current step
            }

            return current;
        }

        // Recursive approach with memoization
        // Time Complexity: O(n)
        // Space Complexity: O(n)
        // This method calculates the number of distinct ways to climb to the nth step
        // using a top-down recursive approach with memoization.
        // It uses a dictionary to store the results of previously calculated steps
        // to avoid redundant calculations.
        public int ClimbStairsRecursive(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return ClimbStairsHelper(n, memo);
        }
        private int ClimbStairsHelper(int n, Dictionary<int, int> memo)
        {
            if (n <= 2) return n;

            if (memo.ContainsKey(n)) return memo[n];

            // Calculate the number of ways to reach the nth step
            memo[n] = ClimbStairsHelper(n - 1, memo) + ClimbStairsHelper(n - 2, memo);
            return memo[n];
        }
        
        // Recursive approach without memoization
        // Time Complexity: O(2^n)
        // Space Complexity: O(n)
        // This method calculates the number of distinct ways to climb to the nth step
        // using a top-down recursive approach without memoization.
        // It recursively calculates the number of ways to reach the nth step
        // by summing the ways to reach the last two steps.
        public int ClimbStairsRecursiveNoMemo(int n)
        {
            if (n <= 2) return n;

            // Calculate the number of ways to reach the nth step
            return ClimbStairsRecursiveNoMemo(n - 1) + ClimbStairsRecursiveNoMemo(n - 2);
        }
        
        
        // Tabulation approach
        // Time Complexity: O(n)
        // Space Complexity: O(n)
        // This method calculates the number of distinct ways to climb to the nth step
        // using a bottom-up tabulation approach.
        // It uses an array to store the number of ways to reach each step
        // and iteratively calculates the number of ways to reach each step
        // by summing the ways to reach the last two steps.
         // The result is stored in the last element of the array.
         public int ClimbStairsTabulation(int n)
        {
                if (n <= 2) return n;

            // Initialize an array to store the number of ways to reach each step
            int[] dp = new int[n + 1];
            dp[1] = 1; // 1 way to reach step 1
            dp[2] = 2; // 2 ways to reach step 2
    
                for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2]; // sum of the last two steps
                }
    
                return dp[n]; // return the number of ways to reach the nth step
            }
        
        // Space Optimized Tabulation approach
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // This method calculates the number of distinct ways to climb to the nth step
        // using a bottom-up tabulation approach with space optimization.
        // It uses two variables to keep track of the number of ways to reach
        // the last two steps, and iteratively calculates the number of ways
        // to reach the current step by summing the ways to reach the last two steps.
        // The result is stored in the variable 'current'.
        public int ClimbStairsSpaceOptimized(int n)
        {
            if (n <= 2) return n;

            // Initialize the first two steps
            int first = 1, second = 2, current = 0;

            for (int i = 3; i <= n; i++)
            {
                current = first + second; // sum of the last two steps
                first = second;// update first to the last step
                second = current;// update second to the current step
            }

            return current;
        }
        

    }
}
