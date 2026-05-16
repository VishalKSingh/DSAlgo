using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L207_CourseSchedule
    {
        // This problem is about determining if it's possible to finish all courses given prerequisites
        // It can be modeled as a directed graph where courses are nodes and prerequisites are directed edges
        // The problem can be solved using topological sorting or cycle detection in a directed graph
        // Time Complexity: O(V + E) where V is the number of vertices (courses) and E is the number of edges (prerequisites)
        // Space Complexity: O(V + E) for the adjacency list and visited set

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses]; // Initialize the graph as an adjacency list
            // Initialize the graph with empty lists for each course
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

            // Check for cycles in the directed graph using DFS
            for (int i = 0; i < numCourses; i++)
            {
                // If the node has not been visited, perform DFS to check for cycles
                if (!visited.Contains(i) && HasCycle(graph, i, visited, recStack))
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasCycle(List<int>[] graph, int node, HashSet<int> visited, HashSet<int> recStack)
        {
            if (recStack.Contains(node)) return true; // Cycle detected
            if (visited.Contains(node)) return false; // Already processed

            visited.Add(node); // Mark the node as visited
            recStack.Add(node); // Mark the node in the recursion stack

            // Traverse all neighbors of the current node
            foreach (var neighbor in graph[node])
            {
                if (HasCycle(graph, neighbor, visited, recStack))
                {
                    return true;
                }
            }

            recStack.Remove(node); // Remove from recursion stack after processing
            return false;
        }

        // Optimized version using Kahn's algorithm for topological sorting
        // Kahn's algorithm is an efficient way to perform topological sorting and can be used to determine if a cycle exists in the graph.
        public bool CanFinishOptimized(int numCourses, int[][] prerequisites)
        {
            //## Form Adjancency List and Indegree Array
            var indegree = new int[numCourses]; // number of prerequisites for each course
            var graph = new List<int>[numCourses]; // Initialize the graph as an adjacency list

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var prereq in prerequisites)
            {
                graph[prereq[1]].Add(prereq[0]); // Build the graph from the prerequisites
                indegree[prereq[0]]++; // Increment the indegree for the course that has a prerequisite
            }

            //## Initialize Queue with Courses that have No Prerequisites
            var queue = new Queue<int>(); // courses with no prerequisites (indegree of 0)
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i); // If a course has no prerequisites, add it to the queue
                }
            }

            //## Process the Queue and Count Completed Courses

            int count = 0; // Number of courses that can be completed
            while (queue.Count > 0)
            {
                var course = queue.Dequeue();// Dequeue a course with no prerequisites
                count++; // Increment the count of completed courses

                foreach (var neighbor in graph[course])
                {
                    indegree[neighbor]--; // Decrease the indegree of neighboring courses (courses that depend on the current course)
                    if (indegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor); // If a neighboring course has no remaining prerequisites, add it to the queue
                    }
                }
            }

            return count == numCourses; // If we processed all courses, return true
        }
    }
}
