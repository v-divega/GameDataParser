using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParser.Classes
{
    public static class FileReader
    {
        public static string FileChecker (string fileName)
        {
            
            if(fileName == null)
            {
                while (fileName == null)
                {
                    Console.WriteLine("File name cannot be null.");
                    Console.WriteLine("Enter the name of the file you want to read:");
                    fileName = Console.ReadLine();
                }
                string FileName  = FileChecker(fileName);
                return FileName;

            }

            else if(fileName == "")
            {
                while (fileName == "")
                {
                    Console.WriteLine("File name cannot be empty.");
                    Console.WriteLine("Enter the name of the file you want to read:");
                    fileName = Console.ReadLine();
                }
                string FileName = FileChecker(fileName);
                return FileName;
            }

            else if (!File.Exists(fileName))
            {
                string FileName;
                while (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found.");
                    Console.WriteLine("Enter the name of the file you want to read:");
                    fileName = Console.ReadLine();
                    FileName = FileChecker(fileName);
                    return FileName;
                }
                
                
            }

            return fileName;
            
        }

        public static void ReadFromFile (string fileName)
        {
            var FileContent = File.ReadAllText(fileName);
            try
            {
                List<Games> GamesFromFile = JsonSerializer.Deserialize<List<Games>>(FileContent);
                if (GamesFromFile.Count == 0)
                {
                    Console.WriteLine("No games are present in the input file");

                }
                else
                {
                    Console.WriteLine("Loaded games are:");
                    Console.WriteLine();
                    foreach (var Game in GamesFromFile)
                    {
                        Console.WriteLine($"{Game.Title}, released in {Game.ReleaseYear}, rating {Game.Rating}");

                    }
                }
            }
            catch (JsonException ex) 
            {
                Console.WriteLine ($"JSON in the {fileName}  was not in a valid format. JSON body:");
                var jsonBody = FileContent.Split(Environment.NewLine);
                foreach (var body in jsonBody)
                {
                    Console.WriteLine(body);
                    
                }
                Console.WriteLine();
                Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
                Logger.LogExceptions(ex);
            }
            
            
            

        }
    }
}
