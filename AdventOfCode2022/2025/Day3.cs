using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025
{
    public static class Day3
    {
        public static void Run() 
        {
            var input = InputReader.ReadInput("Day3.txt", "2025");
            var banks = input.Split("\r\n").ToList();

            var part1Result = 0;
            var part2Result = 0L;

            foreach (var bank in banks)
            {
                var twoDigitJolitage = GetMax2DigitJoltage(bank);
                part1Result += twoDigitJolitage;

                var twelveDigitJoltage = GetMax12DigitJoltage(bank);
                part2Result += long.Parse(twelveDigitJoltage);
            }

            Console.WriteLine($"Part 1: {part1Result}");
            Console.WriteLine($"Part 2: {part2Result}");
        }

        public static int GetMax2DigitJoltage(string bank)
        {
            int highestCombination = 0;

            for (int i = 0; i < bank.Length - 1; i++)
            {
                int tens = bank[i] - '0';

                for (int j = i + 1; j < bank.Length; j++)
                {
                    int ones = bank[j] - '0';
                    int current = tens * 10 + ones;

                    if (current > highestCombination)
                    {
                        if (current == 99)
                        {
                            return current;
                        }

                        highestCombination = current;
                    }

                }
            }

            return highestCombination;
        }

        public static string GetMax12DigitJoltage(string bank)
        {
            const int digitsToKeep = 12;
            int digitsToRemove = bank.Length - digitsToKeep;

            var stack = new Stack<char>();

            foreach (char digit in bank)
            {
                while (stack.Count > 0 &&
                       digitsToRemove > 0 &&
                       stack.Peek() < digit)
                {
                    stack.Pop();
                    digitsToRemove--;
                }

                stack.Push(digit);
            }

            while (digitsToRemove > 0)
            {
                stack.Pop();
                digitsToRemove--;
            }

            return new string(stack.Reverse().Take(digitsToKeep).ToArray());
        }
    }
}
