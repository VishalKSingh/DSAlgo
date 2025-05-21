using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L_199_BinaryTreeRightSideView
    {
        // This problem is about finding the right side view of a binary tree
        // The right side view of a binary tree is the set of nodes visible when the tree is viewed from the right side
        // The BFS approach is used to traverse the tree level by level and collect the last node of each level
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(w) where w is the maximum width of the tree (number of nodes at any level)
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result; // If the tree is empty, return an empty list
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();

                    // If it's the last node in this level, add it to the result
                    if (i == levelSize - 1)
                    {
                        result.Add(currentNode.val);
                    }

                    // Enqueue left and right children
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
            }

            return result;
        }
    }
}
