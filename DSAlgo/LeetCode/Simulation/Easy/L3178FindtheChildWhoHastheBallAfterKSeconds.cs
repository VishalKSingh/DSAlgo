using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Simulation.Easy
{
    internal class L3178FindtheChildWhoHastheBallAfterKSeconds
    {
        public L3178FindtheChildWhoHastheBallAfterKSeconds() { }
        public int FindTheChild(int n, int k)
        {
            // The ball starts with child 0 and is passed to the next child in a circular manner.
            // We can use the modulo operator to determine which child has the ball after k seconds.
            return k % n; // The child who has the ball after k seconds is determined by k mod n
        }

        // Time Complexity: O(1) since we are performing a constant time operation to find the child with the ball.
        // Space Complexity: O(1) since we are using a constant amount of space to store the result.


    }
}
