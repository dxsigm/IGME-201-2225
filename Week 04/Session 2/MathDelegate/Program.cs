using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDelegate
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(int n1, int n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2);

    delegate double MathFunction(int n1, int n2);

    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = null;
            string sOperation = null;

            int nNum1 = 0;
            int nNum2 = 0;
            double nAnswer = 0;

            // prompt and convert first number
            do
            {
                Console.Write("Enter a number: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nNum1));

            // prompt and convert second number
            do
            {
                Console.Write("Enter another number: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nNum2));

            // prompt for operation
            do
            {
                Console.Write("Multiply or Divide: ");
                sOperation = Console.ReadLine();
            } while (!sOperation.ToLower().StartsWith("m") &&
                     !sOperation.ToLower().StartsWith("d"));

            //MathFunction processDivMult;
            Func<int, int, double> processDivMult;

            if (sOperation.ToLower().StartsWith("m"))
            {
                //nAnswer = Multiply(nNum1, nNum2);

                //processDivMult  = new MathFunction(Multiply);
                //processDivMult = Multiply;
                //
                //processDivMult = delegate (int n1, int n2)
                //{
                //    double returnVal = 0;
                //    returnVal = n1 * n2;
                //    return (returnVal);
                //};
                //
                //processDivMult = (int n1, int n2) =>
                //{
                //    double returnVal = 0;
                //    returnVal = n1 * n2;
                //    return (returnVal);
                //};
                //
                //processDivMult = (n1, n2) =>
                //{
                //    double returnVal = 0;
                //    returnVal = n1 * n2;
                //    return (returnVal);
                //};
                //
                //processDivMult = (n1, n2) => n1 * n2;

                processDivMult  = new Func<int,int,double>(Multiply);
                processDivMult = Multiply;
                
                processDivMult = delegate (int n1, int n2)
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return (returnVal);
                };
                
                processDivMult = (int n1, int n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return (returnVal);
                };
                
                processDivMult = (n1, n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return (returnVal);
                };
                
                processDivMult = (n1, n2) => n1 * n2;
            }
            else
            {
                //nAnswer = Divide(nNum1, nNum2);
                //processDivMult = new MathFunction(Divide);
                processDivMult = new Func<int, int, double>(Divide);
            }

            nAnswer = processDivMult(nNum1, nNum2);

            Action<double> outputAnswer;
            outputAnswer = new Action<double>(OutputAnswer);
            outputAnswer = OutputAnswer;

            outputAnswer = delegate (double d1)
            {
                Console.WriteLine("The answer is: {0}", d1);
            };

            outputAnswer = (double d1) =>
            {
                Console.WriteLine("The answer is: {0}", d1);
            };

            outputAnswer = (d1) =>
            {
                Console.WriteLine("The answer is: {0}", d1);
            };

            outputAnswer = (double d1) => Console.WriteLine("The answer is: {0}", d1);

            outputAnswer(nAnswer);
        }

        static void CallOutputAnswer(Action<double> outputAnswer, double dAnswer)
        {
            outputAnswer(dAnswer);
        }


        static void OutputAnswer(double dAnswer)
        {
            Console.WriteLine("The answer is: {0}", dAnswer);
        }


        static double Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        static double Divide(int num1, int num2)
        {
            return (double)num1 / num2;
        }

        static double Sum(int n1, int n2, int n3)
        {
            return n1 +n2 + n3;
        }

    }
}
