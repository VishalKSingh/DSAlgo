using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L1838_MaximumFrequency
    {
        // Optimized Sliding Window

        public int MaxFrequency(int[] nums, int k)
        {
            Array.Sort(nums);
            int sum = 0;
            long total = 0;
            int maxFreq = 1;
            int left =0;
            // right pointer
            // expand the window
            // calculate the total increments needed to make all elements in the window equal to nums[right]
            // if total exceeds k, shrink the window from the left
            // update the result with the maximum window size found
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right]; // sum of elements in the current window
                total = (long)(nums[right]* (right - left + 1) - sum); // total increments needed
                // shrink the window if total exceeds k
                while (total > k)
                {
                    sum -= nums[left];// remove the leftmost element from sum
                    left++; // shrink the window from the left
                }
                maxFreq = Math.Max(maxFreq, right - left + 1);// update max frequency
            }
            return maxFreq;
        }

        // Brute Force - TLE
        public int MaxFrequency_BruteForce(int[] nums, int k)
        {
            int maxFreq = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int currentFreq = 1;
                int remainingK = k;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[j] < nums[i])
                    {
                        int diff = nums[i] - nums[j];
                        if (remainingK >= diff)
                        {
                            remainingK -= diff;
                            currentFreq++;
                        }
                    }
                }
                maxFreq = Math.Max(maxFreq, currentFreq);
            }
            return maxFreq;
        }

    }
}
