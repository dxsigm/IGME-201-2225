using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            // this will call Add(int int)
            Console.WriteLine("5 + 5 = " + Add(5, 5));

            // this will call Add(double, double)
            Console.WriteLine("5.0 + 5.0 = " + Add(5.0, 5.0));

            // this will call Add(string, string)
            Console.WriteLine("\"5\" + \"5\" = " + Add("5", "5"));

            // Add(int, double) will work because Add(double, double) will implicitly convert the int parameter to a double
            Console.WriteLine("5 + 5.0 = " + Add(5, 5.0));

            // this line will give a compile error because no function signature matches Add(int, string)
            //Console.WriteLine("5 + \"5\" = " + Add(5, "5"));


            // test calling a function and passing a parameter by value
            int changeMe = 456;
            Console.WriteLine("Value before Change(int): " + changeMe);
            Change(changeMe);
            Console.WriteLine("Value after Change(int): " + changeMe);

            Console.WriteLine();

            // test calling a function and passing a parameter by reference
            Console.WriteLine("Value before Change(ref int): " + changeMe);
            Change(ref changeMe);
            Console.WriteLine("Value after Change(ref int): " + changeMe);

            // the first 2 arguments are required, but starting with the third can be any number of the same data type
            VarMethod(12, 24, 45, 46, 476, 34, 34, 34, 23);
        }

        // these are overloaded methods
        // they have the same names (Add and Change) but different return types and parameter types
        // the compiler will choose which function to call based on the context of the call


        // Method: Add
        // Purpose: Add and return 2 ints
        // Restrictions: None
        static int Add(int val1, int val2)
        {
            int returnVal = 0;

            val1 += 5;

            returnVal = val1 + val2;

            return (returnVal);
        }

        // Method: Add
        // Purpose: Add and return 2 ints
        // Restrictions: val1 and val2 must be valid numeric strings
        static int Add(string val1, string val2) 
        {
            int returnVal = 0;

            returnVal = int.Parse(val1) + int.Parse(val2);

            return (returnVal);
        }

        // Method: Add
        // Purpose: Add and return 2 doubles
        // Restrictions: None
        static double Add(double val1, double val2)
        {
            double returnVal = 0;

            returnVal = val1 + val2;

            return (returnVal);
        }

        // Method: Change
        // Purpose: Pass a variable by value and change the value to 123
        // Restrictions: None
        static void Change(int val)
        {
            // this function passes val by value and only creates a copy of the variable within the function
            // the passed variable contents are not changed
            val = 123;
        }

        // Method: Change
        // Purpose: Pass a variable by reference and change the value to 123
        // Restrictions: None
        static void Change(ref int val)
        {
            // this function passes val by reference
            // any changes to val are also made to the passed variable in the calling program (ie. changeMe in this case)
            val = 123;
        }

        // Method: VarMethod
        // Purpose: Demonstrate a variable number of arguments using the params keyword
        //          Calculate the average of the ints passed in
        // Restrictions: None
        static void VarMethod(int var1, int var2, params int[] var3)
        {
            int sum = 0;
            int cntr = 0;
            double avg;

            sum = var1 + var2;

            // because var3 may not have any values, we should check that the Length > 0 before trying to iterate through it
            // otherwise it will cause a runtime error
            if (var3.Length > 0)
            {
                foreach (int n in var3)
                {
                    sum += n;
                    ++cntr;
                }
            }

            // int/int = int, therefore we need to cast 1 operand to double to return double
            avg = (double)sum / (cntr + 2);
        }

    }
}
