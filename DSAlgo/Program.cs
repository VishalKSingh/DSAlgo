
using DSAlgo.LeetCode.Array.Easy;
using DSAlgo.LeetCode.Array.Medium;
using DSAlgo.LeetCode.Design;
using DSAlgo.LeetCode.DP.Medium;
using DSAlgo.LeetCode.Graph;
using DSAlgo.LeetCode.Graph.Medium;
using DSAlgo.LeetCode.Helper;
using DSAlgo.LeetCode.Matrix;
using DSAlgo.LeetCode.String.Easy;
using DSAlgo.LeetCode.String.Hard;
using DSAlgo.LeetCode.String.Medium;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

var equations = new List<IList<string>>
            {
                new List<string> { "a", "b" },
                new List<string> { "b", "c" }
            };
var values = new double[] { 2.0, 3.0 };
var queries = new List<IList<string>>
        {
            new List<string> { "a", "c" },
            new List<string> { "b", "a" },
            new List<string> { "a", "e" },
            new List<string> { "a", "a" },
            new List<string> { "x", "x" }
        };

//var result = L796_RotateString.RotateString("abcde", "abced");

//var uniquePaths = new L62UniquePaths();
//var result = uniquePaths.UniquePathsOneDArray(3, 7);
//Console.WriteLine(result);
//Console.WriteLine(String.Join("#", new char[] { '1', '2', '3' }));

    var minPathSum = new L64_MinPathSum();
var result2 = minPathSum.MinPathSumOptimized(new int[][]
{
    new int[] {1, 3, 1},
    new int[] {1, 5, 1},
    new int[] {4, 2, 1}
});
Console.WriteLine(result2);

