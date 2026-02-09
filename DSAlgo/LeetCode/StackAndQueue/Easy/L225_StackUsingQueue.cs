using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    internal class L225_StackUsingQueue
    {
        private Queue<int> queue;
        public L225_StackUsingQueue() {
            // Initialize your data structure here.
            queue = new Queue<int>();
        }

        public void Push(int x) {
            // To push an element onto the stack, we enqueue it to the queue and then rotate the queue to maintain the stack order.
            queue.Enqueue(x);
            int size = queue.Count;
            for (int i = 0; i < size - 1; i++) {
                queue.Enqueue(queue.Dequeue());
            }
        }

        public int Pop() {
            // To pop an element from the stack, we simply dequeue from the queue, which will give us the last pushed element.
            return queue.Dequeue();
        }

        public void Clear()
        {
            // Clear the stack by clearing the queue.
            queue.Clear();
        }

        public int Top()
        {
            // To get the top element of the stack, we peek at the front of the queue, which will give us the last pushed element.
            return queue.Peek();
        }

        public bool Empty()
        {
            // To check if the stack is empty, we check if the queue is empty.
            return queue.Count == 0;
        }


        }
}
