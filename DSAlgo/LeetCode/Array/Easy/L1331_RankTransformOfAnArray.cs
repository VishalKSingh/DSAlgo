using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L1331_RankTransformOfAnArray
    {
        public L1331_RankTransformOfAnArray() { }
        // This problem is about transforming an array into its rank representation.
        // The rank of a number is its position in the sorted array of unique numbers.
        // The approach is to first create a sorted list of unique numbers from the input array, then create a dictionary to map each number to its rank, and finally transform the original array into its rank representation using the dictionary.

        // Time Complexity: O(n log n) due to sorting the unique numbers
        // Space Complexity: O(n) for the dictionary and the output array

        public int[] ArrayRankTransform(int[] arr)
        {
            // Create a sorted list of unique numbers from the input array
            var sortedUnique = arr.Distinct().OrderBy(x => x).ToList();
            // Create a dictionary to map each number to its rank
            var rankDict = new Dictionary<int, int>();
            for (int i = 0; i < sortedUnique.Count; i++)
            {
                rankDict[sortedUnique[i]] = i + 1; // Rank starts from 1
            }
            // Transform the original array into its rank representation using the dictionary
            var result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = rankDict[arr[i]];
            }
            return result;
        }

        // Optimized version using a single pass to create the rank dictionary
        //Time Complexity: O(n log n) due to sorting the unique numbers
        //Space Complexity: O(n) for the dictionary and the output array
        public int[] ArrayRankTransformOptimized(int[] arr)
        {
            // Create a sorted list of unique numbers from the input array
            var sortedUnique = arr.Distinct().OrderBy(x => x).ToList();
            // Create a dictionary to map each number to its rank using a single pass
            var rankDict = sortedUnique.Select((value, index) => new { value, index })
                                        .ToDictionary(x => x.value, x => x.index + 1); // Rank starts from 1
            // Transform the original array into its rank representation using the dictionary
            var result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = rankDict[arr[i]];
            }
            return result;
        }
    }
}
