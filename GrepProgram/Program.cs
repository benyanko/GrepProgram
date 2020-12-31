using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepProgram
{
    public class Program
    {
        public static void Main()
        {
            // C:\Temp\ExerciseCheckingReport.txt
            // https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient?view=netcore-3.1

            string filePath = @"https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient?view=netcore-3.1";
            string pattern = "the";
            Builder builder = new Builder(filePath, pattern);
            Console.WriteLine(builder.TextSearcher.Result);
        }
    }
}
