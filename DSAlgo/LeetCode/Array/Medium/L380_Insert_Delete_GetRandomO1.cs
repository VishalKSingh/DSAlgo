namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L380_Insert_Delete_GetRandomO1
    {
        public class RandomizedSet
        {
            private List<int> _list;
            private Dictionary<int, int> _dict;
            private Random _random;

            public RandomizedSet()
            {
                _list = new List<int>();
                _dict = new Dictionary<int, int>();
                _random = new Random();
            }

            public bool Insert(int val)
            {
                if (_dict.ContainsKey(val))
                {
                    return false; // Value already exists
                }
            _dict[val] = _list.Count; // Store the index of the value
                _list.Add(val); // Add the value to the list
                return true;
            }

            public bool Remove(int val)
            {
                if (!_dict.ContainsKey(val))
                {
                    return false; // Value does not exist
                }
                int index = _dict[val]; // Get the index of the value to be removed
                int lastValue = _list[_list.Count - 1]; // Get the last value in the list

            // Move the last value to the place of the value to be removed
            _list[index] = lastValue;
            _dict[lastValue] = index; // Update the index of the last value

                // Remove the last element from the list and dictionary
                _list.RemoveAt(_list.Count - 1);
                _dict.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                return _list[_random.Next(_list.Count)]; // Return a random element from the list
            }
        }

        // Example usage:
        // RandomizedSet randomizedSet = new RandomizedSet();
        // randomizedSet.Insert(1); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
        // randomizedSet.Remove(2); // Returns false as 2 does not exist in the set.
        // randomizedSet.Insert(2); // Inserts 2 to the set, returns true. Set now contains [1, 2].
        // randomizedSet.GetRandom(); // Get a random element from the set. Each element must have the same probability of being returned.
        // randomizedSet.Remove(1); // Removes 1 from the set, returns true. Set now contains [2].
        // randomizedSet.Insert(2); // Returns false as 2 is already in the set.
        // randomizedSet.GetRandom(); // Since 2 is the only number in the set, it will always return 2.

    }
}
