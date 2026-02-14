using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1248_CountNiceSubarray
    {
        public L1248_CountNiceSubarray()
        {
            int[] nums = new int[] { 1, 1, 2, 1, 1 };
            int k = 3;
            Console.WriteLine(CountNiceSubarrays(nums, k));
        }

        public int CountNiceSubarrays(int[] nums, int k)
        {
            int count = 0;
            int left = 0, right = 0, oddCount = 0;
            while (right < nums.Length)
            {
                if (nums[right] % 2 == 1) // Check if the current number is odd
                {
                    oddCount++;
                }
                while (oddCount > k) // If we have more than k odd numbers, move the left pointer
                {
                    if (nums[left] % 2 == 1) // Check if the left number is odd
                    {
                        oddCount--;
                    }
                    left++;
                }
                if (oddCount == k) // If we have exactly k odd numbers, count the subarrays
                {
                    int tempLeft = left;
                    while (tempLeft < right && nums[tempLeft] % 2 == 0) // Count even numbers on the left
                    {
                        tempLeft++;
                    }
                    int tempRight = right;
                    while (tempRight > left && nums[tempRight] % 2 == 0) // Count even numbers on the right
                    {
                        tempRight--;
                    }
                    count += (tempLeft - left + 1) * (right - tempRight + 1); // Calculate the number of subarrays
                }
                right++;
            }
            return count;
        }

        // Brute Force Approach
        public int CountNiceSubarraysBruteForce(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int oddCount = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] % 2 == 1) // Check if the current number is odd
                    {
                        oddCount++;
                    }
                    if (oddCount == k) // If we have exactly k odd numbers, count the subarray
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
