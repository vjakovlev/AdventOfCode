using AdventOfCode2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public static class Day6
    {
        public static void Run() 
        {
            string input = InputReader.ReadInput("Day6.txt");
            char[] chars = input.ToCharArray();

            var startPosition = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                char[] tempArr = new char[4];

                for (int x = 0; x < 4; x++)
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

            Console.WriteLine(startPosition + 4);
        }
    }
}
