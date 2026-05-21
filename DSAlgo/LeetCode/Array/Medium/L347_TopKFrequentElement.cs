using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L347_TopKFrequentElement
    {
        public L347_TopKFrequentElement() { }

        // Use a min-heap to keep track of the top k elements
        // The heap will store pairs of (number, frequency) and will be ordered by frequency
        // Time Complexity: O(n log k) where n is the number of elements in the input array and k is the number of top frequent elements to return
        // Space Complexity: O(n) for the frequency map and O(k) for the heap
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }
            // Use a min-heap to keep track of the top k elements
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            foreach (var kvp in frequencyMap)
            {
                minHeap.Enqueue(kvp.Key, kvp.Value);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = minHeap.Dequeue();
            }
            return result;
        }

        // optimized approach using bucket sort




    }
}
