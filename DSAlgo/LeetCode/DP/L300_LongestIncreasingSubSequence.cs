namespace DSAlgo.LeetCode.DP
{
    using System;
    public class L300_LongestIncreasingSubSequence
    {
        // This is a classic dynamic programming problem where we want to find the length of the longest increasing subsequence in an array.
        // The idea is to maintain a dp array where dp[i] represents the length of the longest increasing subsequence that ends with nums[i].
        // We iterate through the array and for each element, we check all previous elements to see if we can extend the increasing subsequence.
        // The time complexity of this approach is O(n^2) where n is the length of the input array.
        // The space complexity is O(n) for the dp array.
        // The final result is the maximum value in the dp array.

        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n]; // dp[i] will be storing the length of the longest increasing subsequence ending at index i
            Array.Fill(dp, 1); // Initialize all dp values to 1

            // Base case: the longest increasing subsequence ending at each index is at least 1 (the element itself)
           
            // If nums[i] > nums[j], we can extend the increasing subsequence ending at j to include nums[i]
            // So we update dp[i] to be the maximum of its current value and dp[j] + 1
            // This means we can extend the increasing subsequence ending at j to include nums[i]
            // The final result is the maximum value in the dp array

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            return dp.Max();
        }
        // This is an optimized version of the above approach using binary search.
        // The idea is to maintain a list that represents the smallest tail of all increasing subsequences with different lengths.
        // We iterate through the input array and for each element, we use binary search to find its position in the list.
        // If the element is larger than the largest element in the list, we append it to the list.
        // Otherwise, we replace the first element in the list that is larger than or equal to the current element.
        // The length of the list at the end of the iteration is the length of the longest increasing subsequence.
        // The time complexity of this approach is O(n log n) where n is the length of the input array.
        // The space complexity is O(n) for the list.
        public int LengthOfLISOptimized(int[] nums)
        {
            List<int> lis = new List<int>();

            foreach (var num in nums)
            {
                int index = lis.BinarySearch(num);
                if (index < 0) index = ~index;

                if (index == lis.Count)
                {
                    lis.Add(num);
                }
                else
                {
                    lis[index] = num;
                }
            }

            return lis.Count;
        }
    }
}
