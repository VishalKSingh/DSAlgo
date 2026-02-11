using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1004_MaxConsecutiveOneIII
    {
        // The approach is to use a sliding window technique to find the longest subarray that contains at most k zeros.
        // Time Complexity: O(n2) where n is the length of the input array
        // Space Complexity: O(1) since we are using a constant amount of space

        public int LongestOnesBruteForce(int[] nums, int k)
        {
            int maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int zeroCount = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] == 0)
                    {
                        zeroCount++;
                    }
                    if (zeroCount > k)
                    {
                        break;
                    }
                    maxLength = Math.Max(maxLength, j - i + 1);
                }
            }
            return maxLength;
        }

        public int LongestOnesOptimized(int[] nums, int k)
        {
            int left = 0, maxLength = 0, right =0, zeros =0;

            // The idea is to expand the right pointer and count the number of zeros in the current window.
            // If the count of zeros exceeds k, we move the left pointer to shrink the window until we have at most k zeros.
            // We keep track of the maximum length of the window that satisfies the condition.
            while (right < nums.Length)
            {
                if(nums[right] == 0)
                {
                    zeros++;
                }

                if(zeros > k)
                {
                    if(nums[left] == 0)
                    {
                        zeros--;
                    }
                    left++;
                }
               
                if(zeros <= k)
                {
                    maxLength = Math.Max(maxLength, right - left + 1);
                }
                right++;

            }

            return maxLength;
        }
    }
}
