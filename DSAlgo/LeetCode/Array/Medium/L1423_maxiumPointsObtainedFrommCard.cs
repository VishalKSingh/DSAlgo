using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1423_maxiumPointsObtainedFrommCard
    {
        // The idea is to use a sliding window approach. We will calculate the sum of the first k cards from the left and then
        // we will move the window from left to right, removing one card from the left and adding one card from the right until
        // we have considered all possible combinations of k cards.
        // Time Complexity: O(k) for the initial sum calculation and O(k) for the sliding window, resulting in O(k) overall.
        // Space Complexity: O(1) since we are using only a constant amount of extra space.
        public int MaxScore(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;
            int leftSum = 0, rightSum = 0;

            // Calculate the sum of the first k cards from the left
            for (int i=0; i < k; i++)
            {
                leftSum += cardPoints[i];
            }

            int maxScore = leftSum;
            int rightIndex = n - 1;

            // Now, we will move the window from left to right, removing one card from the left and adding one card from the right
            for (int j = k - 1; j >= 0; j--)
            {
                leftSum -= cardPoints[j]; // Remove the last card from the left sum
                rightSum += cardPoints[rightIndex]; // Add the next card from the right sum
                maxScore = Math.Max(maxScore, leftSum + rightSum); // Update max score
                rightIndex--; // Move the right index to the left
            }
            return maxScore;
        }
    }
}
