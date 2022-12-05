using AdventOfCode2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public static class Day1
    {
        public static void Run() 
        {
            var input = InputReader.ReadInput("Day1.txt");
            string[] lines = input.Split("\r\n");

            List<int> TotalCaloriesByElf = new List<int>();

            var totalCaloresPerElf = 0;

            foreach (var item in lines)
            {

                if (item != "")
                {
                    totalCaloresPerElf += int.Parse(item);
                    continue;
                }

                TotalCaloriesByElf.Add(totalCaloresPerElf);
                totalCaloresPerElf = 0;
            }

            //result1
            Console.WriteLine(TotalCaloriesByElf.Max());

            List<int> tempArr = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                tempArr.Add(TotalCaloriesByElf.Max());
                TotalCaloriesByElf.Remove(TotalCaloriesByElf.Max());
            }

            //result2
            Console.WriteLine(tempArr.Sum());
        }
    }
}
