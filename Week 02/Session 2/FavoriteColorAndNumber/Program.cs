// the using statement gives us access to objects, methods and enums in a namespace without having to prefix them every time
// for example, without line #3, we would have to type System.Console.WriteLine() every time
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// we can define other namespaces at the same level as the app's namespace
namespace ColorNameSpace
{
    // we can nest namespaces within each other
    // a namespace to hold the user's favorite color
    namespace Color
    {
        // Class: NumberClass
        // Author: David Schuh
        // Purpose: Class to contain the user's favorite number
        // Restrictions: None
        // BE SURE TO ADD THE "static" KEYWORD TO ALL CLASS DEFINITIONS DURING UNIT 1!
        static class ColorClass
        {
            public static String sFavColor = null;
        }
    }
}

// upon creating a project VS creates a namespace with the same name
namespace FavoriteColorAndNumber
{
    // we can define a namespace alias for more concise access
    // we only have to type CAlias.ColorClass.sFavColor instead of ColorNameSpace.Color.ColorClass.sFavColor
    using CAlias = ColorNameSpace.Color;

    // Class: Program
    // Author: David Schuh
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    static internal class Program
    {
        static void PrintMyColor(string sColorString)
        {
            sColorString += " is your favorite color";
            Console.WriteLine(sColorString);
        }

        static void PrintMyColor(ref string sColorString)
        {
            sColorString += " is your favorite color";
            Console.WriteLine(sColorString);
        }


        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        // Restrictions: None
        static void Main(string[] args)
        {
            // refer to Week #1 Lecture Notes for the summary of all of the primitive data types
            // the primitive data types are "value" data types in that they are referenced by value, and have their data stored in discrete "boxes" (or chunks of memory)
            // the string data type is also a value pointer in that it can be set to null, which indicates it is not pointing to any valid data

            // note that variables cannot start with a number, but can contain numbers
            // the only special character variables can contain is the underscore "_"
            // they can start with underscore
            // Best practice is to use camelcase for variable names, which means the variable starts lowercase and each subsequent word is capitalized
            // I prefer using the first character to indicate the variable data type.  For example:
            //      "s" : string  (sFavColor)
            //      "n  : numeric (nFavNumber)
            //      "b" : bool (bValid)

            int nFavNum = 0;
            string sFavNum = null;
            sFavNum = "123";

            // the other primitive data types are not pointer values by default and therefore cannot be set to null
            // the following statement, if uncommented, will cause a compile-time error
            // int nFavNumber = null;

            // we can override the data type support the null pointer by adding the "?" suffix to the primitive data type
            int? npFavNum = null;

            bool bValid = false;

            Int32 nParentInt = 0;

            // examples of nested code blocks
            {
                // parent variables are available within child code blocks
                nParentInt = 1;

                Int32 myInt = 0;

                {
                    myInt = 2;
                    nParentInt = 3;
                }
            }

            // myInt is not available here


            Int32 nFavNumber = 0;

            // comments can be created with double slash
            /// or 3 slashes
            /* or slash star ... star slash
               to span multiple lines */


            Console.WriteLine("Hello World");
            // this outputs: Hello World\n    where \n is the newline character

            // prompt the user for their fav color
            // \t is the escape sequence for the tab character
            // note that System. is not necessary since we have the "using" statement at the top of the code
            // commands must end with ";" and can span multiple lines
            Console.
                Write("Enter your favorite color:\t");

            // read from the console and store that in a variable
            // the following statement reads a line from the Console, but does not store it anywhere
            //Console.ReadLine();

            //ColorNameSpace.Color.ColorClass.sFavColor = Console.ReadLine();
            CAlias.ColorClass.sFavColor = Console.ReadLine();

            PrintMyColor(CAlias.ColorClass.sFavColor);
            PrintMyColor(ref CAlias.ColorClass.sFavColor);

            // prompt the user for their fav number
            Console.Write("Enter your favorite number:\t");


            // validate that the user entered a valid number
            // we want a loop until the user enters a valid number
            // note that Console.ReadLine() can only read strings, and if the user does not enter a number, then a runtime error will occur
            // you must write code that validates all user input and does not crash!

            // the do...while() loop always executes the loop at least once
            // and checks the while condition after the first execution
            do
            {
                // read from the console and store that in a variable
                sFavNum = Console.ReadLine();

                // Convert.ToInt32() will generate a runtime error (exception) if the passed in string is not a valid number
                // therefore, we "try" to convert it
                try
                {
                    npFavNum = Convert.ToInt32(sFavNum);
                }
                // and "catch" any exception that occurs
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                }

                // and we put this in a loop while nFavNumber is null
                // the advantage of initializing nFavNumber to a null pointer is that we know whether they entered a valid number or not
                // if we initialize it to 0 or 123456, those may be someone's favorite number, so we wouldn't know that they entered those numbers!
            } while (npFavNum == null);


            // the while() loop may never execute if the condition is false, since the condition is tested before entering the loop
            while (npFavNum == null)
            {
                // read from the console and store that in a variable
                sFavNum = Console.ReadLine();

                try
                {
                    npFavNum = Convert.ToInt32(sFavNum);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                }
            }

            // convert using int.Parse()
            while (npFavNum == null)
            {

                // read from the console and store that in a variable
                sFavNum = Console.ReadLine();

                try
                {
                    npFavNum = int.Parse(sFavNum);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                }
            }

            // convert using int.TryParse()
            while( !bValid )
            //while( bValid == false)
            {
                // read from the console and store that in a variable
                sFavNum = Console.ReadLine();

                // note that we cannot pass npFavNum to TryParse because it does not match the method signature
                bValid = int.TryParse(sFavNum, out nFavNum);
            }

            npFavNum = nFavNum;


            //CAlias.ColorClass.sFavColor = CAlias.ColorClass.sFavColor.ToLower();

            // change text to match their color 
            // if we lowercase the color, we don't have to check every case combination
            switch (CAlias.ColorClass.sFavColor.ToLower())
            {
                case "red":
                case "RED":
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            // the switch statement is similar to an if... then... else if... then... else
            // note how much more work is involved to do the same code as the string needs to be lowercased everytime
            // double equals is used to test for equality in C#
            //if (CAlias.ColorClass.sFavColorsFavColor.ToLower() == "red")
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //}
            //else if (CAlias.ColorClass.sFavColorsFavColor.ToLower() == "blue")
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //}
            //else if (CAlias.ColorClass.sFavColorsFavColor.ToLower() == "green")
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //}


            // output their favorite color the number of times as their favorite number
            // use a for(initialization;condition;operation) loop to output their favorite color the number of times as their favorite number
            // The three statements within the for() statement:
            //      1. initialization statement(s):  (i = 0) any variable initialization
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i)
            //
            //      2. condition check:  (i < favNum) what to check at the beginning of the loop each time it loops (including the first time)
            //
            //      3. operation: (++i)  any operations to execute upon each subsequent start of the loop (not including the first time)
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i, ++y)
            //
            //          Note that using the "continue" statement to return to the top of the loop will execute the operation statement(s)
            //          so that if you need to do something N times, you may have to --i before the "continue" to repeat the same value of i.
            //
            for ( int i = 0; i < npFavNum; i += 1  /* could also be ++i or i++ */)
            {
                // different ways to generate output
                // appending strings using the "+" operator
                Console.WriteLine("Your favorite color is " + CAlias.ColorClass.sFavColor + "! (appending)");

                // embedding code blocks using string interpolation
                Console.WriteLine($"Your favorite color is  + {CAlias.ColorClass.sFavColor + "!"} (interpolation)");

                // substituting numbered tokens with comma-separated arguments
                Console.WriteLine("Your favorite color is {0}{1} (substitution)", CAlias.ColorClass.sFavColor, "!");
            }

            // three kinds of coding errors:
            // 1. compile-time (syntax) errors: the code will not even compile
            // 2. run-time errors or exceptions: the code compiles and runs, but encounters an exception that crashes the app (eg. trying to access a null pointer, divide by zero, etc)
            // 3. logic errors: the code compiles and runs but does the wrong thing!

            // for example a logic error would be to write the above for() loop incorrectly as:
            // for (int i = 1; i < nFavNumber; i += 1)
            // starting from 1 to nFavNumber will output 1 less than desired.
            // if starting from 1, then the test needs to be: i <= nFavNumber

            // explaining the incrementer operator (++)
            int x = 0;
            int y = 0;

            // with the incrementer prefix, x is incremented when the statement first executes
            y = ++x;  // y = 1   x = 1

            x = 0;
            y = 0;

            // with the incrementer postfix, x is incremented at the end of statement execution
            y = x++;  // y = 0  x = 1
        }
    }
}
