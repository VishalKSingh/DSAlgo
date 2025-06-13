using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L134_GasStation
    {
        // This problem is to find the starting gas station index from which we can complete a circuit
        // given an array of gas stations and the amount of gas available at each station.
        // The approach is to use a greedy algorithm to find the starting index.
        // Time Complexity: O(n) where n is the number of gas stations
        // Space Complexity: O(1) since we are using constant space

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int totalGas = 0, totalCost = 0, currentGas = 0, startIndex = 0;

            // Iterate through each gas station
            for (int i = 0; i < gas.Length; i++)
            {
                totalGas += gas[i]; // Total gas available
                totalCost += cost[i]; // Total cost to travel to the next station
                currentGas += gas[i] - cost[i]; // Current gas after visiting the station

                // If current gas is negative, we cannot start from the previous startIndex
                if (currentGas < 0)
                {
                    startIndex = i + 1; // Move the starting index to the next station
                    currentGas = 0; // Reset current gas
                }
            }

            return totalGas >= totalCost ? startIndex : -1; // If total gas is less than total cost, return -1
        }
    }
}
