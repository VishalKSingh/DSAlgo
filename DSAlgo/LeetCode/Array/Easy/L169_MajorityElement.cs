using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L169_MajorityElement
    {
        /// This problem is about finding the majority element in an array
        // The majority element is the element that appears more than n/2 times in the array

        // The Boyer-Moore Voting Algorithm is used to find the majority element in linear time and constant space
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1) as we are using only a few variables
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            // Iterate through the array
            foreach (int num in nums)
            {
                // If count is 0, set the candidate to the current number
                if (count == 0)
                {
                    candidate = num;
                }

                // If the current number is the candidate, increment count
                // Otherwise, decrement count
                if (num == candidate) 
                {
                    count++;
                } else {
                    count--;
                }
            }

            return candidate;
        }
        // Brute force approach is to use a hash map to count the frequency of each element in the array
        public int MajorityElementHashMap(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            int n = nums.Length;

            foreach (int num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic[num] = 1;
                }
                else
                {
                    dic[num]++;
                }

                if (dic[num] > n / 2) return num;
            }
            return -1;
        }

    }
}
