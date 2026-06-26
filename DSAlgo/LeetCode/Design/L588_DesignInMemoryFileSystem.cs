using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L588_DesignInMemoryFileSystem
    {
        // Time Complexity: O(n) where n is the number of files and directories in the file system
        // Space Complexity: O(n) for storing the file system structure
        public L588_DesignInMemoryFileSystem() { }

        public class FileSystemNode
        {
            public bool IsFile { get; set; }
            public string Content { get; set; }
            public Dictionary<string, FileSystemNode> Children { get; set; }
            public FileSystemNode()
            {
                IsFile = false;
                Content = string.Empty;
                Children = new Dictionary<string, FileSystemNode>();
            }
        }

        public class FileSystem
        {
            private FileSystemNode root;
            public FileSystem()
            {
                root = new FileSystemNode();
            }
            public IList<string> Ls(string path)
            {
                var node = TraversePath(path);
                if (node.IsFile)
                {
                    return new List<string> { path.Split('/').Last() };
                }
                else
                {
                    return node.Children.Keys.OrderBy(k => k).ToList();
                }
            }
            public void Mkdir(string path)
            {
                TraversePath(path, createIfNotExist: true);
            }
            public void AddContentToFile(string filePath, string content)
            {
                var node = TraversePath(filePath, createIfNotExist: true);
                node.IsFile = true;
                node.Content += content;
            }
            public string ReadContentFromFile(string filePath)
            {
                var node = TraversePath(filePath);
                if (!node.IsFile)
                {
                    throw new InvalidOperationException("The specified path is not a file.");
                }
                return node.Content;
            }
            private FileSystemNode TraversePath(string path, bool createIfNotExist = false)
            {
                var parts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var currentNode = root;
                foreach (var part in parts)
                {
                    if (!currentNode.Children.ContainsKey(part))
                    {
                        if (createIfNotExist)
                        {
                            currentNode.Children[part] = new FileSystemNode();
                        }
                        else
                        {
                            throw new InvalidOperationException($"The specified path '{path}' does not exist.");
                        }
                    }
                    currentNode = currentNode.Children[part];
                }
                return currentNode;
            }
        }


    }
}
