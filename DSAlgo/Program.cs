
using DSAlgo.LeetCode.Array.Easy;
using DSAlgo.LeetCode.Array.Medium;
using DSAlgo.LeetCode.DP.Medium;
using DSAlgo.LeetCode.Graph.Medium;
using DSAlgo.LeetCode.String.Hard;
using DSAlgo.LeetCode.String.Medium;

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

//var solution = new L399_EvaluateDivision();
//var results = solution.CalcEquation(equations, values, queries);
//Console.WriteLine(string.Join(", ", results));
//Console.ReadLine();

//var solution = new L136SingleNumber();
//var input = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
//var result = solution.FullJustify(input, 16);
//Console.WriteLine(result); // Output: "blue is sky the"

//var solution = new L136SingleNumber();
//var nums = new int[] { 4, 1, 2, 1, 2 };
//var singleNumber = solution.SingleNumber(nums);
//Console.WriteLine(singleNumber); // Output: 4

//var solution = new L54SpiralMatrix();
//var matrix = new int[][]
//{
//    new int[] { 1, 2, 3, 4 },
//    new int[] { 5, 6, 7, 8 },
//    new int[] { 9, 10, 11, 12 }
//};
//var spiralOrder = solution.SpiralOrder(matrix);
//Console.WriteLine(string.Join(", ", spiralOrder)); // Output: 1, 2, 3, 6, 9, 8, 7, 4, 5

var solution = new L62UniquePaths();
// Example input for Unique Paths
var m = 3;
var n = 7;
var uniquePaths = solution.UniquePathsOptimized(m, n);
Console.WriteLine(uniquePaths); // Output: 28

//var solution = new L63_UniquePathsII();

//// Example input for Unique Paths II
//var obstacleGrid = new int[][]
//{
//    new int[] { 0, 0, 0 },
//    new int[] { 0, 1, 0 },
//    new int[] { 0, 0, 0 }
//};
//var uniquePathsWithObstacles = solution.UniquePathsWithObstacles(obstacleGrid);
//Console.WriteLine(uniquePathsWithObstacles); // Output: 2
