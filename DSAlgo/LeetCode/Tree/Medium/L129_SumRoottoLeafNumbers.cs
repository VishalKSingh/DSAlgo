using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    public class L129_SumRoottoLeafNumbers
    {
        public L129_SumRoottoLeafNumbers()
        {
            // This problem is about calculating the sum of all numbers formed by root-to-leaf paths in a binary tree
            // Each path represents a number formed by concatenating the values of the nodes along the path
            // The recursive approach is used to traverse the tree and calculate the sum
            // Time Complexity: O(n) where n is the number of nodes in the tree
            // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        }
        public int SumNumbers(TreeNode root)
        {
            return SumNumbersHelper(root, 0);
        }
        private int SumNumbersHelper(TreeNode node, int currentSum)
        {
            if (node == null)
            {
                return 0; // Base case: if the node is null, return 0
            }

            currentSum = currentSum * 10 + node.val; // Update the current sum

            // If we are at a leaf node, return the current sum
            if (node.left == null && node.right == null)
            {
                return currentSum;
            }

            // Recursively calculate the sum for left and right subtrees
            return SumNumbersHelper(node.left, currentSum) + SumNumbersHelper(node.right, currentSum);
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
