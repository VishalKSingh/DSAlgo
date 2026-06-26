using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L904FruitIntoBaskets
    {
        // Time Complexity: O(n), where n is the number of elements in the fruits array.
        // Space Complexity: O(1), as we are using a fixed-size dictionary to store the count of fruits.
        public int TotalFruit(int[] fruits)
        {
            int maxFruits = 0;
            int left = 0;
            // This dictionary will store the count of each type of fruit in the current window.
            Dictionary<int, int> fruitCount = new Dictionary<int, int>();
            // We will use a sliding window approach to find the longest subarray that contains at most 2 different types of fruits.
            for (int right = 0; right < fruits.Length; right++)
            {
                if (!fruitCount.ContainsKey(fruits[right]))
                {
                    fruitCount[fruits[right]] = 0;
                }
                fruitCount[fruits[right]]++;
                // If we have more than 2 types of fruits, we need to shrink the window from the left until we have at most 2 types.s
                while (fruitCount.Count > 2)
                {
                    fruitCount[fruits[left]]--;// Decrease the count of the fruit at the left pointer.
                    // If the count of that fruit becomes 0, we remove it from the dictionary.
                    if (fruitCount[fruits[left]] == 0)
                    {
                        fruitCount.Remove(fruits[left]);
                    }
                    left++;
                }
                maxFruits = Math.Max(maxFruits, right - left + 1); // Update the maximum number of fruits we can collect in the current window.
            }
            return maxFruits;
        }
    }
}
