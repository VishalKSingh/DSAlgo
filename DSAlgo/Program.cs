
using DSAlgo.LeetCode.Graph.Medium;

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

var solution = new L399_EvaluateDivision();
var results = solution.CalcEquation(equations, values, queries);
Console.WriteLine(string.Join(", ", results));
Console.ReadLine();
