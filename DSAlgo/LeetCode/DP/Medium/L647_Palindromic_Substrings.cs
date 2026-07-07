using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L647_Palindromic_Substrings
    {
        // Brute force approach
        // Time complexity: O(n^3)
        // Space complexity: O(1)
        public int CountSubstringsBruteForce(string s)
        {
            int n = s.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (IsPalindrome(s, i, j))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public int CountSubstrings(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n]; // dp[i, j] will be true if s[i..j] is a palindrome
            int count = 0;
            // All substrings of length 1 are palindromes
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    // Check if the substring s[i..j] is a palindrome
                    if (s[i] == s[j] && (j - i < 3 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                        count++;
                    }
                }
            }
            return count;
        }

        // Another approach using expand around center
        // Time complexity: O(n^2)
        // Space complexity: O(1)
        public int CountSubstringsExpandAroundCenter(string s)
        {
            int n = s.Length;
            int count = 0;
            // There are 2n - 1 centers for palindromes (n single character centers and n-1 between character centers)
            for (int center = 0; center < 2 * n - 1; center++)
            {
                int left = center / 2; // left index of the palindrome
                int right = left + center % 2; // right index of the palindrome
                while (left >= 0 && right < n && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }
            return count;
        }

        // Another approach using Manacher's algorithm
        // Time complexity: O(n)
        // Space complexity: O(n)
        public int CountSubstringsManacher(string s)
        {
            // Transform s into t with separators to handle even length palindromes
            string t = "^#" + string.Join("#", s.ToCharArray()) + "#$";
            int n = t.Length;
            int[] p = new int[n]; // Array to store the radius of palindromes centered at each character
            int center = 0, right = 0; // Current center and right edge of the palindrome
            for (int i = 1; i < n - 1; i++)
            {
                int mirror = 2 * center - i; // Mirror index of i around center
                if (right > i)
                {
                    p[i] = Math.Min(right - i, p[mirror]);
                }
                // Expand around center i
                while (t[i + (1 + p[i])] == t[i - (1 + p[i])])
                {
                    p[i]++;
                }
                // Update center and right edge if the palindrome expanded past right
                if (i + p[i] > right)
                {
                    center = i;
                    right = i + p[i];
                }
            }
            // Count the number of palindromic substrings
            return p.Sum(x => (x + 1) / 2);
        }

        
    }
}
