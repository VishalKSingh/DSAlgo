using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP
{
    public class L403_FrogJump
    {
        /// This problem is about finding if a frog can cross a river by jumping on stones.
        /// The function takes an array of integers representing the positions of the stones.
        /// The frog can jump to the next stone with a jump size of k-1, k, or k+1.
        /// The function uses dynamic programming to check if the frog can reach the last stone.
         
        // Time Complexity: O(n^2) where n is the number of stones
        // Space Complexity: O(n) for the dp array
        

        public bool CanCross(int[] stones)
        {
            int n = stones.Length;
            if (n == 0 || stones[0] != 0) return false; // The frog starts at stone 0

            HashSet<int>[] dp = new HashSet<int>[n]; // Initialize a list of HashSets to store the possible jumps at each stone
            
            for (int i = 0; i < n; i++)
            {
                dp[i] = new HashSet<int>();
            }
            dp[0].Add(0); // The frog starts at stone 0 with a jump of 0

            // Iterate through each stone and check the possible jumps from the previous stones
            for (int i = 0; i < n; i++)
            {
                foreach (int k in dp[i]) // For each possible jump size at the current stone
                {
                    for (int j = -1; j <= 1; j++) // Check the next jump size (k-1, k, k+1)
                    {
                        int nextJump = k + j;
                        if (nextJump > 0) // The jump size must be positive
                        {
                            int nextStone = stones[i] + nextJump; // Calculate the position of the next stone
                            int index = Array.BinarySearch(stones, nextStone); // Find the index of the next stone
                            if (index >= 0) // If the stone exists
                            {
                                dp[index].Add(nextJump); // Add the jump size to the HashSet for that stone
                            }
                        }
                    }
                }
            }

            return dp[n - 1].Count > 0;
        }
        /// This is a recursive approach with memoization to solve the problem.
        /// The function takes the current stone index and the last jump size as parameters.
        /// It checks if the frog can jump to the next stone with a valid jump size.
        /// The function uses a dictionary to store the results of previously calculated stones to avoid redundant calculations.
        /// The function iterates through each possible jump size (k-1, k, k+1) and checks if the frog can jump to the next stone.
        /// Finally, it returns true if the frog can reach the last stone, otherwise false.
        /// Time Complexity: O(n^2) where n is the number of stones
        /// Space Complexity: O(n) for the memoization dictionary

        public bool CanCrossRecursive(int[] stones)
        {
            Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();
            return CanCrossHelper(stones, 0, 0, memo);
        }
        private bool CanCrossHelper(int[] stones, int index, int lastJump, Dictionary<(int, int), bool> memo)
        {
            if (index == stones.Length - 1) return true; // Reached the last stone

            if (memo.ContainsKey((index, lastJump))) return memo[(index, lastJump)]; // Check if already calculated

            for (int jump = lastJump - 1; jump <= lastJump + 1; jump++)
            {
                if (jump > 0)
                {
                    int nextStone = stones[index] + jump;
                    int nextIndex = Array.BinarySearch(stones, nextStone);
                    if (nextIndex >= 0 && CanCrossHelper(stones, nextIndex, jump, memo))
                    {
                        memo[(index, lastJump)] = true; // Store the result in the memo dictionary
                        return true;
                    }
                }
            }

            memo[(index, lastJump)] = false; // Store the result in the memo dictionary
            return false;
        }

        /// This is a recursive approach without memoization to solve the problem.
        /// The function takes the current stone index and the last jump size as parameters.
        /// It checks if the frog can jump to the next stone with a valid jump size.
        /// The function iterates through each possible jump size (k-1, k, k+1) and checks if the frog can jump to the next stone.
        /// Finally, it returns true if the frog can reach the last stone, otherwise false.
        // / Time Complexity: O(n^2) where n is the number of stones
        // / Space Complexity: O(n) for the recursion stack
        public bool CanCrossRecursiveNoMemo(int[] stones)
        {
            return CanCrossHelperNoMemo(stones, 0, 0);
        }
        private bool CanCrossHelperNoMemo(int[] stones, int index, int lastJump)
        {
            if (index == stones.Length - 1) return true; // Reached the last stone

            for (int jump = lastJump - 1; jump <= lastJump + 1; jump++)
            {
                if (jump > 0)
                {
                    int nextStone = stones[index] + jump;
                    int nextIndex = Array.BinarySearch(stones, nextStone);
                    if (nextIndex >= 0 && CanCrossHelperNoMemo(stones, nextIndex, jump))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// This is a tabulation approach to solve the problem.
        /// The function takes an array of integers representing the positions of the stones.
        /// It uses a 2D array to store the possible jumps at each stone.
        /// The function iterates through each stone and checks the possible jumps from the previous stones.
        /// Finally, it returns true if the frog can reach the last stone, otherwise false.
        /// Time Complexity: O(n^2) where n is the number of stones
        // Space Complexity: O(n^2) for the dp array

        public bool CanCrossTabulation(int[] stones)
        {
            int n = stones.Length;
            if (n == 0 || stones[0] != 0) return false; // The frog starts at stone 0

            bool[,] dp = new bool[n, n]; // Initialize a 2D array to store the possible jumps at each stone
            dp[0, 0] = true; // The frog starts at stone 0 with a jump of 0

            // Iterate through each stone and check the possible jumps from the previous stones
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dp[i, j])
                    {
                        for (int k = -1; k <= 1; k++) // Check the next jump size (k-1, k, k+1)
                        {
                            int nextJump = j + k;
                            if (nextJump > 0) // The jump size must be positive
                            {
                                int nextStone = stones[i] + nextJump; // Calculate the position of the next stone
                                int index = Array.BinarySearch(stones, nextStone); // Find the index of the next stone
                                if (index >= 0) // If the stone exists
                                {
                                    dp[index, nextJump] = true; // Mark the jump size as possible for that stone
                                }
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (dp[n - 1, j]) return true; // Check if any jump size is possible for the last stone
            }

            return false;
        }

        /// This is a space optimized tabulation approach to solve the problem.
        /// The function takes an array of integers representing the positions of the stones.
        /// It uses a HashSet to store the possible jumps at each stone.
        /// The function iterates through each stone and checks the possible jumps from the previous stones.
        /// Finally, it returns true if the frog can reach the last stone, otherwise false.
        /// Time Complexity: O(n^2) where n is the number of stones
        // Space Complexity: O(n) for the HashSet

        public bool CanCrossSpaceOptimized(int[] stones)
        {
            int n = stones.Length;
            if (n == 0 || stones[0] != 0) return false; // The frog starts at stone 0

            HashSet<int> dp = new HashSet<int>(); // Initialize a HashSet to store the possible jumps at each stone
            dp.Add(0); // The frog starts at stone 0 with a jump of 0

            // Iterate through each stone and check the possible jumps from the previous stones
            for (int i = 0; i < n; i++)
            {
                HashSet<int> nextDp = new HashSet<int>(); // Create a new HashSet for the next stone
                foreach (int k in dp) // For each possible jump size at the current stone
                {
                    for (int j = -1; j <= 1; j++) // Check the next jump size (k-1, k, k+1)
                    {
                        int nextJump = k + j;
                        if (nextJump > 0) // The jump size must be positive
                        {
                            int nextStone = stones[i] + nextJump; // Calculate the position of the next stone
                            int index = Array.BinarySearch(stones, nextStone); // Find the index of the next stone
                            if (index >= 0) // If the stone exists
                            {
                                nextDp.Add(nextJump); // Add the jump size to the HashSet for that stone
                            }
                        }
                    }
                }
                dp = nextDp; // Update the HashSet for the next iteration
            }

            return dp.Count > 0; // Check if any jump size is possible for the last stone
        }
    }

    
}
