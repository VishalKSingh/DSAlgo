using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L981_TimeBasedKeyValueStore
    {
        // This problem is to implement a time-based key-value store that allows setting values with timestamps and retrieving them based on the latest timestamp.
        // We can use a dictionary to store the key-value pairs along with their timestamps.
        // Time Complexity: O(log n) for set and get operations due to binary search
        // Space Complexity: O(n) for storing the key-value pairs

        private Dictionary<string, List<(int timestamp, string value)>> store;

        public L981_TimeBasedKeyValueStore()
        {
            // Initialize the store as a dictionary where each key maps to a list of tuples containing timestamp and value
            store = new Dictionary<string, List<(int timestamp, string value)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!store.ContainsKey(key))
            {
                store[key] = new List<(int, string)>();
            }
            store[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!store.ContainsKey(key)) return "";

            var values = store[key];
            int left = 0, right = values.Count - 1;

            // Perform binary search to find the latest value before or at the given timestamp
            // The list is assumed to be sorted by timestamp, so we can use binary search for efficiency
            // We are looking for the largest timestamp that is less than or equal to the given timestamp
            // If we find an exact match, we return that value
            // Otherwise, we return the value of the largest timestamp that is less than the given timestamp
            // Binary search to find the rightmost value with timestamp <= given timestamp
            // If no such value exists, return an empty string
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid].timestamp == timestamp)
                {
                    return values[mid].value;
                }
                else if (values[mid].timestamp < timestamp)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // If we reach here, it means the timestamp is not found, but we need the latest value before the given timestamp
            return right >= 0 ? values[right].value : "";
        }
    }
}
