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

            string inputFromConsole = Console.ReadLine();

            //comment
            int convertedString = Convert.ToInt32("34");


            Console.WriteLine("WTF Mate");
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
