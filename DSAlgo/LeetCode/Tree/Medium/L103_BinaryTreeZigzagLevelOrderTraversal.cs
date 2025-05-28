using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L103_BinaryTreeZigzagLevelOrderTraversal
    {
        // This problem is about traversing a binary tree in a zigzag level order
        // The zigzag level order means that the nodes at each level are traversed from left to right for even levels and from right to left for odd levels
        // The BFS approach is used to traverse the tree level by level
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(w) where w is the maximum width of the tree (number of nodes at any level)
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>(); // List to store the final zigzag order
            if (root == null) return result; // If the tree is empty, return an empty list

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool leftToRight = true; // Flag to indicate the direction of traversal

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (leftToRight)
                    {
                        currentLevel.Add(node.val); // Add node value to the current level list
                    }
                    else
                    {
                        currentLevel.Insert(0, node.val); // Insert node value at the beginning for reverse order
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left); // Enqueue left child
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right); // Enqueue right child
                    }
                }

                result.Add(currentLevel); // Add current level to the result list
                leftToRight = !leftToRight; // Toggle the direction for next level
            }

            return result; // Return the final zigzag order list
        }
    }
}
