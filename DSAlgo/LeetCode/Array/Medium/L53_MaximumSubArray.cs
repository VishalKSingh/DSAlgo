using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L53_MaximumSubArray
    {
        // This is a classic problem of finding the maximum sum of a contiguous subarray.
        // The algorithm used here is Kadane's algorithm, which runs in O(n) time complexity.
        // The idea is to iterate through the array while maintaining the current sum of the subarray.
        // If the current sum becomes negative, we reset it to zero.    
        // We also keep track of the maximum sum encountered so far.
        // The space complexity is O(1) since we are using only a few variables to store the current sum and maximum sum.
        // The final result is the maximum sum of the contiguous subarray.
        
        // The algorithm works as follows:
        // 1. Initialize two variables: sum to 0 and maxSum to the minimum possible integer value.
        // 2. Iterate through the array:
        //    a. Add the current element to sum.
        //    b. If sum is greater than maxSum, update maxSum.
        //    c. If sum becomes negative, reset it to 0.
        // 3. Return maxSum as the result.
        // The time complexity of this algorithm is O(n), where n is the length of the input array.
        // The space complexity is O(1) since we are using only a few variables to store the current sum and maximum sum.

        public int MaximumSubArray(int[] nums)
        {
            int N = nums.Length;
            int sum = 0;
            int maxSum = Int32.MinValue;

            for (int i = 0; i < N; i++)
            {
                sum += nums[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                if (sum < 0)
                {
                    sum = 0;
                }
            }
            return maxSum;

        }

        // This is a brute force approach to find the maximum sum of a contiguous subarray.
        // The algorithm works as follows:
        // 1. Initialize a variable maxSum to the minimum possible integer value.
        // 2. Iterate through the array with two nested loops:
        //    a. The outer loop iterates through each element of the array.
        //    b. The inner loop iterates through the subarray starting from the current element of the outer loop.
        //    c. For each subarray, calculate the sum and update maxSum if the current sum is greater than maxSum.
        // 3. Return maxSum as the result.
        // The time complexity is O(n^2), where n is the length of the input array.
        // The space complexity is O(1) since we are using only a few variables to store the current sum and maximum sum.

        public int MaximumSubArrayBruteForce(int[] nums)
        {
            int N = nums.Length;
            int maxSum = Int32.MinValue;

            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = i; j < N; j++)
                {
                    sum += nums[j];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }
    }
}
