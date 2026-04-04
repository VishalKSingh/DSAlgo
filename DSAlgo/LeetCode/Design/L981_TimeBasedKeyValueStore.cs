using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L981_TimeBasedKeyValueStore
    {
        // This problem is about designing a time-based key-value store that supports set and get operations with timestamps.
        // We can use a dictionary to store the key-value pairs, where the key is the string and the value is a list of tuples containing the timestamp and the corresponding value.
        private Dictionary<string, List<(int timestamp, string value)>> store;
        public L981_TimeBasedKeyValueStore() {
            store = new Dictionary<string, List<(int timestamp, string value)>>();

        }

        public void Set(string key, string value, int timestamp)
        {
            if (!store.ContainsKey(key))
            {
                store[key] = new List<(int timestamp, string value)>();
            }
            store[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!store.ContainsKey(key))
            {
                return string.Empty;
            }
            var values = store[key];
            // We can use binary search to find the value with the largest timestamp that is less than or equal to the given timestamp
            int left = 0, right = values.Count - 1;
            string result = string.Empty;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid].timestamp <= timestamp)
                {
                    result = values[mid].value; // Update result to the current value
                    left = mid + 1; // Move right to search for a potentially larger timestamp
                }
                else
                {
                    right = mid - 1; // Move left to search for smaller timestamps
                }
            }
            return result;
        }



    }
}
