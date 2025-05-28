using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L210__CourseScheduleII
    {
        // This problem is about finding the order of courses to take given prerequisites
        // It can be modeled as a directed graph where courses are nodes and prerequisites are directed edges
        // The problem can be solved using topological sorting
        // Time Complexity: O(V + E) where V is the number of vertices (courses) and E is the number of edges (prerequisites)
        // Space Complexity: O(V + E) for the adjacency list and visited set

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses]; // Initialize the graph as an adjacency list
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Build the graph from the prerequisites
            foreach (var prereq in prerequisites)
            {
                graph[prereq[1]].Add(prereq[0]);
            }

            var visited = new HashSet<int>(); // Set to keep track of visited nodes
            var recStack = new HashSet<int>(); // Set to keep track of nodes in the current recursion stack
            var result = new Stack<int>(); // Stack to store the topological order

            // Check for cycles in the directed graph using DFS
            for (int i = 0; i < numCourses; i++)
            {
                if (!visited.Contains(i) && HasCycle(graph, i, visited, recStack, result))
                {
                    return []; // Return empty array if a cycle is detected
                }
            }

            return result.ToArray(); // Convert stack to array and return
        }
        private bool HasCycle(List<int>[] graph, int node, HashSet<int> visited, HashSet<int> recStack, Stack<int> result)
        {
            if (recStack.Contains(node)) return true; // Cycle detected
            if (visited.Contains(node)) return false; // Already processed

            visited.Add(node); // Mark the node as visited
            recStack.Add(node); // Mark the node in the recursion stack

            // Traverse all neighbors of the current node
            foreach (var neighbor in graph[node])
            {
                if (HasCycle(graph, neighbor, visited, recStack, result))
                {
                    return true; // Cycle detected in the neighbor
                }
            }

            recStack.Remove(node); // Remove from recursion stack after processing
            result.Push(node); // Add to result stack for topological order
            return false; // No cycle detected
        }

        // optimized version using Kahn's algorithm
        public int[] FindOrderKahn(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            var inDegree = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Build the graph and calculate in-degrees
            foreach (var prereq in prerequisites)
            {
                graph[prereq[1]].Add(prereq[0]);
                inDegree[prereq[0]]++;
            }

            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i); // Add courses with no prerequisites to the queue
                }
            }

            var result = new List<int>();
            while (queue.Count > 0)
            {
                var course = queue.Dequeue();
                result.Add(course); // Add course to the result

                // Decrease in-degree of neighbors
                foreach (var neighbor in graph[course])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor); // If in-degree becomes zero, add to queue
                    }
                }
            }

            return result.Count == numCourses ? result.ToArray() : []; // Return result if all courses are taken, else empty array
        }
    }
}
