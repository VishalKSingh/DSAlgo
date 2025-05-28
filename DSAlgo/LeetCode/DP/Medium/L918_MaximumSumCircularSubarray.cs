using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L918_MaximumSumCircularSubarray
    {
        // This problem is about finding the maximum sum of a circular subarray in an array
        // The key idea is to consider two cases:
        // 1. The maximum subarray sum is not circular (Kadane's algorithm)
        // 2. The maximum subarray sum is circular, which can be computed as total sum - minimum subarray sum
        // We need to handle the case where all elements are negative separately
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1)

        public int MaxSubarraySumCircular(int[] nums)
        {
            int maxKadane = Kadane(nums);
            int totalSum = nums.Sum();
            int minKadane = Kadane(nums.Select(x => -x).ToArray());
            int maxCircular = totalSum + minKadane; // Since minKadane is negative, this effectively subtracts the minimum subarray sum

            // If all numbers are negative, maxCircular will be 0, so we return maxKadane
            return maxCircular > 0 ? Math.Max(maxKadane, maxCircular) : maxKadane;
        }
        private int Kadane(int[] nums)
        {
            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }

        // more optimized version
        public int MaxSubarraySumCircularOptimized(int[] nums)
        {
            int maxSum = nums[0], minSum = nums[0], totalSum = nums[0];
            int currentMax = nums[0], currentMin = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentMax = Math.Max(nums[i], currentMax + nums[i]);
                maxSum = Math.Max(maxSum, currentMax);

                currentMin = Math.Min(nums[i], currentMin + nums[i]);
                minSum = Math.Min(minSum, currentMin);

                totalSum += nums[i];
            }

            // If all numbers are negative, return the maximum subarray sum
            return totalSum == minSum ? maxSum : Math.Max(maxSum, totalSum - minSum);
        }

    

    }
}
