using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public static class Day1
    {
        public static void Run() 
        {
            var instructions = InputReader.ReadInput("Day1.txt", "2015");

            var startingPosition = 0;
            var basementIndex = 0;

            foreach (var instruction in instructions)
            {
                if (instruction == '(')
                {
                    startingPosition++;
                }
                else if (instruction == ')')
                {
                    startingPosition--;
                }
            }

            startingPosition = 0;

            foreach (var instruction in instructions)
            {
                if (instruction == '(')
                {
                    startingPosition++;
                }
                else if (instruction == ')')
                {
                    startingPosition--;
                }

                if (startingPosition == -1)
                {
                    basementIndex = instructions.IndexOf(instruction);
                    break;
                }
            }

            Console.WriteLine($"Part1: {startingPosition}");
            Console.WriteLine($"Part2: {basementIndex}");
        }
    }
}
