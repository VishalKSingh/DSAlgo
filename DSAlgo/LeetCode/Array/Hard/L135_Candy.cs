namespace DSAlgo.LeetCode.Array.Hard
{
    using System;
    internal class L135_Candy
    {
        // This problem is to distribute candies to children such that each child has at least one candy,
        // and children with a higher rating than their neighbors receive more candies.
        // The approach is to use two passes: one from left to right and another from right to left.
        // Time Complexity: O(n) where n is the number of children
        // Space Complexity: O(n) for the candies array

        public int Candy(int[] ratings)
        {
            int n = ratings.Length;
            if (n == 0) return 0;

            int[] candies = new int[n];
            Array.Fill(candies, 1); // Start by giving each child one candy

            // First pass: left to right
            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1; // Give more candy than the previous child
                }
            }

            // Second pass: right to left
            for (int i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1); // Ensure the current child has more than the next child
                }
            }

            return candies.Sum(); // Return the total number of candies distributed
        }

        // Optimzed version without using extra space
        // This version uses two counters to track the number of increasing and decreasing sequences
        // and calculates the total candies in a single pass.
        // Time Complexity: O(n)
        // Space Complexity: O(1) since we are not using any extra space for candies array
        public int CandyOptimized(int[] ratings)
        {
            int n = ratings.Length;
            if (n == 0) return 0;

            int totalCandies = 0;
            int up = 0, down = 0;

            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    up++;
                    down = 0;
                    totalCandies += up + 1; // +1 for the current child
                }
                else if (ratings[i] < ratings[i - 1])
                {
                    down++;
                    up = 0;
                    totalCandies += down + 1; // +1 for the current child
                }
                else
                {
                    totalCandies += Math.Max(up, down) + 1; // Reset both counters
                    up = down = 0;
                }
            }

            return totalCandies;
        }

    }
}
