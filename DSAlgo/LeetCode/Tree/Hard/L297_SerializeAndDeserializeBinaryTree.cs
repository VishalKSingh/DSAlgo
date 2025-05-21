using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Hard
{
    internal class L297_SerializeAndDeserializeBinaryTree
    {
        public L297_SerializeAndDeserializeBinaryTree()
        {
            // This problem is about serializing and deserializing a binary tree
            // Serialization is the process of converting a data structure into a format that can be easily stored or transmitted
            // Deserialization is the reverse process of converting the serialized data back into the original data structure
            // The BFS approach is used to serialize and deserialize the binary tree
            // Time Complexity: O(n) where n is the number of nodes in the tree
            // Space Complexity: O(n) for storing the serialized data
        }
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "[]";
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    sb.Append("null,");
                }
                else
                {
                    sb.Append(node.val + ",");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            sb.Length--; // Remove the last comma
            sb.Append("]");
            return sb.ToString();
        }
        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "[]") return null;
            string[] nodes = data.Trim('[', ']').Split(',');
            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1; // Start from the second element
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue(); // Dequeue the front node

                if (i >= nodes.Length) break; // Check if we have processed all nodes
                // Check if the left child is not null
                if (nodes[i] != "null")
                {
                    node.left = new TreeNode(int.Parse(nodes[i]));
                    queue.Enqueue(node.left);
                }
                i++;
                // Check if the right child is not null
                if (nodes[i] != "null")
                {
                    node.right = new TreeNode(int.Parse(nodes[i]));
                    queue.Enqueue(node.right);
                }
                i++;
            }
            return root;
        }


    }


}
