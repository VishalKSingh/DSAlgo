using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L287_FindtheDuplicateNumber
    {
        // This problem is to find the duplicate number in an array containing n integers where each integer is between 1 and n (inclusive).
        // The approach uses the Floyd's Tortoise and Hare (Cycle Detection) algorithm.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(1) since we are using constant space

        public int FindDuplicate(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];

            // Phase 1: Finding the intersection point in the cycle
            do
            {
                slow = nums[slow]; // Move slow pointer by 1 step
                fast = nums[nums[fast]]; // Move fast pointer by 2 steps
            } while (slow != fast);

            // Phase 2: Finding the entrance to the cycle
            slow = nums[0];
            while (slow != fast)
            {
                slow = nums[slow]; // Move slow pointer by 1 step
                fast = nums[fast]; // Move fast pointer by 1 step
            }

            return slow; // The duplicate number
        }
    }
}
