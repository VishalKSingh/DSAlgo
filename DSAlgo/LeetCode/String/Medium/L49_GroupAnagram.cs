using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L49_GroupAnagram
    {
        public L49_GroupAnagram() { }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramGroups = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var sortedStr = string.Concat(str.OrderBy(c => c));
                if (!anagramGroups.ContainsKey(sortedStr))
                {
                    anagramGroups[sortedStr] = new List<string>();
                }
                anagramGroups[sortedStr].Add(str);
            }
            return anagramGroups.Values.ToList();
        }

        // Optimized Approach using Character Count as Key
        public IList<IList<string>> GroupAnagramsOptimized(string[] strs)
        {
            var anagramGroups = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var charCount = new char[26];
                foreach (var c in str)
                {
                    charCount[c - 'a']++;
                }
                var key = new string(charCount); // Create a unique key based on character count
                if (!anagramGroups.ContainsKey(key))
                {
                    anagramGroups[key] = new List<string>();
                }
                anagramGroups[key].Add(str);
            }
            return anagramGroups.Values.ToList();
        }
    }
}
