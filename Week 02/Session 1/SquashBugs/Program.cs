using System;

namespace SquashBugs
{
    // Class: Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise #1
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for a decimal-valued number
        //          Count down to 0 in 0.5 increments
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare variable to hold user-entered number
            //int myNum = 0
            //int myNum = 0;   // syntax error: missing semicolon
            double myNum = 0;   // logic error: int data type won't support decimals

            // prompt for number entry
            //needs quotes?
            //Console.Write(Enter a number:);  // syntax error: missing double quotes
            Console.Write("Enter a number:");

            // read user input and convert to double
            // Convert.ToDouble(Console.ReadLine()); // Need to push to a variable    // Logic error
            // Need data validation
            // myNum = Convert.ToDouble(Console.ReadLine());  // run-time error

            bool bValid = false;
            while(!bValid)
            {
                bValid = double.TryParse(Console.ReadLine(), out myNum);

                if( !bValid)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            // output starting value
            // should have a plus in between the
            //Console.Write("starting value = " myNum); //syntax error
            Console.Write("starting value = " + myNum);

            // while myNum is greater than 0
            //while (myNum < 0)
          // logic error, should be >
            while (myNum > 0)
            // (  syntax error: should be braces
            {
                // output explanation of calculation
                Console.Write("{0} - 0.5 = ", myNum);

                // output the result of the calculation
                Console.WriteLine($"{myNum - 0.5}");

                // logic error: missing decrementing myNum resulting in infinite loop
                myNum -= 0.5;
            }
            // ) syntax error: should be braces
        }
    }
}
