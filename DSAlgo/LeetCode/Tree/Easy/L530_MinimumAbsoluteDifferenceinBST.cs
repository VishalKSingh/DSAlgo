using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L530_MinimumAbsoluteDifferenceinBST
    {
        // This problem is about finding the minimum absolute difference between values of any two nodes in a Binary Search Tree (BST)
        // The BST property ensures that for any node, all values in the left subtree are less than the node's value and all values in the right subtree are greater
        // The in-order traversal of a BST gives the values in sorted order
        // By comparing adjacent values in the sorted order, we can find the minimum absolute difference
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree (for recursion stack)
        public int GetMinimumDifference(TreeNode root)
        {
            List<int> values = new List<int>();
            InOrderTraversal(root, values);
            int minDiff = int.MaxValue;

            for (int i = 1; i < values.Count; i++)
            {
                minDiff = Math.Min(minDiff, Math.Abs(values[i] - values[i - 1]));
            }

            return minDiff;
        }

        private void InOrderTraversal(TreeNode node, List<int> values)
        {
            if (node == null) return;

            InOrderTraversal(node.left, values);
            values.Add(node.val);
            InOrderTraversal(node.right, values);
        }


    }
}
