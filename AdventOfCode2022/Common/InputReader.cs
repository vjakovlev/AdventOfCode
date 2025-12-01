namespace AdventOfCode.Common
{
    public static class InputReader
    {
        private static readonly string ProjectRootPath =
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Inputs");

        public static string ReadInput(string fileName, string year)
        {
            return File.ReadAllText(Path.Combine($"{ProjectRootPath}{year}", fileName));
        }
    }
}
