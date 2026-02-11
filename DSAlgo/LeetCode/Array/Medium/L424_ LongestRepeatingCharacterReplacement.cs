using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L424__LongestRepeatingCharacterReplacement
    {
        public int CharacterReplacement(string s, int k)
        {
            int left = 0, maxLength = 0, right = 0, maxCount = 0;
            int[] charCount = new int[26];
            while (right < s.Length)
            {
                charCount[s[right] - 'A']++;
                maxCount = Math.Max(maxCount, charCount[s[right] - 'A']);
                if (right - left + 1 - maxCount > k)
                {
                    charCount[s[left] - 'A']--;
                    left++;
                }
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            return maxLength;
        }

        // Brute Force Approach
        public int CharacterReplacementBruteForce(string s, int k)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int[] charCount = new int[26];
                int maxCount = 0;
                for (int j = i; j < s.Length; j++)
                {
                    charCount[s[j] - 'A']++;
                    maxCount = Math.Max(maxCount, charCount[s[j] - 'A']);

                    // The idea is to count the frequency of each character in the current window and keep track of the maximum frequency (maxCount).
                    // If the length of the current window minus maxCount is greater than k, it means we need to replace more than k characters to
                    // make all characters in the window the same, so we break out of the inner loop.
                    if (j - i + 1 - maxCount > k)
                    {
                        break;
                    }
                    maxLength = Math.Max(maxLength, j - i + 1);
                }
            }
            return maxLength;
        }
}
