using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L637_AverageOfLevelsInBinaryTree
    {
        // This problem is about finding the average value of nodes on each level of a binary tree
        // The average value is calculated by summing the values of all nodes at a level and dividing by the number of nodes at that level
        // The BFS approach is used to traverse the tree level by level
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(w) where w is the maximum width of the tree (number of nodes at any level)
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> averages = new List<double>();// List to store the average values of each level
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                double sum = 0; // Sum of values at the current level

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                averages.Add(sum / levelSize);
            }

            return averages;
        }
    }
}
