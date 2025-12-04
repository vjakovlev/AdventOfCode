using AdventOfCode.Common;

namespace AdventOfCode._2025
{
    public static class Day4
    {
        public static void Run()
        {
            var input = InputReader.ReadInput("Day4.txt", "2025");
            var paperShelves = input.Split("\r\n").ToList();

            var lastShelvePosition = paperShelves.Count;
            var currentShelvePosition = -1;
            var paperPositionInShelve = 0;

            var result = 0;


            foreach (var shelve in paperShelves)
            {
                currentShelvePosition++;

                for (var i = 0; i < shelve.Length; i++)
                {
                    paperPositionInShelve++;

                    if (shelve[i] == '@')
                    {
                        var forkPosibility = 0;


                        var middleShelve = paperShelves[currentShelvePosition];
                        var middlePositionsToCheck = new List<int> { paperPositionInShelve - 1, paperPositionInShelve + 1 };

                        var midToAdd = ChekShelveAvailability(middleShelve, middlePositionsToCheck);
                        forkPosibility = forkPosibility + midToAdd;

                        try
                        {
                            var upperShelv = paperShelves[currentShelvePosition - 1];
                            var upperShelvPositionsToCheck = new List<int> { paperPositionInShelve - 1, paperPositionInShelve, paperPositionInShelve + 1 };
                            var upperToAdd = ChekShelveAvailability(upperShelv, upperShelvPositionsToCheck);
                            forkPosibility = forkPosibility + upperToAdd;
                        }
                        catch (Exception)
                        {
                        }


                        try
                        {
                            var lowerShelve = paperShelves[currentShelvePosition + 1];
                            var lowerShelvePositionsToCheck = new List<int> { paperPositionInShelve - 1, paperPositionInShelve, paperPositionInShelve + 1 };
                            var lowerToAdd = ChekShelveAvailability(lowerShelve, lowerShelvePositionsToCheck);
                            forkPosibility = forkPosibility + lowerToAdd;
                        }
                        catch (Exception)
                        {
                        }

                        if (forkPosibility < 4)
                        {
                            result++;
                        }
                    }

                    if (paperPositionInShelve >= shelve.Length)
                    {
                        paperPositionInShelve = 0;
                    }
                }
            }

            Console.WriteLine(result);
        }

        public static int ChekShelveAvailability(string shelve, List<int> positionsToCheck)  
        {
            var totalPapers = 0;

            foreach (var paperPosition in positionsToCheck)
            {
                try
                {
                    var pickedPosition = shelve[paperPosition - 1];
                    if (pickedPosition == '@')
                    {
                        totalPapers++;
                    }
                }
                catch (Exception)
                {
                }
            }


            return totalPapers;
        }
    }
}
