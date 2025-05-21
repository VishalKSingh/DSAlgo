using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    public class L106_ConstructBinaryTree
    {
        public L106_ConstructBinaryTree() { }
        // This problem is about constructing a binary tree from its inorder and postorder traversals
        // The recursive approach is used to construct the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 || postorder.Length == 0)
            {
                return null; // Base case: if either array is empty, return null
            }

            // Create a dictionary to store the indices of inorder elements for quick lookup
            Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexMap[inorder[i]] = i;
            }

            return BuildTreeHelper(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1, inorderIndexMap);
        }

        private TreeNode BuildTreeHelper(int[] inorder, int[] postorder, int inorderStart, int inorderEnd, int postorderStart, int postorderEnd, Dictionary<int, int> inorderIndexMap)
        {
            if (inorderStart > inorderEnd || postorderStart > postorderEnd)
            {
                return null; // Base case: if the start index is greater than the end index, return null
            }

            int rootValue = postorder[postorderEnd]; // The last element of postorder is the root value
            TreeNode root = new TreeNode(rootValue); // Create a new node for the root

            int rootIndexInInorder = inorderIndexMap[rootValue]; // Get the index of the root in inorder array
            int leftSubtreeSize = rootIndexInInorder - inorderStart; // Calculate the size of the left subtree

            // Recursively build the left and right subtrees
            root.left = BuildTreeHelper(inorder, postorder, inorderStart, rootIndexInInorder - 1, postorderStart, postorderStart + leftSubtreeSize - 1, inorderIndexMap);
            root.right = BuildTreeHelper(inorder, postorder, rootIndexInInorder + 1, inorderEnd, postorderStart + leftSubtreeSize, postorderEnd - 1, inorderIndexMap);

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
