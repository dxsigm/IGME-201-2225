using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialOOP
{
    class FactorialClass
    {
        public int nResult;

        public FactorialClass( int i )
        {
            nResult = Factorial(i);
        }

        public FactorialClass()
        {
        }

        private int Factorial(int v)
        {
            int returnVal;

            // base case: 0! = 1
            if (v == 0)
            {
                returnVal = 1;
            }
            else
            {
                returnVal = v * Factorial(v - 1);
            }

            return (returnVal);
        }
    }


    internal class Program
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

            FactorialClass factorial = new FactorialClass(nNumber);

            FactorialClass factorial2 = new FactorialClass();

            Console.Write($"{sNumber + "!"} = {factorial.nResult}");
        }
    }
}
