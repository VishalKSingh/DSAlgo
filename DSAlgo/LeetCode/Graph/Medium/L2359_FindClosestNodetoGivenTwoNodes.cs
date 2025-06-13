namespace DSAlgo.LeetCode.Graph.Medium
{
    using System;
    internal class L2359_FindClosestNodetoGivenTwoNodes
    {
        // This problem is about finding the closest node to a given two nodes in a directed graph
        // The function should return the closest node to the given two nodes
        // Time Complexity: O(n) where n is the number of nodes in the graph
        // Space Complexity: O(n) for storing the graph and visited nodes

        public int FindClosestNode(int n, int[][] edges, int node1, int node2)
        {
            // Create a graph representation using an adjacency list
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            // Add edges to the graph
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
            }

            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            visited.Add(node1);
            visited.Add(node2);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                if (graph[currentNode].Count == 0) return currentNode;

                foreach (var neighbor in graph[currentNode])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return -1; // If no closest node found
        }

      
        // Another approach using DFS
        // This approach uses Depth First Search (DFS) to find the closest node to the given two nodes
        // Time Complexity: O(n) where n is the number of nodes in the graph
        // Space Complexity: O(n) for storing the graph and visited nodes
        public int FindClosestNodeDFS(int n, int[][] edges, int node1, int node2)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
            }

            var visited = new HashSet<int>();
            return DFS(graph, node1, node2, visited);
        }

        private int DFS(Dictionary<int, List<int>> graph, int currentNode, int targetNode, HashSet<int> visited)
        {
            if (currentNode == targetNode) return currentNode;
            if (visited.Contains(currentNode)) return -1;

            visited.Add(currentNode);
            foreach (var neighbor in graph[currentNode])
            {
                int result = DFS(graph, neighbor, targetNode, visited);
                if (result != -1) return result;
            }

            return -1; // If no closest node found
        }

        //Closest meeting node in a directed graph
        public int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            int n = edges.Length;
            int[] dist1 = new int[n];
            int[] dist2 = new int[n];

            Array.Fill(dist1, -1);
            Array.Fill(dist2, -1);

            BFS(edges, node1, dist1);
            BFS(edges, node2, dist2);

            int closestNode = -1;
            int minDistance = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (dist1[i] != -1 && dist2[i] != -1)
                {
                    int maxDist = Math.Max(dist1[i], dist2[i]);
                    if (maxDist < minDistance)
                    {
                        minDistance = maxDist;
                        closestNode = i;
                    }
                }
            }

            return closestNode;
        }
        private void BFS(int[] edges, int startNode, int[] distances)
        {
            int n = edges.Length;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            distances[startNode] = 0;

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                int nextNode = edges[currentNode];

                if (nextNode != -1 && distances[nextNode] == -1)
                {
                    distances[nextNode] = distances[currentNode] + 1;
                    queue.Enqueue(nextNode);
                }
            }
            // If the next node is -1, it means there is no outgoing edge from the current node
            // If the next node is already visited, we do not enqueue it again
        }

        // Another approach using DFS for Closest Meeting Node
        public int ClosestMeetingNodeDFS(int[] edges, int node1, int node2)
        {
            int n = edges.Length;
            int[] dist1 = new int[n]; // Distances from node1
            int[] dist2 = new int[n]; // Distances from node2

            Array.Fill(dist1, -1);
            Array.Fill(dist2, -1);

            // Perform DFS from both nodes to calculate distances
            DFS(edges, node1, dist1, 0);
            DFS(edges, node2, dist2, 0);

            // Find the closest meeting node
            int closestNode = -1;
            int minDistance = int.MaxValue;

            // Iterate through all nodes to find the closest meeting node
            for (int i = 0; i < n; i++)
            {
                // Check if both nodes have valid distances
                if (dist1[i] != -1 && dist2[i] != -1)
                {
                    // Calculate the maximum distance from both nodes to the current node
                    int maxDist = Math.Max(dist1[i], dist2[i]);
                    // Check if this is the closest node found so far
                    if (maxDist < minDistance)
                    {
                        minDistance = maxDist; // Update the minimum distance
                        closestNode = i; // Update the closest node
                    }
                }
            }

            return closestNode;
        }

        private void DFS(int[] edges, int currentNode, int[] distances, int currentDistance)
        {
            if (currentNode == -1 || distances[currentNode] != -1) return;

            distances[currentNode] = currentDistance;
            DFS(edges, edges[currentNode], distances, currentDistance + 1);
        }
    }
}
