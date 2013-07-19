using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions.Common;

namespace ArraysExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrays hold more than one of something
            //they are known as "containers"  This array contains integers. 
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };


            PrintAllNumbers(numbers);
            Console.WriteLine("The Sum is: {0}", GetSum(numbers));
            Console.WriteLine("The Average is: {0}", 0);

            //to see the definition of any method, you can click on it and press F12
            //See where this method is defined.
            CommonConsole.DoExitPrompt();
        }

        //lets look at loops, since they are essential for handling arrays
        private static void PrintAllNumbers(int[] numbers)
        {
            //Notice there are 3 parts to the declaration of this for loop
            //initialization (executed once before the loop starts)
            //continue condition (checked before each loop)
            //Post-execution (run after the loop completes)
            for (int i = 0; i < numbers.Length; ++i)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        private static int GetSum(int[] numbersToSum)
        {
            int sum = 0;
            for (int i = 0; i < numbersToSum.Length; ++i)
            {
                sum = sum + numbersToSum[i];
            }
            return sum;
        }


        



    }
}
