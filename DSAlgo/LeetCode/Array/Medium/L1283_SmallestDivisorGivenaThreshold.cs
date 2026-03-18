using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1283_SmallestDivisorGivenaThreshold
    {
        public L1283_SmallestDivisorGivenaThreshold() { }

        public int SmallestDivisor(int[] nums, int threshold)
        {
            int left = 1; // Minimum possible divisor
            int right = nums.Max(); // Maximum possible divisor
            while (left < right)
            {
                int mid = left + (right - left) / 2; // Midpoint divisor
                if (CalculateSum(nums, mid) > threshold)
                {
                    left = mid + 1; // Need a larger divisor
                }
                else
                {
                    right = mid; // Try for a smaller divisor
                }
            }
            return left; // The smallest divisor that meets the threshold condition
        }

        private int CalculateSum(int[] nums, int divisor)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += (num + divisor - 1) / divisor; // Equivalent to Math.Ceiling(num / divisor)
            }
            return sum;
        }
    }
}
