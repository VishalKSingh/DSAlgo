using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L452_MinimumNumberofArrowstoBurstBalloons
    {
        public L452_MinimumNumberofArrowstoBurstBalloons() { }

        public int FindMinArrowShots(int[][] points)
        {
            if (points == null || points.Length == 0) return 0; // If there are no balloons, we need 0 arrows
            // Sort the balloons based on their end coordinates
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
            int arrows = 1; // We need at least one arrow to burst the first balloon
            int currentEnd = points[0][1]; // The end coordinate of the first balloon
            for (int i = 1; i < points.Length; i++)
            {
                // If the start coordinate of the current balloon is greater than the end coordinate of the last burst balloon,
                // it means we need another arrow to burst this balloon
                if (points[i][0] > currentEnd)
                {
                    arrows++; // Increment the number of arrows needed
                    currentEnd = points[i][1]; // Update the end coordinate to the current balloon's end
                }
            }
            return arrows; // Return the total number of arrows needed to burst all balloons
        }

        // Time Complexity: O(n log n) due to sorting the points array.
        // Space Complexity: O(1) if we ignore the space used for sorting, otherwise O(n) due to the sorting algorithm's space complexity.

        // The greedy approach works because by sorting the balloons based on their end coordinates, we can always burst the balloon that ends the earliest with one arrow. This way, we maximize the chances of bursting multiple balloons with a single arrow. If the next balloon starts after the current end coordinate, it means we need another arrow to burst it, and we update our current end coordinate to the end of this new balloon.
        // This algorithm efficiently finds the minimum number of arrows needed to burst all balloons by leveraging the properties of intervals and a greedy strategy.
    }
}
