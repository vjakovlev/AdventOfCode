using AdventOfCode.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace AdventOfCode._2025
{
    public static class Day1
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day1.txt", "2025");
            string[] instructions = input.Split("\r\n");

            var safeDial = new SafeDial(50);
            safeDial.StartSpinning(instructions);

            Console.WriteLine($"Part 1: {safeDial.ZeroCount}");
            Console.WriteLine($"Part 2: {safeDial.ZeroPassCount}");
        }
    }

    public class SafeDial
    {
        public int CurrentPosition { get; set; }
        public int ZeroCount { get; set; }
        public int ZeroPassCount { get; set; }

        public SafeDial(int startPosition)
        {
            CurrentPosition = startPosition;
            ZeroCount = 0;
            ZeroPassCount = 0;
        }

        public void StartSpinning(string[] input) 
        {
            foreach (var line in input)
            {
                var direction = line[0].ToString();
                var steps = int.Parse(line.Substring(1));

                if (direction == "L")
                {
                    RotateLeft(steps);
                }
                else
                {
                    RotateRight(steps);
                }
            }
        }

        private void RotateLeft(int steps)
        {
            for (int i = 0; i < steps; i++) 
            {
                CurrentPosition--;

                if (CurrentPosition == -1)
                {
                    CurrentPosition = 99;
                }

                if (CurrentPosition == 0) 
                {
                    ZeroPassCount++;
                }
            }

            if (CurrentPosition == 0)
            {
                ZeroCount++;
            }
        }
        private void RotateRight(int steps) 
        {
            for (int i = 0; i < steps; i++)
            {
                CurrentPosition++;

                if (CurrentPosition == 100) 
                {
                    CurrentPosition = 0;
                }

                if (CurrentPosition == 0)
                {
                    ZeroPassCount++;
                }
            }

            if (CurrentPosition == 0)
            {
                ZeroCount++;
            }
        }
    }
}
