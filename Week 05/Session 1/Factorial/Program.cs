using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = null;
            int nNumber = 0;
            int nAnswer = 0;

            do
            {
                Console.Write("Enter a positive integer: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nNumber) && nNumber <= 0);

            nAnswer = 1;

            while( nNumber > 0)
            {
                nAnswer *= nNumber;
                --nNumber;
            }


        }

        static int Factorial(int v)
        {
            int returnVal;

            returnVal = v * Factorial(v-1);

            return (returnVal);
        }
    }
}
