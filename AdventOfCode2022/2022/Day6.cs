using AdventOfCode.Common;

namespace AdventOfCode._2022
{
    public static class Day6
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day6.txt", "2022");
            var chars = input.ToCharArray();

            //result1
            Console.WriteLine(DetectMarker(chars, 4));

            //result2
            Console.WriteLine(DetectMarker(chars, 14));
        }

        public static int DetectMarker(char[] chars, int markerLength)
        {
            var startPosition = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                char[] tempArr = new char[markerLength];

                for (int x = 0; x < markerLength; x++)
                {
                    tempArr[x] = chars[i + x];
                }

                if (tempArr.Length != tempArr.Distinct().Count())
                {
                    continue;
                }

                startPosition = i;
                break;
            };

            return startPosition + markerLength;
        }
    }
}
