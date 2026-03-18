using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L875_KokoEatingBananas
    {
        public L875_KokoEatingBananas() { }
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1; // Minimum possible speed
            int right = piles.Max(); // Maximum possible speed
            while (left < right)
            {
                int mid = left + (right - left) / 2; // Midpoint speed
                if (CalculateHours(piles, mid) > h)
                {
                    left = mid + 1; // Need a larger speed
                }
                else
                {
                    right = mid; // Try for a smaller speed
                }
            }
            return left; // The minimum speed that allows Koko to eat all bananas in h hours
        }
        private int CalculateHours(int[] piles, int speed)
        {
            int hours = 0;
            foreach (int pile in piles)
            {
                hours += (pile + speed - 1) / speed; // Equivalent to Math.Ceiling(pile / speed)
            }
            return hours;
        }
    }
}
