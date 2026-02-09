using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Easy
{
    internal class L232_QueueUsingStack
    {
        public L232_QueueUsingStack() { }

            private Stack<int> stack1 = new Stack<int>();
            private Stack<int> stack2 = new Stack<int>();
        private void TransferStack1ToStack2()
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }

        private void TransferStack2ToStack1()
        {
            while (stack2.Count > 0)
            {
                stack1.Push(stack2.Pop());
            }
        }


        public void Enqueue(int x)
        {
            TransferStack1ToStack2();
            // To enqueue an element, we simply push it onto stack1.
            stack1.Push(x);

            TransferStack2ToStack1();
        }

        public int Dequeue()
        {
            return stack1.Pop();
        }

        public int Peek()
        {
            return stack1.Peek();
        }

        public bool Empty()
        {
            // To check if the queue is empty, we check if both stacks are empty.
            return stack1.Count == 0 && stack2.Count == 0;
        }



    }
}
