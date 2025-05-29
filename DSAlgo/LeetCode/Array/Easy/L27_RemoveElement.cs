using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L27_RemoveElement
    {
        // This problem is about removing all instances of a given value from an array in-place
        // The function should return the new length of the array after removal
        // Time Complexity: O(n) where n is the length of the array
        // Space Complexity: O(1) since we are modifying the array in place

        public int RemoveElement(int[] nums, int val)
        {
            int k = 0; // Pointer for the position to place the next non-val element

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k++] = nums[i]; // Place the non-val element at position k and increment k
                }
            }

            return k; // Return the new length of the array
        }
    }
}
