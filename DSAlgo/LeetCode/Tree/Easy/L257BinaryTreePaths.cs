using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L257BinaryTreePaths
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            if (root == null)
            {
                return paths; // If the root is null, return an empty list
            }
            
            DFS(root, "", paths); // Start DFS from the root with an empty path
            return paths;
        }

        // Helper function to perform DFS and build paths
        private void DFS(TreeNode node, string path, List<string> paths)
        {
            if (node == null)
            {
                return; // Base case: if the node is null, return
            }
            // Append the current node's value to the path
            path += node.val.ToString();
            // If it's a leaf node, add the path to the list
            if (node.left == null && node.right == null)
            {
                paths.Add(path);
            }
            else
            {
                // If not a leaf, continue DFS on left and right children
                path += "->"; // Add arrow for the next node
                DFS(node.left, path, paths);
                DFS(node.right, path, paths);
            }
        }
    }
}
