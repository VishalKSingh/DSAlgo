using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Easy
{
    internal class L242ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }
            foreach (char c in t)
            {
                if (!charCount.ContainsKey(c)) return false;
                charCount[c]--;
                if (charCount[c] < 0) return false;
            }
            return true;
        }

        public bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] charCount = new int[26];
            foreach (char c in s)
            {
                charCount[c - 'a']++;
            }
            foreach (char c in t)
            {
                charCount[c - 'a']--;
                if (charCount[c - 'a'] < 0) return false;
            }
            return true;
        }
    }
}
