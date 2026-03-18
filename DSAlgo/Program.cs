
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
using DSAlgo.LeetCode.Tree.Medium;
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

//    var minPathSum = new L64_MinPathSum();
//var result2 = minPathSum.MinPathSumOptimized(new int[][]
//{
//    new int[] {1, 3, 1},
//    new int[] {1, 5, 1},
//    new int[] {4, 2, 1}
//});
//Console.WriteLine(result2);

//var result = new L238_ProductOfArrayExceptSelf();
//var result3 = result.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
//Console.WriteLine(String.Join(", ", result3));
//var res = new L974_SubarraySumsDivisiblebyK();
//var result = res.SubarraysDivByK(new int[] { 4, 5, 0, -2, -3, 1 }, 5);
//Console.WriteLine(result);
// var res = L26_RemoveDuplicatesFromSortedArray.RemoveDuplicates(new int[] { 1, 1, 2 });
//Console.WriteLine(res);

//string EncodeBase62(long num)
//{
//    const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
//    StringBuilder result = new StringBuilder();

//    while (num > 0)
//    {
//        result.Insert(0, chars[(int)(num % 62)]);
//        num /= 62;
//    }

//    return result.ToString();
//}

//var encoded = EncodeBase62(125346);
//Console.WriteLine(encoded);

var result = new L1283_SmallestDivisorGivenaThreshold();
result.SmallestDivisor(new int[] { 1, 2, 5, 9 }, 6);