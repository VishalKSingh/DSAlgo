using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    using System;
    internal class L787_CheapestFlightsWithinKStops
    {
        public L787_CheapestFlightsWithinKStops() { }
        // This problem is about finding the cheapest price for a flight from a source city to a destination city with at most K stops.
        // The function should return the cheapest price, or -1 if there is no such route.
        // Time Complexity: O(n * k) where n is the number of flights and k is the maximum number of stops
        // Space Complexity: O(n) for the DP array

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            // Create a DP array to store the minimum cost to reach each city with at most K stops
            int[] dp = new int[n];
            Array.Fill(dp, int.MaxValue);
            dp[src] = 0; // The cost to reach the source city is 0
            // Iterate K + 1 times to allow for up to K stops
            for (int i = 0; i <= K; i++)
            {
                // Create a temporary array to store the updated costs for this iteration
                int[] temp = new int[n];
                Array.Copy(dp, temp, n);
                // Update the costs based on the flights available
                foreach (var flight in flights)
                {
                    int u = flight[0]; // Source city
                    int v = flight[1]; // Destination city
                    int w = flight[2]; // Cost of the flight
                    if (dp[u] != int.MaxValue && dp[u] + w < temp[v])
                    {
                        temp[v] = dp[u] + w; // Update the cost to reach city v
                    }
                }
                dp = temp; // Update the DP array for the next iteration
            }
            return dp[dst] == int.MaxValue ? -1 : dp[dst]; // Return the cheapest price or -1 if unreachable
        }


        // Optimized version using a priority queue (Dijkstra's algorithm)
        public int FindCheapestPriceOptimized(int n, int[][] flights, int src, int dst, int K)
        {
            // Create an adjacency list to represent the graph
            // The graph will map each city to a list of (destination, cost) pairs
            // This allows us to efficiently look up the next cities and their costs when we are at a given city
            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();
            foreach (var flight in flights)
            {
                if (!graph.ContainsKey(flight[0]))
                {
                    graph[flight[0]] = new List<(int, int)>();
                }
                graph[flight[0]].Add((flight[1], flight[2])); // Add destination and cost
            }
            // Use a priority queue to store (cost, city, stops)
            var pq = new SortedSet<(int cost, int city, int stops)>();
            pq.Add((0, src, 0)); // Start with the source city
            while (pq.Count > 0)
            {
                var (cost, city, stops) = pq.Min; // Get the cheapest option
                pq.Remove(pq.Min); // Remove it from the queue
                if (city == dst) return cost; // If we reach the destination, return the cost
                if (stops > K) continue; // If we exceed the number of stops, skip
                // If the current city has outgoing flights, add them to the priority queue
                if (graph.ContainsKey(city))
                {
                    foreach (var (nextCity, nextCost) in graph[city])
                    {
                        pq.Add((cost + nextCost, nextCity, stops + 1)); // Add the next city to the queue
                    }
                }
            }
            return -1; // Return -1 if we cannot reach the destination within K stops
        }



        }
}
