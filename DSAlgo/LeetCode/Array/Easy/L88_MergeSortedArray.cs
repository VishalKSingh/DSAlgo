using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L88_MergeSortedArray
    {
        // This problem is about merging two sorted arrays into one sorted array
        // The first array has enough space to hold the elements of both arrays
        // Time Complexity: O(m + n) where m is the length of the first array and n is the length of the second array
        // Space Complexity: O(1) since we are modifying the first array in place

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1; // Pointer for nums1
            int j = n - 1; // Pointer for nums2
            int k = m + n - 1; // Pointer for the merged array

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }

            while (j >= 0) // If there are remaining elements in nums2
            {
                nums1[k--] = nums2[j--];
            }
        }
    }
}
