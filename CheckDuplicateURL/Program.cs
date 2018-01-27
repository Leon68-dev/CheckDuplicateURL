using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDuplicateURL
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                CheckFile checkFile = new CheckFile();
                string fileName = args[0].ToString();
                checkFile.executeCheck(fileName);
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter full path for file html with bookmark. Please");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

            }
        }
    }
}
