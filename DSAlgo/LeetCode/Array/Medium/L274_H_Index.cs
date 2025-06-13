namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L274_H_Index
    {
        // This problem is about finding the H-Index of a researcher
        // The function should return the H-Index based on the given citations
        // Time Complexity: O(n log n) where n is the number of citations
        // Space Complexity: O(1) since we are using a constant amount of space

        public int HIndex(int[] citations)
        {
            Array.Sort(citations); // Sort the citations in ascending order
            int n = citations.Length;

            for (int i = 0; i < n; i++)
            {
                if (citations[i] >= n - i) // Check if the current citation is greater than or equal to the number of papers with at least that many citations
                {
                    return n - i; // Return the H-Index
                }
            }

            return 0; // If no H-Index found, return 0
        }

        // Another approach using binary search
        public int HIndexBinarySearch(int[] citations)
        {
            Array.Sort(citations); // Sort the citations in ascending order
            int n = citations.Length;
            int left = 0, right = n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Find the middle index
                if (citations[mid] >= n - mid) // Check if the current citation is greater than or equal to the number of papers with at least that many citations
                {
                    right = mid - 1; // Move to the left half
                }
                else
                {
                    left = mid + 1; // Move to the right half
                }
            }

            return n - left; // Return the H-Index
        }

        // Another approach using a counting sort-like technique
        // This approach counts the number of citations and calculates the H-Index in linear time
        // Time Complexity: O(n) where n is the number of citations
        // Space Complexity: O(n) for the count array
        public int HIndexCountingSort(int[] citations)
        {
            int n = citations.Length;
            int[] count = new int[n + 1];

            // Count the number of citations
            for (int i = 0; i < n; i++)
            {
                if (citations[i] >= n) count[n]++;
                else count[citations[i]]++;
            }

            // Calculate the H-Index
            int total = 0;
            for (int i = n; i >= 0; i--)
            {
                total += count[i];
                if (total >= i) return i; // If the total number of papers with at least i citations is greater than or equal to i, return i
            }

            return 0; // If no H-Index found, return 0
        }
    }
}
