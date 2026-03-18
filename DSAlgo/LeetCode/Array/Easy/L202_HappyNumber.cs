using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L202_HappyNumber
    {
        public L202_HappyNumber() { }
        public bool IsHappy(int n)
        {
            HashSet<int> seen = new HashSet<int>(); // To keep track of numbers we've seen to detect cycles
            while (n != 1 && !seen.Contains(n)) // Continue until we find 1 or detect a cycle
            {
                seen.Add(n); // Add the current number to the set of seen numbers
                n = GetNext(n); // Get the next number by summing the squares of its digits
            }
            return n == 1;
        }
        private int GetNext(int n)
        {
            int totalSum = 0;
            while (n > 0)
            {
                int d = n % 10;
                n /= 10;
                totalSum += d * d;
            }
            return totalSum;
        }

        //Optimized version using Floyd's Tortoise and Hare algorithm to detect cycles without extra space
        public bool IsHappyOptimized(int n)
        {
            int slow = n; // Tortoise
            int fast = GetNext(n); // Hare
            while (fast != 1 && slow != fast) // Continue until we find 1 or detect a cycle
            {
                slow = GetNext(slow); // Move slow by 1 step
                fast = GetNext(GetNext(fast)); // Move fast by 2 steps
            }
            return fast == 1; // If fast reaches 1, it's a happy number
        }
    }

}
