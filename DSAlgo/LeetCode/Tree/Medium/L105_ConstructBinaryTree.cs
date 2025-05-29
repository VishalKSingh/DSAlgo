
namespace DSAlgo.LeetCode.Tree.Medium
{
    using System;
    public class L105_ConstructBinaryTree
    {
        // This problem is about constructing a binary tree from its preorder and inorder traversal
        // The preorder traversal gives the root node first, followed by the left subtree and then the right subtree
        // The inorder traversal gives the left subtree first, followed by the root node and then the right subtree
        // The recursive approach is used to construct the binary tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0)
            {
                return null; // Base case: if either array is empty, return null
            }

            int rootValue = preorder[0]; // The first element of preorder is the root value
            TreeNode root = new TreeNode(rootValue); // Create a new node for the root

            int rootIndexInInorder = Array.IndexOf(inorder, rootValue); // Find the index of the root in inorder array

            // Recursively build the left and right subtrees
            root.left = BuildTree(preorder[1..(rootIndexInInorder + 1)], inorder[..rootIndexInInorder]);
            root.right = BuildTree(preorder[(rootIndexInInorder + 1)..], inorder[(rootIndexInInorder + 1)..]);

            return root; // Return the constructed tree
        }

        // Construct Binary Tree from Preorder and Inorder Traversal in optimal way
        public TreeNode BuildTreeOptimal(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexMap[inorder[i]] = i; // Store the index of each value in inorder array
            }

            return BuildTreeHelper(preorder, 0, preorder.Length - 1, inorderIndexMap, 0);
        }

        private TreeNode BuildTreeHelper(int[] preorder, int preorderStart, int preorderEnd, Dictionary<int, int> inorderIndexMap, int inorderStart)
        {
            if (preorderStart > preorderEnd)
            {
                return null; // Base case: if the start index is greater than the end index, return null
            }

            int rootValue = preorder[preorderStart]; // The first element of preorder is the root value
            TreeNode root = new TreeNode(rootValue); // Create a new node for the root

            int rootIndexInInorder = inorderIndexMap[rootValue]; // Get the index of the root in inorder array
            int leftSubtreeSize = rootIndexInInorder - inorderStart; // Calculate the size of the left subtree

            // Recursively build the left and right subtrees
            root.left = BuildTreeHelper(preorder, preorderStart + 1, preorderStart + leftSubtreeSize, inorderIndexMap, inorderStart);
            root.right = BuildTreeHelper(preorder, preorderStart + leftSubtreeSize + 1, preorderEnd, inorderIndexMap, rootIndexInInorder + 1);

            return root; // Return the constructed tree
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
