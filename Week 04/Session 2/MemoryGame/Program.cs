using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


/// delegate steps
/// 1. define the delegate method data type based on the method signature
///         delegate double MathFunction(double n1, double n2);
/// 2. declare the delegate method variable
///         MathFunction processDivMult;
/// 3. point the variable to the method that it should call
///         processDivMult = new MathFunction(Multiply);
/// 4. call the delegate method / add the delegate method to the object's event handler
///         nAnswer = processDivMult(n1, n2);
///         timer.Elapsed += TimesUp;

namespace MemoryGame
{
    static internal class Program
    {
        static Timer timeOutTimer;
        static bool bTimeOut = false;

        static void Main(string[] args)
        {
            string displayString = "";
            Random rand = new Random();
            Console.Clear();

            while(!bTimeOut)
            {
                displayString += (char)('A' + rand.Next(0, 26));
                foreach( char c in displayString)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(500);
                }

                Console.Clear();

            }
        }

        static void TimesUp(object sender, ElapsedEventArgs e)
        {

        }
    }
}
