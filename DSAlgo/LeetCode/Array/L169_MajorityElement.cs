﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L169_MajorityElement
    {
        /// This problem is about finding the majority element in an array
        // The majority element is the element that appears more than n/2 times in the array
        // The Boyer-Moore Voting Algorithm is used to find the majority element in linear time and constant space
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1) as we are using only a few variables
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            // Iterate through the array
            foreach (int num in nums)
            {
                // If count is 0, set the candidate to the current number
                if (count == 0)
                {
                    candidate = num;
                }

                // If the current number is the candidate, increment count
                // Otherwise, decrement count
                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }

    }
}
