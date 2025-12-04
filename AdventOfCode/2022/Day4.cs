using AdventOfCode.Common;

namespace AdventOfCode._2022
{
    public static class Day4
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day4.txt", "2022");
            string[] lines = input.Split("\r\n");

            var result1 = 0;
            var result2 = 0;

            foreach (var line in lines)
            {
                if (ProcessLines(line))
                {
                    result1++;
                }
            }

            foreach (var line in lines)
            {
                if (ProcessLines2(line))
                {
                    result2++;
                }
            }

            //result 1
            Console.WriteLine(result1);

            //result 2
            Console.WriteLine(result2);
        }

        private static bool ProcessLines(string input)
        {
            var left = GenerateArray(input.Split(",")[0]);
            var right = GenerateArray(input.Split(",")[1]);

            var res1 = CheckIfExits(left, right);
            var res2 = CheckIfExits(right, left);

            return res1 || res2;
        }

        private static bool ProcessLines2(string input)
        {
            var left = GenerateArray(input.Split(",")[0]);
            var right = GenerateArray(input.Split(",")[1]);

            return left.Intersect(right).Any();
        }

        private static bool CheckIfExits(List<int> arr1, List<int> arr2)
        {
            foreach (var item in arr2)
            {
                if (!arr1.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> GenerateArray(string input)
        {
            var fromTo = input.Split("-").ToArray();

            var one = int.Parse(fromTo.First());
            var two = int.Parse(fromTo.Last());

            var tempArr = new List<int>();

            for (int i = one; i <= two; i++)
            {
                tempArr.Add(i);
            }

            return tempArr;
        }
    }
}
