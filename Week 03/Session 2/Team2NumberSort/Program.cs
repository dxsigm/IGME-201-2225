using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2NumberSort
{
    internal class Program
    {
        // Purpose: Sort a list of numbers
        // Restrictions: 0 and double.MaxValue cannot be in the list of numbers
        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            double[] aUnsorted = new double[5];
            double[] aSorted = new double[5];

            int i = 0;
            int j = 0;
            int k = 0;

            //Data Validation
            // Doesn't work :(
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a list of space-separated numbers");

                    // read the space-separated string of numbers
                    string sNumberString = Console.ReadLine();

                    // split the string into the an array of strings which are the individual numbers
                    //string[] sNumbers = sNumberString.Split(',');  // logic error, should split by space
                    string[] sNumbers = sNumberString.Split(' ');

                    //try to parse each value
                    //for (int i = 0; i < sNumberString.Length; i++)  // logic error, should be sNumbers.Length
                    for( i = 0; i < sNumbers.Length; i++)
                    {
                        aUnsorted[i] = double.Parse(sNumbers[i]);
                    }

                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter valid numbers");
                }
            }
            // SORTING

            // loop through unsorted array   // code/comment mismatch!
            for (i = 0; i < aSorted.Length; i++)
            {
                //double tempSortInt = aUnsorted[0];  // logic error: need to start tempSortInt from double.MaxValue
                double tempSortInt = double.MaxValue;
                //for (j = 0; j < aUnsorted.Length; j++)  // logic error: should start from 0
                for (j = 0; j < aUnsorted.Length; j++)
                {
                    // Checks already sorted numbers
                    for (k = 0; k < aSorted.Length; k++)
                    {
                        // If it exists in the sorted array, skip to the next number
                        //if (aSorted[k] == tempSortInt)  // logic error: should be checking the current unsorted number, not the current lowest number
                        if (aSorted[k] == aUnsorted[j])
                        {
                            //tempSortInt = aUnsorted[j]; // logic error: should not be setting tempSortInt without comparison and we do not want to set lowest number to a number that was already sorted
                            // I hope this only breaks out of the current loop.  (yes it does!)
                            break;
                        }
                    }

                    // logic error: should only check j if not already sorted
                    if( k == aSorted.Length)
                    {
                        //check if the current temp num is lower than the next number in the unsorted array.
                        //if (tempSortInt < aUnsorted[j])  // logic error: should check if next number or is less than current temp num
                        if (aUnsorted[j] < tempSortInt)
                        {
                            tempSortInt = aUnsorted[j];
                        }
                    }
                }
                aSorted[i] = (double)tempSortInt;
            }
        }
    }
}
