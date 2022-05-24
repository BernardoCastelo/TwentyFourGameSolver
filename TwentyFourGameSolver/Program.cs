using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TwentyFourGameSolver
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var currentSolver = new Randomizer();
            var line = Console.ReadLine();
            SolveNTimes(currentSolver, line[0] - '0', line[1] - '0', line[2] - '0', line[3] - '0');
            Console.ReadLine();
        }

        public static void Solve(ISolver solver, int a, int b, int c, int d)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(solver.solve(a, b, c, d));
            sw.Stop();
            Console.WriteLine(solver.GetType().Name + " took " + sw.ElapsedMilliseconds + "ms.");
            Console.WriteLine("");
        }

        public static void SolveNTimes(ISolver solver, int a, int b, int c, int d)
        {
            var sw = new Stopwatch();
            sw.Start();
            var solutions = new List<string>();
            while(sw.ElapsedMilliseconds < 2000)
            {
                var currentSolution = solver.solve(a, b, c, d);
                if(currentSolution.StartsWith("(") && !solutions.Contains(currentSolution))
                {
                    solutions.Add(currentSolution);
                    Console.WriteLine(currentSolution);
                }
            }

            if(solutions.Count == 0)
            {
                Console.WriteLine("No Solution was found.");
            }
            else
            {
                Console.WriteLine("Found " + solutions.Count + " solutions.");
            }

            Console.WriteLine("");
        }
    }
}
