using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Classes
{
    public static class Application
    {
        public static void Run()
        {
            Console.WriteLine("Enter the name of the file you want to read:");
            string fileName = Console.ReadLine();
            string FileName = FileReader.FileChecker(fileName);
            FileReader.ReadFromFile(FileName);
        }
    }
}
