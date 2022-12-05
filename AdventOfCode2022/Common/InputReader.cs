using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common
{
    public static class InputReader
    {
        private static readonly string ProjectRootPath =
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Inputs");

        public static string ReadInput(string fileName) 
        {
            return File.ReadAllText(Path.Combine(ProjectRootPath, fileName));
        }
    }
}
