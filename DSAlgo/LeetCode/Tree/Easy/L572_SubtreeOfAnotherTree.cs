using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L572_SubtreeOfAnotherTree
    {
        // This problem is about checking if one binary tree is a subtree of another binary tree
        // A subtree of a binary tree is a tree that consists of a node in the original tree and all of its descendants
        // The recursive approach is used to check if one tree is a subtree of another
        // Time Complexity: O(n * m) where n is the number of nodes in the first tree and m is the number of nodes in the second tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
            {
                return false; // If the main tree is empty, it cannot contain any subtrees
            }
            if (IsSameTree(root, subRoot))
            {
                return true; // If the trees are the same, return true
            }
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot); // Check left and right subtrees
        }

        private bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true; // Both trees are empty
            }
            if (p == null || q == null)
            {
                return false; // One tree is empty and the other is not
            }
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right); // Check values and subtrees
        }
    }
}
