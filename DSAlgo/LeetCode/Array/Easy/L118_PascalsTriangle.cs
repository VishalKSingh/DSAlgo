using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L118_PascalsTriangle
    {
        // This problem is to generate the first numRows of Pascal's triangle.
        // Each row is generated based on the previous row, where each element is the sum of the two elements above it.
        // Time Complexity: O(numRows^2) since we are generating each row based on the previous one
        // Space Complexity: O(numRows) for storing the result

        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> triangle = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        row.Add(1); // The first and last elements of each row are always 1
                    else
                        row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]); // Sum of the two elements above
                }
                triangle.Add(row);
            }

            return triangle;
        }


    }
}
