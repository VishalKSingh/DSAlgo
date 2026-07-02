using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L3588FindMaximumAreaofaTriangle
    {
        // Find twice the maximum area of a triangle with at least one side parallel to x-axis or y-axis
        public long MaxArea(int[][] coords)
        {
            long maxArea = -1;
            int n = coords.Length;

            // Check all pairs of points with same x-coordinate (vertical line)
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // If x-coordinates are the same, we have a vertical line
                    if (coords[i][0] == coords[j][0])
                    {
                        long base_length = Math.Abs(coords[i][1] - coords[j][1]);

                        // Try each other point as the third vertex
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && k != j)
                            {
                                long height = Math.Abs(coords[k][0] - coords[i][0]);
                                long area = base_length * height;
                                maxArea = Math.Max(maxArea, area);
                            }
                        }
                    }

                    // If y-coordinates are the same, we have a horizontal line
                    if (coords[i][1] == coords[j][1])
                    {
                        long base_length = Math.Abs(coords[i][0] - coords[j][0]);

                        // Try each other point as the third vertex
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && k != j)
                            {
                                long height = Math.Abs(coords[k][1] - coords[i][1]);
                                long area = base_length * height;
                                maxArea = Math.Max(maxArea, area);
                            }
                        }
                    }
                }
            }

            return maxArea;
        }

        // Optimized O(n) approach suitable for large n (1e5)
        public long MaxAreaOptimized(int[][] coords)
        {
            int n = coords.Length;
            if (n < 3) return -1;

            int globalMinX = int.MaxValue, globalMaxX = int.MinValue;
            int globalMinY = int.MaxValue, globalMaxY = int.MinValue;

            var xStats = new Dictionary<int, (int minY, int maxY, int count)>();
            var yStats = new Dictionary<int, (int minX, int maxX, int count)>();

            for (int i = 0; i < n; i++)
            {
                int x = coords[i][0];
                int y = coords[i][1];

                if (x < globalMinX) globalMinX = x;
                if (x > globalMaxX) globalMaxX = x;
                if (y < globalMinY) globalMinY = y;
                if (y > globalMaxY) globalMaxY = y;

                if (!xStats.TryGetValue(x, out var xv)) xv = (y, y, 0);
                xv.minY = Math.Min(xv.minY, y);
                xv.maxY = Math.Max(xv.maxY, y);
                xv.count = xv.count + 1;
                xStats[x] = xv;

                if (!yStats.TryGetValue(y, out var yv)) yv = (x, x, 0);
                yv.minX = Math.Min(yv.minX, x);
                yv.maxX = Math.Max(yv.maxX, x);
                yv.count = yv.count + 1;
                yStats[y] = yv;
            }

            long ans = -1;

            // Evaluate vertical bases (same x)
            foreach (var kv in xStats)
            {
                int x = kv.Key;
                var (minY, maxY, count) = kv.Value;
                if (count < 2) continue;

                long baseLen = (long)maxY - minY;
                if (baseLen == 0) continue;

                long maxHorDist = 0;
                if (globalMinX != x) maxHorDist = Math.Max(maxHorDist, Math.Abs((long)globalMinX - x));
                if (globalMaxX != x) maxHorDist = Math.Max(maxHorDist, Math.Abs((long)globalMaxX - x));

                if (maxHorDist > 0)
                {
                    ans = Math.Max(ans, baseLen * maxHorDist);
                }
            }

            // Evaluate horizontal bases (same y)
            foreach (var kv in yStats)
            {
                int y = kv.Key;
                var (minX, maxX, count) = kv.Value;
                if (count < 2) continue;

                long baseLen = (long)maxX - minX;
                if (baseLen == 0) continue;

                long maxVertDist = 0;
                if (globalMinY != y) maxVertDist = Math.Max(maxVertDist, Math.Abs((long)globalMinY - y));
                if (globalMaxY != y) maxVertDist = Math.Max(maxVertDist, Math.Abs((long)globalMaxY - y));

                if (maxVertDist > 0)
                {
                    ans = Math.Max(ans, baseLen * maxVertDist);
                }
            }

            return ans;
        }
    }
}
