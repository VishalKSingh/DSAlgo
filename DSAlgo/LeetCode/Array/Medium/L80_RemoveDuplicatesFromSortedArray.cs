using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L80_RemoveDuplicatesFromSortedArray
    {
        // This problem is about removing duplicates from a sorted array
        // The function should allow at most two occurrences of each element
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are modifying the array in place

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2) return nums.Length; // If the array has 2 or fewer elements, return its length

            int k = 2; // Pointer for the position to place the next valid element

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 2]) // Check if the current element is different from the element at k-2
                {
                    nums[k++] = nums[i]; // Place the valid element at position k and increment k
                }
            }

            return k; // Return the new length of the array
        }
    }
}
