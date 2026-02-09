using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Medium
{
    internal class L155_MinStack
    {
        public L155_MinStack() { }

        private Stack<int> stack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();
        public void Push(int x)
        {
            stack.Push(x);

            if(minStack.Count == 0 || x <= minStack.Peek())
            {
                minStack.Push(x);
            }
        }

        public void Pop()
        {
            // To pop an element from the stack, we simply pop the top element. If the popped element is the current minimum, we pop again to remove the duplicate minimum value.
            int top = stack.Pop();
            if (top == GetMin())
            {
                minStack.Pop();
            }

        }

        public int Top()
        {
            // To get the top element of the stack, we peek at the top of the stack.
            return stack.Peek();
        }

        public int GetMin()
        {
            // To get the minimum element in the stack, we peek at the top of the stack, which will give us the current minimum value.
            return minStack.Peek();
        }
    }
}
