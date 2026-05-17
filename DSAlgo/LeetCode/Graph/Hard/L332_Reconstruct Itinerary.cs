using DSAlgo.LeetCode.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Hard
{
    internal class L332_Reconstruct_Itinerary
    {
        // This problem is about reconstructing an itinerary from a list of airline tickets, where each ticket represents a flight from
        // a departure airport to an arrival airport
        // The problem can be solved using Depth-First Search (DFS) to explore all possible itineraries and backtracking to find the
        // valid itinerary that uses all tickets
        
        public L332_Reconstruct_Itinerary() { }
       
         public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var graph = new Dictionary<string, List<string>>();
            foreach (var ticket in tickets)
            {
                if (!graph.ContainsKey(ticket[0]))
                {
                    graph[ticket[0]] = new List<string>();
                }
                graph[ticket[0]].Add(ticket[1]);
            }
            // Sort the destinations for each departure airport to ensure we get the lexicographically smallest itinerary
            foreach (var key in graph.Keys)
            {
                graph[key].Sort();
            }
            var result = new List<string>();
            DFS("JFK", graph, result);
            result.Reverse(); // Reverse the result to get the correct order
            return result;
        }

        public void DFS(string airport, Dictionary<string, List<string>> graph, List<string> result)
        {
            while (graph.ContainsKey(airport) && graph[airport].Count > 0)
            {
                var nextAirport = graph[airport][0]; // Get the next destination
                graph[airport].RemoveAt(0); // Remove the used ticket
                DFS(nextAirport, graph, result); // Continue DFS with the next airport
            }
            result.Add(airport); // Add the airport to the result after exploring all destinations
        }
    }
}
