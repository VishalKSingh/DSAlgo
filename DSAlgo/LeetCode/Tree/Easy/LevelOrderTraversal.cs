using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class LevelOrderTraversal
    {
        // This problem is about traversing a binary tree in level order
        // Level order traversal means visiting all nodes at the present depth level before moving on to the nodes at the next depth level
        // The iterative approach using a queue is used to traverse the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(n) where n is the number of nodes in the tree due to the queue
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root); // Start with the root node

            // Perform level order traversal
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();// Dequeue the front node
                    currentLevel.Add(currentNode.val); // Add the value to the current level list

                    // Enqueue the left and right children of the current node
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                result.Add(currentLevel);
            }

            return result;
        }
    }
}
