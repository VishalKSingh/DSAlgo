using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        // A nice subarray is defined as a contiguous subarray that contains exactly k odd numbers.
        // Given an array of integers nums and an integer k, return the number of nice subarrays.
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1)
        public int CountNiceSubarrays(int[] nums, int k)
        {
            if (k < 0) return 0;

            int count = 0;
            int left = 0;
            int oddCount = 0;
            int middle = 0; // Pointer to track the start of the current window

            for (int right = 0; right < nums.Length; right++)
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
                    middle = left; // Update middle to the new left position
                }

                if (oddCount == k)
                {
                    // Count the number of even numbers to the left of the current window
                    while (nums[middle] % 2 != 1)
                    {
                        middle++; // Move middle to the right until we find an odd number
                    }
                    count += (middle - left) + 1; // Add the number of nice subarrays ending at the current right index


                }
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
                    if (nums[j] % 2 == 1)
                    {
                        oddCount++;
                    }
                    if (oddCount == k)
                    {
                        count++;
                    }
                    else if (oddCount > k)
                    {
                        break;
                    }
                }
            }
            return count;
        }
    }
}
