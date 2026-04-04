using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    internal class L4_MedianOfTwoSortedArray
    {
        // Time Complexity: O(log(min(m, n))) where m and n are the lengths of the two input arrays. This is because we are performing a binary search on the smaller array.
        // Space Complexity: O(1) since we are using only a constant amount of extra space for variables.

        public L4_MedianOfTwoSortedArray() { }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller array to optimize the binary search
            if (nums1.Length > nums2.Length)
                return FindMedianSortedArrays(nums2, nums1);
            int m = nums1.Length;
            int n = nums2.Length;
            int low = 0, high = m;
            while (low <= high)
            {
                int partitionX = (low + high) / 2; // Partition index for nums1
                int partitionY = (m + n + 1) / 2 - partitionX; // Partition index for nums2
                // If partitionX is 0 it means nothing is there on left side. Use -INF for maxLeftX
                // If partitionX is length of input then there is nothing on right side. Use +INF for minRightX
                int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minRightX = (partitionX == m) ? int.MaxValue : nums1[partitionX];
                // Similarly for partitionY
                int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minRightY = (partitionY == n) ? int.MaxValue : nums2[partitionY];
                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    // We have partitioned the array correctly
                    if ((m + n) % 2 == 0)
                        return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    else
                        return (double)Math.Max(maxLeftX, maxLeftY);
                }
                else if (maxLeftX > minRightY)
                {
                    // We are too far on the right side for partitionX. Go on the left side.
                    high = partitionX - 1;
                }
                else
                {
                    // We are too far on the left side for partitionX. Go on the right side.
                    low = partitionX + 1;
                }
            }
            throw new ArgumentException("Input arrays are not sorted.");
        }

    }
}
