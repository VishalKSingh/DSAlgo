using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1011_CapacitytoShipPackagesinDDays
    {
        public L1011_CapacitytoShipPackagesinDDays() { }

        public int ShipWithinDays(int[] weights, int days)
        {
            int left = weights.Max(); // Minimum capacity must be at least the heaviest package
            int right = weights.Sum(); // Maximum capacity can be the sum of all packages
            while (left < right)
            {
                int mid = left + (right - left) / 2; // Midpoint capacity
                if (CanShip(weights, mid, days))
                {
                    right = mid; // Try for a smaller capacity
                }
                else
                {
                    left = mid + 1; // Need a larger capacity
                }
            }
            return left; // The minimum capacity needed to ship all packages within D days
        }

        public bool CanShip(int[] weights, int capacity, int days)
        {
            int currentLoad = 0; // Current load for the day
            int requiredDays = 1; // Start with the first day
            foreach (int weight in weights)
            {
                if (currentLoad + weight > capacity)
                {
                    requiredDays++; // Need an additional day
                    currentLoad = weight; // Start loading for the new day
                    if (requiredDays > days) // If we exceed the allowed days, return false
                    {
                        return false;
                    }
                }
                else
                {
                    currentLoad += weight; // Continue loading for the current day
                }
            }
            return true; // All packages can be shipped within the given days
        }
    }
}
