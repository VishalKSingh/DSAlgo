using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class L226_InvertBinaryTree
    {
        // This problem is about inverting a binary tree
        // Inverting a binary tree means swapping the left and right children of all nodes in the tree
        // The recursive approach is used to invert the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null; // Base case: if the node is null, return null
            }

            // Swap the left and right children
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            // Recursively invert the left and right subtrees
            InvertTree(root.left);
            InvertTree(root.right);

            return root; // Return the inverted tree
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
