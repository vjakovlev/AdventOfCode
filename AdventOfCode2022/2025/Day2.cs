using AdventOfCode.Common;

namespace AdventOfCode._2025
{
    public static class Day2
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day2.txt", "2025");
            var keys = input.Split(",").ToList();

            var part1Result = new List<long>();
            var part2Result = new List<long>();

            foreach (var key in keys)
            {
                var parts = key.Split("-");
                var intParts = parts.Select(long.Parse).ToArray();

                for (long i = intParts[0]; i <= intParts[1]; i++)
                {
                    if (HasIdenticalParts(i))
                    {
                        part1Result.Add(i);
                    }

                    if (HasRepeatingPattern(i))
                    {
                        part2Result.Add(i);
                    }
                }
            }

            Console.WriteLine($"Part 1: {part1Result.Sum()}");
            Console.WriteLine($"Part 2: {part2Result.Sum()}");
        }

        public static bool HasIdenticalParts(long number)
        {
            var input = number.ToString();

            if (input.Length % 2 != 0) 
            {
                return false;
            }
                
            int half = input.Length / 2;
            string firstHalf = input.Substring(0, half);
            string secondHalf = input.Substring(half, half);

            return firstHalf == secondHalf;
        }

        public static bool HasRepeatingPattern(long number)
        {
            var input = number.ToString();

            for (int i = 1; i <= input.Length / 2; i++)
            {
                if (input.Length % i == 0)
                {
                    string pattern = input.Substring(0, i);
                    int repeatCount = input.Length / i;

                    if (repeatCount >= 2)
                    {
                        string candidate = string.Concat(Enumerable.Repeat(pattern, repeatCount));
                        if (candidate == input) 
                        {
                            return true;
                        }
                            
                    }
                }
            }

            return false;
        }
    }
}
