using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L55_JumpGame
    {
        // This problem is about determining if you can reach the last index of the array
        // The function should return true if you can reach the last index, otherwise false
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are using a constant amount of space

        // Recursive approach without memoization (not recommended due to potential for exponential time complexity)
        public bool CanJumpRecursive(int[] nums)
        {
            return CanJumpHelper(nums, 0); // Start the recursive helper function from the first index
        }
        private bool CanJumpHelper(int[] nums, int index)
        {
            if (index >= nums.Length - 1) return true; // If we reach or exceed the last index, return true
            // Try to jump to all reachable indices from the current index
            // Because a jump of 0 leaves you at the same index — calling CanJumpHelper(nums, index + 0) would recurse on the identical state
            //and (without a visited/memo check) cause infinite recursion. So the loop starts at i = 1 to only consider moves that advance the index.
            for (int i = 1; i <= nums[index]; i++)
            {
                if (CanJumpHelper(nums, index + i)) return true; // Recur for the next indices
            }
            return false; // If no path leads to the last index, return false
        }

        // Recursive approach with memoization to avoid redundant calculations
        // Time Complexity: O(n) where n is the length of the array, since each index is computed at most once
        // space Complexity: O(n) due to the memoization array
        public bool CanJumpRecursiveMemo(int[] nums)
        {
            int n = nums.Length;
            bool[] memo = new bool[n]; // Initialize a memoization array to store results of subproblems
            return CanJumpHelper(nums, 0, memo); // Start the recursive helper function from the first index
        }
        private bool CanJumpHelper(int[] nums, int index, bool[] memo)
        {
            if (index >= nums.Length - 1) return true; // If we reach or exceed the last index, return true
            if (memo[index]) return false; // If we have already computed this index and it's not reachable, return false
            memo[index] = true; // Mark this index as visited
            // Try to jump to all reachable indices from the current index
            for (int i = 1; i <= nums[index]; i++)
            {
                if (CanJumpHelper(nums, index + i, memo)) return true; // Recur for the next indices
            }
            return false; // If no path leads to the last index, return false
        }

        // using dynamic programming
        public bool CanJumpDP(int[] nums)
        {
            int n = nums.Length;
            bool[] dp = new bool[n];
            dp[0] = true; // We can always reach the first index

            // Iterate through the array and update the dp array
            for (int i = 0; i < n; i++)
            {
                // If we can't reach this index, continue to the next
                if (dp[i])
                {
                    // Try to jump to all reachable indices from the current index
                    for (int j = 1; j <= nums[i] && i + j < n; j++)
                    {
                        dp[i + j] = true; // Mark reachable indices as true
                    }
                }
            }

            return dp[n - 1]; // Return if the last index is reachable
        }


        // Optimized version using a forward greedy approach
        public bool CanJumpForwardGreedy(int[] nums)
        {
            int n = nums.Length;
            int maxReach = 0; // Initialize the maximum reachable index
            // Iterate through the array
            for (int i = 0; i < n; i++)
            {
                if (i > maxReach) return false; // If we can't reach current index, return false
                maxReach = Math.Max(maxReach, i + nums[i]); // Update the maximum reachable index
                if (maxReach >= n - 1) return true; // If we can reach or exceed the last index, return true
            }
            return false; // If we finish the loop and can't reach the last index, return false

        }


        // Another approach using BFS
        public bool CanJumpBFS(int[] nums)
        {
            int n = nums.Length;
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[n];
            queue.Enqueue(0); // Start from the first index
            visited[0] = true;

            while (queue.Count > 0)
            {
                int currentIndex = queue.Dequeue();
                if (currentIndex >= n - 1) return true; // If we reach or exceed the last index, return true

                for (int i = 1; i <= nums[currentIndex]; i++)
                {
                    int nextIndex = currentIndex + i;
                    if (nextIndex < n && !visited[nextIndex])
                    {
                        visited[nextIndex] = true; // Mark this index as visited
                        queue.Enqueue(nextIndex); // Add it to the queue for further exploration
                    }
                }
            }

            return false; // If we finish the loop and can't reach the last index, return false
        }

        // Another approach using DFS
        public bool CanJumpDFS(int[] nums)
        {
            int n = nums.Length;
            bool[] visited = new bool[n]; // Initialize a visited array to keep track of visited indices
            return DFS(nums, 0, visited); // Start DFS from the first index
        }
        private bool DFS(int[] nums, int index, bool[] visited)
        {
            if (index >= nums.Length - 1) return true; // If we reach or exceed the last index, return true
            if (visited[index]) return false; // If we have already visited this index, return false

            visited[index] = true; // Mark this index as visited
            // Try to jump to all reachable indices from the current index
            // We can jump from index to index + 1, index + 2, ..., index + nums[index]
            // Recursively call DFS for each reachable index
            // If any of the recursive calls returns true, we can reach the last index, so we return true
            for (int i = 1; i <= nums[index]; i++)
            {
                if (DFS(nums, index + i, visited)) return true; // Recur for the next indices
            }

            return false; // If no path leads to the last index, return false
        }
    }
}
