using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L187RepeatedDNASequences
    {
        // Time Complexity: O(n), where n is the length of the input string s. We iterate through the string once to extract all 10-letter-long sequences.
        // Space Complexity: O(n), where n is the number of unique 10-letter-long sequences. In the worst case, we may store all unique sequences in the HashSet.
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            HashSet<string> seen = new HashSet<string>();
            HashSet<string> repeated = new HashSet<string>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string sequence = s.Substring(i, 10);
                if (seen.Contains(sequence))
                {
                    repeated.Add(sequence);
                }
                else
                {
                    seen.Add(sequence);
                }
            }
            return repeated.ToList();
        }

        // Alternative approach using a dictionary to count occurrences
        // Time Complexity: O(n), where n is the length of the input string s. We iterate through the string once to extract all 10-letter-long sequences.
        // Space Complexity: O(n), where n is the number of unique 10-letter-long sequences. In the worst case, we may store all unique sequences in the dictionary.
        public IList<string> FindRepeatedDnaSequencesWithCount(string s)
        {
            Dictionary<string, int> sequenceCount = new Dictionary<string, int>();
            List<string> result = new List<string>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string sequence = s.Substring(i, 10);
                if (sequenceCount.ContainsKey(sequence))
                {
                    sequenceCount[sequence]++;
                    if (sequenceCount[sequence] == 2) // Only add to result when it appears the second time
                    {
                        result.Add(sequence);
                    }
                }
                else
                {
                    sequenceCount[sequence] = 1;
                }
            }
            return result;
        }
              
        
    }
}
