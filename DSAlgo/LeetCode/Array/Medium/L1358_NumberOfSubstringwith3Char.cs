using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L1358_NumberOfSubstringwith3Char
    {
        public int NumberOfSubstringsOptimized(string s)
        {
            int count = 0;
            int[] ch = new int[] { -1, -1, -1 };

            for (int i = 0; i < s.Length; i++)
            {
                ch[s[i] - 'a'] = i;
                count += Math.Min(ch[0], Math.Min(ch[1], ch[2])) + 1;
            }
            return count;
        }
        public int NumberOfSubstrings(string s)
        {
            int count = 0;
            int[] charCount = new int[3]; // To count 'a', 'b', and 'c'
            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                charCount[s[right] - 'a']++; // Increment the count of the current character
                // Check if we have at least one of each character
                while (charCount[0] > 0 && charCount[1] > 0 && charCount[2] > 0)
                {
                    count += s.Length - right; // All substrings starting from left to the end of the string are valid
                    charCount[s[left] - 'a']--; // Decrement the count of the left character
                    left++; // Move the left pointer to the right
                }
            }
            return count;
        }

        // Brute Force Approach
        public int NumberOfSubstringsBruteForce(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> uniqueChars = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    uniqueChars.Add(s[j]);
                    if (uniqueChars.Count == 3) // Check if we have all three characters
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // Optimized Approach using Sliding Window


    }
}
