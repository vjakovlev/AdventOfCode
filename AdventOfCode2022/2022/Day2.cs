using AdventOfCode.Common;

namespace AdventOfCode._2022
{
    public static class Day2
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day2.txt", "2022");
            string[] lines = input.Split("\r\n");

            var totalScore1 = 0;
            var totalScore2 = 0;

            foreach (var item in lines)
            {
                string[] line = item.Split(" ");
                totalScore1 += CalculateResultPerRound(line[0], line[1]);
            }

            foreach (var item in lines)
            {
                string[] line = item.Split(" ");
                totalScore2 += CalculateResultPerRound2(line[0], line[1]);
            }

            Console.WriteLine(totalScore1);
            Console.WriteLine(totalScore2);

        }

        private static int CalculateResultPerRound2(string opponentChoice, string myChoice)
        {
            var totalRoundScore = 0;

            if (opponentChoice == "A") // rock
            {
                if (myChoice == "X") //lose = 0
                {
                    //cisors = 3
                    totalRoundScore += 3;
                }

                if (myChoice == "Y") //draw = 3
                {
                    //rock = 1
                    totalRoundScore += 4;
                }

                if (myChoice == "Z") //win = 6
                {
                    //paper = 2
                    totalRoundScore += 8;
                }
            }

            if (opponentChoice == "B") // paper
            {
                if (myChoice == "X") //lose = 0
                {
                    //rock = 1
                    totalRoundScore += 1;
                }

                if (myChoice == "Y") //draw = 3
                {
                    //paper = 2
                    totalRoundScore += 5;
                }

                if (myChoice == "Z") //win = 6
                {
                    //cisors = 3
                    totalRoundScore += 9;
                }
            }

            if (opponentChoice == "C") // cisors
            {
                if (myChoice == "X") //lose = 0
                {
                    //paper = 2
                    totalRoundScore += 2;
                }

                if (myChoice == "Y") //draw = 3
                {
                    //cisors = 3
                    totalRoundScore += 6;
                }

                if (myChoice == "Z") //win = 6
                {
                    //rock = 1
                    totalRoundScore += 7;
                }
            }

            return totalRoundScore;
        }

        private static int CalculateResultPerRound(string opponentChoice, string myChoice)
        {
            var totalRoundScore = 0;

            if (myChoice == "X")
            {
                totalRoundScore += 1;

                if (opponentChoice == "A")
                {
                    totalRoundScore += 3;
                }

                if (opponentChoice == "B")
                {
                    totalRoundScore += 0;
                }

                if (opponentChoice == "C")
                {
                    totalRoundScore += 6;
                }
            }

            if (myChoice == "Y")
            {
                totalRoundScore += 2;

                if (opponentChoice == "A")
                {
                    totalRoundScore += 6;
                }

                if (opponentChoice == "B")
                {
                    totalRoundScore += 3;
                }

                if (opponentChoice == "C")
                {
                    totalRoundScore += 0;
                }
            }

            if (myChoice == "Z")
            {
                totalRoundScore += 3;

                if (opponentChoice == "A")
                {
                    totalRoundScore += 0;
                }

                if (opponentChoice == "B")
                {
                    totalRoundScore += 6;
                }

                if (opponentChoice == "C")
                {
                    totalRoundScore += 3;
                }
            }

            return totalRoundScore;
        }


    }
}
