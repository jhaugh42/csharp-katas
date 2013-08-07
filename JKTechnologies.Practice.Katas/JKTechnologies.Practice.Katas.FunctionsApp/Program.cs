using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JKTechnologies.Practice.Katas.FunctionsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number: ");
            string inputFromConsole = Console.ReadLine();
            int convertedString = Convert.ToInt32(inputFromConsole);

            Console.WriteLine("Enter a Number: ");
            string inputFromConsole1 = Console.ReadLine();
            int convertedString1 = Convert.ToInt32(inputFromConsole1);

            int Total = convertedString + convertedString1;

            Console.WriteLine("Total of {0} + {1} = {2}", convertedString, convertedString1, Total);


            //Console.WriteLine("WTF Mate");
            
            ShowPausePrompt();

        }


        static private void ShowPausePrompt()
        {
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();


        }

        private static int GetIntegerInputFromConsole(string consolePrompt)
        {

            return 0;
        }
    }
}
