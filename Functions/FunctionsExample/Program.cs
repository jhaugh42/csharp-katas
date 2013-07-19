using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //lets learn some new things while we're at it
            int someNumber = 1;
            int otherNumber = 54;

            //add the two numbers with a function, store the result
            int sum = AddTwoNumbers(someNumber, otherNumber);

            //print what just happened.
            Console.WriteLine("{0} + {1} = {2}", someNumber, otherNumber, sum);

            //get the average of the two numbers
            //implement average function.  See below.
            double average = 0;

            //print what just happened.
            Console.WriteLine("{0} + {1} = {2}", someNumber, otherNumber, average);

            //this exit prompt thing is common code, we're going to use it everywhere
            //lets encapsulate it in a function so we don't have to re-create the wheel every program.
            DoExitPrompt();
        }


        private static int AddTwoNumbers(int num1, int num2)
        {
            //returns a new integer whose value is the sum of the arguments
            return num1 + num2;
        }

        //TODO: Write a private static function that returns a double
        //the value returned should be the average of the two arguments.
        //Call the function to set the value for the "average" variable in the main method of the program.

       

        private static void DoExitPrompt()
        {
            //this function returns "void", or nothing.
            Console.WriteLine("Press Enter To Exit!");
            Console.ReadLine();
        }
    }
}
