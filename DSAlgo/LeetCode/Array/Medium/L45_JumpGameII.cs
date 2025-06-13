using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L45_JumpGameII
    {
        // This problem is about finding the minimum number of jumps to reach the last index
        // The function should return the minimum number of jumps required
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are using a constant amount of space
        // approach using Greedy Algorithm
        public int Jump(int[] nums)
        {
            if (nums.Length <= 1) return 0; // If the array has one or no elements, no jumps are needed

            int jumps = 0; // Initialize the number of jumps
            int currentEnd = 0; // The farthest point we can reach with the current number of jumps
            int farthest = 0; // The farthest point we can reach with one more jump

            // Iterate through the array until the second last element
            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]); // Update the farthest point we can reach

                if (i == currentEnd) // If we have reached the end of the current jump
                {
                    jumps++; // Increment the jump count
                    currentEnd = farthest; // Update the end point for the next jump
                }
            }

            return jumps; // Return the total number of jumps required
        }

        // Another approach using BFS
        public int JumpBFS(int[] nums)
        {
            if (nums.Length <= 1) return 0; // If the array has one or no elements, no jumps are needed

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); // Start from the first index
            int jumps = 0; // Initialize the number of jumps
            int n = nums.Length;

            while (queue.Count > 0)
            {
                int size = queue.Count; // Number of elements at the current level
                for (int i = 0; i < size; i++)
                {
                    int currentIndex = queue.Dequeue(); // Get the current index

                    if (currentIndex >= n - 1) return jumps; // If we reach or exceed the last index, return jumps

                    for (int j = 1; j <= nums[currentIndex]; j++)
                    {
                        int nextIndex = currentIndex + j;
                        if (nextIndex < n) queue.Enqueue(nextIndex); // Enqueue the next index if it's within bounds
                    }
                }
                jumps++; // Increment the jump count after processing all indices at the current level
            }

            return -1; // If we exit the loop without reaching the last index, return -1 (should not happen in valid input)
        }

        // Another approach using Dynamic Programming
        public int JumpDP(int[] nums)
        {
            if (nums.Length <= 1) return 0; // If the array has one or no elements, no jumps are needed

            int[] dp = new int[nums.Length]; // Create a DP array to store the minimum jumps to reach each index
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = int.MaxValue; // Initialize all indices to max value
                for (int j = 0; j < i; j++)
                {
                    if (j + nums[j] >= i && dp[j] != int.MaxValue) // If we can jump from j to i
                    {
                        dp[i] = Math.Min(dp[i], dp[j] + 1); // Update the minimum jumps to reach i
                    }
                }
            }

            return dp[nums.Length - 1]; // Return the minimum jumps to reach the last index
        }


        // Another approach using DFS
        public int JumpDFS(int[] nums)
        {
            if (nums.Length <= 1) return 0; // If the array has one or no elements, no jumps are needed

            return JumpDFSHelper(nums, 0, new int[nums.Length]);
        }
        private int JumpDFSHelper(int[] nums, int index, int[] memo)
        {
            if (index >= nums.Length - 1) return 0; // If we reach or exceed the last index, no jumps are needed

            if (memo[index] != 0) return memo[index]; // Return the cached result if it exists

            int minJumps = int.MaxValue; // Initialize the minimum jumps to max value
            for (int i = 1; i <= nums[index]; i++)
            {
                int nextIndex = index + i;
                if (nextIndex < nums.Length)
                {
                    int jumps = JumpDFSHelper(nums, nextIndex, memo); // Recursive call to find jumps from the next index
                    if (jumps != int.MaxValue) // If we can reach the end from the next index
                    {
                        minJumps = Math.Min(minJumps, jumps + 1); // Update the minimum jumps
                    }
                }
            }

            memo[index] = minJumps; // Cache the result
            return minJumps; // Return the minimum jumps required from this index
        }
    }
}
