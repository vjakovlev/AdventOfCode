using AdventOfCode.Common;

namespace AdventOfCode._2022
{
    public static class Day3
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day3.txt", "2022");
            string[] lines = input.Split("\r\n");

            var chars = new List<char>();

            foreach (var item in lines)
            {
                chars.Add(ExtractSameCharacter(item));
            }

            List<int> results = new List<int>();

            foreach (var item in chars)
            {
                results.Add(CalculateScore(item));
            }

            //result1
            Console.WriteLine(results.Sum());

            var results2 = new List<int>();

            for (int i = 0; i < lines.Length; i += 3)
            {
                results2.Add(ExtractSameCharacterInThreeLines(new List<string> { lines[i], lines[i + 1], lines[i + 2] }));
            }

            //result2
            Console.WriteLine(results2.Sum());
        }

        private static int ExtractSameCharacterInThreeLines(List<string> strings)
        {
            string[] orderedStrings = strings.OrderBy(s => s.Length).ToArray();

            char chs = default;

            foreach (var character in orderedStrings.First())
            {
                if (CompareChatInString(character, orderedStrings[1], orderedStrings[2]))
                {
                    chs = character;
                }
            }

            return CalculateScore(chs);
        }

        private static bool CompareChatInString(char c, string str1, string str2)
        {
            foreach (var item in str1)
            {
                if (c == item)
                {
                    foreach (var item2 in str2)
                    {
                        if (c == item2)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static char ExtractSameCharacter(string line)
        {
            var string1 = string.Join("", line.Skip(0).Take(line.Length / 2));
            var string2 = string.Join("", line.Skip(line.Length / 2).Take(line.Length));

            return string1.Intersect(string2).ToList().First();
        }

        private static int CalculateScore(char letter)
        {
            char[] small = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            char[] big = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var result = 0;

            for (int i = 0; i < small.Length; i++)
            {
                if (letter == small[i])
                {
                    result = i + 1;
                    break;
                }

                if (letter == big[i])
                {
                    result = i + 27;
                    break;
                }
            }

            return result;
        }
    }
}
