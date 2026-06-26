namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    using System;
    using System.Collections.Generic;

    public class CustomStack<T>
    {
        // The internal list used to store stack elements
        private readonly List<T> _storage = new List<T>();

        // Returns the number of elements in the stack
        public int Count => _storage.Count;

        // Checks if the stack is empty
        public bool IsEmpty => _storage.Count == 0;

        // Push: Adds an item to the top of the stack
        public void Push(T item)
        {
            // Adding to the end of a List is an O(1) operation on average
            _storage.Add(item);
        }

        // Pop: Removes and returns the item at the top of the stack
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty. Cannot pop.");
            }

            // Get the last element (top of the stack)
            int lastIndex = _storage.Count - 1;
            T poppedItem = _storage[lastIndex];

            // Remove it from the list
            _storage.RemoveAt(lastIndex);

            return poppedItem;
        }

        // Peek: Returns the item at the top of the stack without removing it
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty. Cannot peek.");
            }

            // Return the last element
            return _storage[_storage.Count - 1];
        }

        // Clear: Removes all elements from the stack
        public void Clear()
        {
            _storage.Clear();
        }
    }
}
