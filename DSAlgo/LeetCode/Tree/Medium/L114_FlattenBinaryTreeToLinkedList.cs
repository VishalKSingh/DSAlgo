using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    public class L114_FlattenBinaryTreeToLinkedList
    {
        // This problem is about flattening a binary tree to a linked list in-place
        // The flattened tree should follow the pre-order traversal of the original tree
        // The right child of each node should point to the next node in the pre-order traversal
        // The left child of each node should be set to null
        // The recursive approach is used to flatten the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return; // Base case: if the node is null, return
            }

            // Flatten the left and right subtrees
            Flatten(root.left);
            Flatten(root.right);

            // Store the right subtree
            TreeNode tempRight = root.right;

            // Move the left subtree to the right
            root.right = root.left;
            root.left = null; // Set left child to null

            // Find the last node of the new right subtree
            TreeNode current = root;
            while (current.right != null)
            {
                current = current.right;
            }

            // Attach the original right subtree to the end of the new right subtree
            current.right = tempRight;
        }

        // 

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
