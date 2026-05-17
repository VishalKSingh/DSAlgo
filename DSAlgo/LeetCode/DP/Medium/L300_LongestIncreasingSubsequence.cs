namespace DSAlgo.LeetCode.DP.Medium
{
    using System;
    internal class L300_LongestIncreasingSubsequence
    {
        // This problem is about finding the length of the longest increasing subsequence in an array of integers
        // The function should return the length of the longest increasing subsequence
        // Time Complexity: O(n^2) where n is the length of the input array, due to the nested loops
        // Space Complexity: O(n) due to the dp array

        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0; // Handle edge case of empty array
            int n = nums.Length;
            int[] dp = new int[n]; // Initialize a dp array to store the length of the longest increasing subsequence at each index
            Array.Fill(dp, 1); // Each element is at least an increasing subsequence of length 1
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j]) // Check if we can extend the increasing subsequence
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1); // Update the dp value for index i
                    }
                }
            }
            return dp.Max(); // The length of the longest increasing subsequence is the maximum value in the dp array
        }

        // This is an optimized approach using binary search, which reduces the time complexity to O(n log n)
        // The idea is to maintain a list that represents the smallest tail of all increasing subsequences with different lengths found so far.
        // For each number in the input array, we use binary search to find the appropriate position in the list and update it accordingly.
        // Time Complexity: O(n log n) where n is the length of the input array, due to the binary search
        // Space Complexity: O(n) in the worst case when all elements are increasing, as we may end up storing all elements in the list
        public int LengthOfLISOptimized(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0; // Handle edge case of empty array
            List<int> subsequence = new List<int>(); // This list will store the smallest tail of all increasing subsequences with different lengths
            foreach (var num in nums)
            {
                int index = subsequence.BinarySearch(num); // Find the index to insert the current number
                if (index < 0) index = ~index; // If not found, BinarySearch returns a negative number, we need to convert it to the correct index
                if (index == subsequence.Count) // If the number is larger than all elements in the subsequence list, add it to the end
                {
                    subsequence.Add(num);
                }
                else // Otherwise, replace the existing element at the found index
                {
                    subsequence[index] = num;
                }
            }
            return subsequence.Count; // The length of the longest increasing subsequence is the size of the subsequence list
        }
    }
}
