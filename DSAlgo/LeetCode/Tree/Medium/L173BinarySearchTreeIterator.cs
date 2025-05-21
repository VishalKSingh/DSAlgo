using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L173BinarySearchTreeIterator
    {
        // This problem is about implementing an iterator for a binary search tree (BST)
        // The iterator should return the next smallest number in the BST
        // The stack is used to keep track of the nodes in the BST
        // The constructor initializes the iterator with the root of the BST
        // The Next() method returns the next smallest number in the BST
        // The HasNext() method checks if there are more elements to iterate

        // Time Complexity: O(h) where h is the height of the tree for next() and hasNext()
        // Space Complexity: O(h) for the stack used to store nodes
        private Stack<TreeNode> stack;

        public L173BinarySearchTreeIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            PushLeft(root);
        }


        public int Next()
        {
            TreeNode node = stack.Pop(); // Pop the top node from the stack
            // Push all left children of the right child of the popped node onto the stack
            PushLeft(node.right);
            return node.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        // Push all left children of the given node onto the stack
        private void PushLeft(TreeNode node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
        }

        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
