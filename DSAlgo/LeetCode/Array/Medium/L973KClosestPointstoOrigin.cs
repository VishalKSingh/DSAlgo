using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L973KClosestPointstoOrigin
    {
        // This problem is about finding the k closest points to the origin (0, 0) in a 2D plane.
        // The function should return the k closest points based on their distance from the origin.
        // Time Complexity: O(n log k) where n is the number of points, because we maintain a max heap of size k.
        // Space Complexity: O(k) for the heap that stores the closest points.
        public int[][] KClosest(int[][] points, int k)
        {
            // Use a max heap to keep track of the k closest points
            // We can use a PriorityQueue in C# to implement the max heap. The priority will be the distance from the origin.
            // The comparer for the max heap will compare the distances, and we will keep the farthest point at the top of the heap.
            // We will iterate through the list of points, calculate their distance from the origin, and add them to the heap.
            PriorityQueue<int[], double> maxHeap = new PriorityQueue<int[], double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));
            foreach (var point in points)
            {
                double distance = Math.Sqrt(point[0] * point[0] + point[1] * point[1]); // Calculate distance from origin
                maxHeap.Enqueue(point, distance); // Add point to the heap with its distance as priority
                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue(); // Remove the farthest point if we have more than k points in the heap
                }
            }
            return maxHeap.UnorderedItems.Select(item => item.Element).ToArray(); // Return the k closest points
        }
    }
}
