using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L743_NetworkDelayTime
    {
        // This problem is about finding the time it takes for all nodes in a network to receive a signal from a starting node
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // Build the graph as an adjacency list
            var graph = new Dictionary<int, List<(int neighbor, int time)>>();
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int neighbor, int time)>();
            }
            foreach (var time in times)
            {
                graph[time[0]].Add((time[1], time[2]));
            }
            // Dijkstra's algorithm to find the shortest path from node k to all other nodes
            var minHeap = new SortedSet<(int time, int node)>();
            minHeap.Add((0, k)); // (time, node)
            // Initialize distances to all nodes as infinity, except for the starting node k
            var dist = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[k] = 0;
            while (minHeap.Count > 0)
            {
                var (currTime, currNode) = minHeap.Min;
                minHeap.Remove(minHeap.Min);
                foreach (var (neighbor, time) in graph[currNode])
                {
                    // If the time to reach the neighbor through the current node is less than the previously known time, update it
                    if (currTime + time < dist[neighbor])
                    {
                        minHeap.Remove((dist[neighbor], neighbor)); // Remove old entry if it exists
                        dist[neighbor] = currTime + time;
                        minHeap.Add((dist[neighbor], neighbor)); // Add updated entry
                    }
                }
            }
            // Find the maximum time it takes for all nodes to receive the signal
            int maxTime = dist.Values.Max();
            return maxTime == int.MaxValue ? -1 : maxTime;
        }

        // using priority queue (min-heap) for Dijkstra's algorithm
        public int NetworkDelayTime_PriorityQueue(int[][] times, int n, int k)
        {
            var graph = new Dictionary<int, List<(int neighbor, int time)>>();
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int neighbor, int time)>();
            }
            foreach (var time in times)
            {
                graph[time[0]].Add((time[1], time[2]));
            }
            var pq = new PriorityQueue<(int node, int time), int>();
            pq.Enqueue((k, 0), 0); // (node, time)
            var dist = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[k] = 0;
            while (pq.Count > 0)
            {
                var (currNode, currTime) = pq.Dequeue();
                foreach (var (neighbor, time) in graph[currNode])
                {
                    if (currTime + time < dist[neighbor])
                    {
                        dist[neighbor] = currTime + time;
                        pq.Enqueue((neighbor, dist[neighbor]), dist[neighbor]);
                    }
                }
            }
            int maxTime = dist.Values.Max();
            return maxTime == int.MaxValue ? -1 : maxTime;
        }
    }
}
