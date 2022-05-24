using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TwentyFourGameSolver
{
    public class Randomizer : ISolver
    {
        public string solve(int a, int b, int c, int d)
        {
            var numbers = new int[4] { a, b, c, d };
            var allOperations = Enum.GetValues(typeof(Operation.Operations));

            var result = 0.0;
            string currentTry = "";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (result != 24.0)
            {
                var digitRandoms = GenerateNDifferentNumbers(4, 0, 3);
                var operationRandoms = GenerateNDifferentNumbers(3, 0, 3);

                var op1 = (Operation.Operations)allOperations.GetValue(operationRandoms[0]);
                var op2 = (Operation.Operations)allOperations.GetValue(operationRandoms[1]);
                var op3 = (Operation.Operations)allOperations.GetValue(operationRandoms[2]);

                result = op3.calculate(op2.calculate(op1.calculate(numbers[digitRandoms[0]], numbers[digitRandoms[1]]), numbers[digitRandoms[2]]), numbers[digitRandoms[3]]);
                currentTry = "(((" + numbers[digitRandoms[0]] + op1.ToString(true) + numbers[digitRandoms[1]] + ")" + op2.ToString(true) + numbers[digitRandoms[2]] + ")" + op3.ToString(true) + numbers[digitRandoms[3]] + ")";

                if(sw.ElapsedMilliseconds > 10000)
                {
                    return "No solution found for[" + digitRandoms[0] + "," + digitRandoms[1] + "," + digitRandoms[2] + "," + digitRandoms[3] + "]";
                }
            }

            return currentTry;
        }

        private int[] GenerateNDifferentNumbers(int numberOfDigits, int min, int max)
        {
            var digits = new List<int>();
            var generator = new Random();

            for (int i = 0; i < numberOfDigits; i++)
            {
                var current = generator.Next(min, max+1);
                if (!digits.Contains(current))
                {
                    digits.Add(current);
                }
                else
                {
                    i--;
                }
            }

            return digits.ToArray();
        }
    }
}
