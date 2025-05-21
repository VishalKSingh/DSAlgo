using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class L100_SameTree
    {
        // This problem is about checking if two binary trees are the same
        // Two binary trees are considered the same if they are structurally identical and the nodes have the same value
        // The recursive approach is used to check if the two trees are the same
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public bool IsSameTree(TreeNode p, TreeNode q)
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
