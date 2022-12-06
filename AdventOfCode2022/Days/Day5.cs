using AdventOfCode2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public static class Day5
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day5.txt");
            string[] lines = input.Split("\r\n\r\n");

            string[] docks = lines[0].Split("\r\n");
            string[] instructions = lines[1].Split("\r\n");

            var task1Dock = GenerateWorkloadSchema(docks);
            var task2Dock = GenerateWorkloadSchema(docks);

            var moves = GenerateMoves(instructions);

            //result1
            Console.WriteLine(Task1(task1Dock, moves));

            //result2
            Console.WriteLine(Task2(task2Dock, moves));
        }

        private static List<MoveInput> GenerateMoves(string[] instructions) 
        {
            List<MoveInput> moves = new List<MoveInput>();

            foreach (var line in instructions)
            {
                var temp = line.Split(" ");
                var moveInput = new MoveInput()
                {
                    Move = int.Parse(temp[1]),
                    From = int.Parse(temp[3]) - 1,
                    To = int.Parse(temp[5]) - 1
                };

                moves.Add(moveInput);
            }

            return moves;
        }

        private static List<List<string>> GenerateWorkloadSchema(string[] workLoad) 
        {
            List<List<string>> stacks = new List<List<string>>();

            for (int i = 0; i < workLoad[0].Length; i++)
            {
                List<string> tempList = new List<string>();

                for (int x = 0; x < workLoad.Length - 1; x++)
                {
                    string item = workLoad[x][i].ToString();

                    if (!String.IsNullOrWhiteSpace(item) && item != "[" && item != "]")
                    {
                        tempList.Add(item);
                    }
                }

                if (tempList.Count > 0)
                {
                    tempList.Reverse();
                    stacks.Add(tempList.Select(x => x).ToList());
                    tempList.Clear();
                }
            }

            return stacks;
        }

        private static string Task1(List<List<string>> stacks, List<MoveInput> moves) 
        {
            foreach (var item in moves)
            {
                Move9000(stacks, item);
            }

            string result = "";

            foreach (var stack in stacks)
            {
                result += stack.Last();
            }

            return result.ToString();
        }

        private static string Task2(List<List<string>> stacks, List<MoveInput> moves) 
        {
            foreach (var item in moves)
            {
                Move9001(stacks, item);
            }

            string result = "";

            foreach (var stack in stacks)
            {
                result += stack.Last();
            }

            return result.ToString();
        }  

        public static void Move9000(List<List<string>> stacks, MoveInput input)
        {
            for (int i = 0; i < input.Move; i++)
            {
                string lastItem = stacks[input.From].Last();
                stacks[input.From].RemoveAt(stacks[input.From].Count - 1);
                stacks[input.To].Add(lastItem);
            }
        }

        public static void Move9001(List<List<string>> stacks, MoveInput input)
        {
            var test = stacks[input.From].Skip(stacks[input.From].Count - input.Move).ToList();
            stacks[input.To].AddRange(test);

            for (int i = 0; i < input.Move; i++)
            {
                stacks[input.From].RemoveAt(stacks[input.From].Count - 1);
            }
        }
    }

    public class MoveInput
    {
        public int Move { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
