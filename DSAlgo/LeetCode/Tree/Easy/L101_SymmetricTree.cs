using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class L101_SymmetricTree
    {
        // This problem is about checking if a binary tree is symmetric
        // A binary tree is symmetric if the left subtree is a mirror reflection of the right subtree
        // The recursive approach is used to check if the two subtrees are mirror images of each other
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true; // An empty tree is symmetric
            }
            return IsMirror(root.left, root.right); // Check if left and right subtrees are mirrors
        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true; // Both subtrees are empty
            }
            if (left == null || right == null)
            {
                return false; // One subtree is empty and the other is not
            }
            return left.val == right.val && IsMirror(left.left, right.right) && IsMirror(left.right, right.left); // Check values and subtrees
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
