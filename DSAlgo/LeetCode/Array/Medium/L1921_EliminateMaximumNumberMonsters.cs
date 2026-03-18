using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L1921_EliminateMaximumNumberMonsters
    {
        public L1921_EliminateMaximumNumberMonsters() { }

        /// <summary>
        // You are playing a video game where you are defending your city from a group of monsters.
        // You are given a 0-indexed integer array dist, where dist[i] is the initial distance in meters of the ith monster from the city.
        // The monsters walk toward the city at a constant speed, and each monster moves 1 meter per second.
        // You have a weapon that can eliminate a single monster at the start of each second's end (i.e., at t = 0, t = 1, etc.).
        // You lose when any monster reaches your city (i.e., when the monster's distance from the city becomes 0).
        // Return the maximum number of monsters that you can eliminate before you lose.
        // 
        public int EliminateMaximum(int[] dist, int[] speed)
        {
            if (dist == null || speed == null || dist.Length != speed.Length)
            {
                return 0;
            }
            int n = dist.Length;
            double[] timeToReach = new double[n]; // Time for each monster to reach the city
            // Calculate the time for each monster to reach the city
            for (int i = 0; i < n; i++)
            {
                timeToReach[i] = (double)dist[i] / speed[i];
            }
            // Sort the time to reach in ascending order
            Array.Sort(timeToReach);
            int eliminated = 0;// Eliminate monsters in the order of their arrival time
            // If the time to reach is greater than the number of monsters already eliminated, we can eliminate this monster
            for (int i = 0; i < n; i++)
            {
                if (timeToReach[i] > eliminated)
                {
                    eliminated++;
                }
                else
                {
                    break;
                }
            }
            return eliminated;
        }

        // Time Complexity: O(n log n) due to sorting the timeToReach array.
        // Space Complexity: O(n) for the timeToReach array.

        //Optimization: We can optimize the space complexity to O(1) by calculating the time to reach on the fly while sorting the monsters based on their arrival time.
        //However, this would require a custom sorting mechanism and may not be as straightforward as using an additional array.



    }
}
