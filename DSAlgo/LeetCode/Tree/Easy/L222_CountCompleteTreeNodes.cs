using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class L222_CountCompleteTreeNodes
    {
        // This problem is about counting the number of nodes in a complete binary tree
        // A complete binary tree is a binary tree in which every level, except possibly the last, is completely filled
        // The last level has all nodes as far left as possible

        // The recursive approach is used to count the nodes
        // The idea is to calculate the height of the left and right subtrees
        // If the heights are equal, it means the left subtree is a full binary tree
        // If the heights are not equal, it means the right subtree is a full binary tree
        // The number of nodes in a complete binary tree can be calculated using the formula: 2^h - 1
        // where h is the height of the tree
        // The total number of nodes can be calculated as:
        // Total nodes = (2^leftHeight - 1) + (2^rightHeight - 1) + 1
        // where leftHeight is the height of the left subtree and rightHeight is the height of the right subtree

        // The approach used here is to calculate the height of the tree and use it to count the nodes
        // Time Complexity: O(log n * log n) where n is the number of nodes in the tree
        // Space Complexity: O(1) as we are using only a few variables
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0; // Base case: if the node is null, return 0
            }

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            if (leftHeight == rightHeight)
            {
                return (1 << leftHeight) + CountNodes(root.right); // Left subtree is full, count nodes in right subtree
            }
            else
            {
                return (1 << rightHeight) + CountNodes(root.left); // Right subtree is full, count nodes in left subtree
            }
        }

        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0; // Base case: if the node is null, return 0
            }
            return 1 + GetHeight(node.left); // Calculate height by traversing left subtree
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
