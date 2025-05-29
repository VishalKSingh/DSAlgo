using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L26_RemoveDuplicatesFromSortedArray
    {
        // This problem is about removing duplicates from a sorted array in-place
        // The function should return the new length of the array after removing duplicates
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are modifying the array in place

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0; // If the array is empty, return 0

            int k = 1; // Pointer for the position to place the next unique element

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 1]) // Check if the current element is different from the last unique element
                {
                    nums[k++] = nums[i]; // Place the unique element at position k and increment k
                }
            }

            return k; // Return the new length of the array
        }
    }
}
