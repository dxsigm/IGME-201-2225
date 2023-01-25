using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    // Class: Examples
    // Author: David Schuh
    // Purpose: Contains examples for Week 2
    // Restrictions: Only contains code snippets.  
    internal class Examples
    {
        // Method: Main
        // Purpose: The main entry point for the executable. Code snippet examples.
        // Restrictions: None
        static void Main(string[] args)
        {
            int nNumber = 0;

            {
                int[] myIntArray = { 5, 9, 10, 2, 99 };
            }

            {
                int[] myIntArray = new int[5] { 5, 9, 10, 2, 99 };
            }

            {
                int[] myIntArray = new int[5];

                myIntArray[0] = 5;
                myIntArray[1] = 9;
                myIntArray[2] = 10;
                myIntArray[3] = 2;
                myIntArray[4] = 99;
            }

            {
                int arraySize = 5;
                int[] myIntArray = new int[arraySize];
            }

            {
                // single dimension array useful for lists for 2d graphs
                int[] funcVal = new int[21];
                int x = 0;
                int xCntr = 0;
                int y = 0;

                // the value of y at x
                funcVal[x] = y;

                // cannot access arrays with negative indexes
                //funcVal[-10] = 45;

                // we may want a parallel array to store each value of x
                int[] xArray = new int[21];

                // for example: y = 2 * x^2 + 3
                // fill the array for -10 <= x <= 10 (21 data points)
                for (x = -10; x <= 10; ++x, ++xCntr)
                {
                    // Math.Pow() returns a double, so we need to cast as int
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // the array indexer must be a positive integer and 0-based
                    // (ie. we cannot store funcVal[-10])
                    funcVal[xCntr] = y;
                    xArray[xCntr] = x;
                }


                /////////////////////////////////////////////////////////////////////////
                // or we may want to add a dimension to the array to store x as well
                int[,] funcVal2 = new int[21, 2];

                // for example: y = 2 * x^2 + 3
                // fill the array for -10 <= x <= 10 (21 data points)

                xCntr = 0;
                for (x = -10; x <= 10; ++x)
                {
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // store x in the first element of the second dimension
                    funcVal2[xCntr, 0] = x;

                    // store y in the second element of the second dimension
                    funcVal2[xCntr, 1] = y;

                    ++xCntr;
                }
            }


            {
                // 3-d formula example with rectangular array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;

                // we declare our 3 dimensional array to hold:
                //        81 values of x
                //        36 values of y for each value of x
                //        3 values for each data point: the x, y and z
                double[,,] zFunc = new double[81, 36, 3];

                for (x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        z = 2 * Math.Pow(x, 3) + 3 * Math.Pow(y, 3) + 6;

                        z = Math.Round(z, 3);

                        zFunc[nX, nY, 0] = x;
                        zFunc[nX, nY, 1] = y;
                        zFunc[nX, nY, 2] = z;
                    }
                }
            }
        }
    }
}
