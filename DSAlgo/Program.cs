
using DSAlgo.LeetCode.Array.Easy;
using DSAlgo.LeetCode.Array.Medium;
using DSAlgo.LeetCode.Design;
using DSAlgo.LeetCode.DP.Medium;
using DSAlgo.LeetCode.Graph.Medium;
using DSAlgo.LeetCode.Helper;
using DSAlgo.LeetCode.String.Hard;
using DSAlgo.LeetCode.String.Medium;
using System.Globalization;

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

//var solution = new L62UniquePaths();
//// Example input for Unique Paths
//var m = 3;
//var n = 7;
//var uniquePaths = solution.UniquePathsOptimized(m, n);
//Console.WriteLine(uniquePaths); // Output: 28

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

//var solution = new L287_FindtheDuplicateNumber();
//// Example input for Find the Duplicate Number
//var nums = new int[] { 1, 3, 4, 2, 2 };
//var duplicateNumber = solution.FindDuplicate(nums);
//Console.WriteLine(duplicateNumber); // Output: 2

//var solution = new L994_RottingOranges();
//// Example input for Rotting Oranges
//var grid = new int[][]
//{
//    new int[] { 2, 1, 1 },
//    new int[] { 1, 1, 0 },
//    new int[] { 0, 1, 1 }
//};
//var minutes = solution.OrangesRotting(grid);
//Console.WriteLine(minutes); // Output: 4


//var solution = new L621_TaskScheduler();
//// Example input for Task Scheduler
//var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
//var n = 2; // Cooldown period
//var leastInterval = solution.LeastIntervalGreedy(tasks, n);
//Console.WriteLine(leastInterval); // Output: 8

//var solution = new L981_TimeBasedKeyValueStore();
//// Example usage of Time-Based Key-Value Store
//solution.Set("foo", "bar", 1);
//solution.Set("foo", "bar2", 2);
//solution.Set("foo1", "bar3", 3);
//var result1 = solution.Get("foo", 4); // Returns "bar"
//var result2 = solution.Get("foo", 3); // Returns "bar"
//var result3 = solution.Get("foo1", 2); // Returns ""
//Console.WriteLine(result1); // Output: bar
//Console.WriteLine(result2); // Output: bar
//Console.WriteLine(result3); // Output: (empty string)
//Console.ReadLine();

//var solution = new MathHelp();
//MathHelp.IsPrime(29);
//Console.WriteLine(MathHelp.IsPrime(19));
//Console.WriteLine(MathHelp.GCD(4, 3)); // Output: 6
//Console.WriteLine(MathHelp.LCM(6, 4)); // Output: 20
//    var primes = MathHelp.SieveOfEratosthenes(30);
//    Console.WriteLine(string.Join(", ", primes)); // Output: 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 





////var solution = new L2353_DesignFoodRatingSystem();
//var foods = new string[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
//var cuisines = new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
//var ratings = new int[] { 9, 12, 8, 15, 14, 7 };
//var foodRatingSystem = new L2353_DesignFoodRatingSystem(foods, cuisines, ratings);
//foodRatingSystem.ChangeRating("sushi", 16); // Change the rating of "sushi" to 16
//var highestRatedJapanese = foodRatingSystem.HighestRated("japanese"); // Returns "sushi"
//Console.WriteLine(highestRatedJapanese); // Output: sushi
//foodRatingSystem.ChangeRating("ramen", 16); // Change the rating of "ramen" to 16
//highestRatedJapanese = foodRatingSystem.HighestRated("japanese"); // Returns "ramen" (lexicographically smaller than "sushi")
//Console.WriteLine(highestRatedJapanese); // Output: ramen
//Console.ReadLine();


var solution = new L120_Triangle();
var triangle = new List<IList<int>>
{
    new List<int> { 2 },
    new List<int> { 3, 4 },
    new List<int> { 6, 5, 7 },
    new List<int> { 4, 1, 8, 3 }
};
var minPathSum = solution.MinimumTotal_BruteForce(triangle);
Console.WriteLine(minPathSum); // Output: 11