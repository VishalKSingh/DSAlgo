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

        // Optimized version using a greedy approach
        public bool CanJumpOptimized(int[] nums)
        {
            // Check if the array is empty or has only one element
            if (nums.Length == 0 || nums.Length == 1) return true;
            // Initialize the maximum reachable index to 0
            int maxReach = 0;
            // Iterate through the array until we reach the maximum reachable index
            for (int i = 0; i < nums.Length && i <= maxReach; i++)
            {
                maxReach = Math.Max(maxReach, i + nums[i]); // Update the maximum reachable index
                if (maxReach >= nums.Length - 1) return true; // If we can reach or exceed the last index, return true
            }
            return false; // If we finish the loop and can't reach the last index, return false
        }

        // Another approach using dynamic programming
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
            for (int i = 1; i <= nums[index]; i++)
            {
                if (DFS(nums, index + i, visited)) return true; // Recur for the next indices
            }

            return false; // If no path leads to the last index, return false
        }
    }
}
