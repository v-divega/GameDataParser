using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Classes
{
    
    public static class Logger
    {
        
        public static void LogExceptions (Exception exception)
        {
            File.AppendAllText("log.txt", Format(exception));
            
            
        }

        public static string Format(Exception exception)
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString() + exception.ToString() + Environment.NewLine;

        }
    }
}
