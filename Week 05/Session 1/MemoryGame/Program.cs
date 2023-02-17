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


        start:
            bTimeOut = false;

            string displayString = "";
            Random rand = new Random();
            Console.Clear();

            MyMethod();

            while (!bTimeOut)
            {
                displayString += (char)('A' + rand.Next(0, 26));
                foreach (char c in displayString)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(500);
                }

                Console.Clear();

                timeOutTimer = new Timer(displayString.Length * 500 + 1000);

                // Timer calls the Timer.Elapsed event handler when the time elapses
                // The Timer.Elapsed event handler uses a delegate function with the following signature:
                //        public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
                // This delegate method type is already defined for us by .NET
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

                timeOutTimer.Start();

                string sAnswer = null;
                sAnswer = Console.ReadLine();

                timeOutTimer.Stop();

                if (sAnswer.ToUpper() == displayString && !bTimeOut /* same as bTimeOut == false */ )
                {
                    Console.WriteLine("Well Done!  Your current score is {0}", displayString.Length);
                }
                else
                {
                    Console.WriteLine("Bad luck.  :(  The correct code was {0}.  Your final score is: {1}", displayString, displayString.Length - 1);

                    // set timeout to leave the while() loop
                    bTimeOut = true;
                }
            }

            Console.Write("Press Enter to Play Again");
            Console.ReadLine();

            goto start;

        }

        static void MyMethod()
        {
            Console.WriteLine("in my method");
        }

        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Your time is up!");
            Console.WriteLine("Please press enter");
            bTimeOut = true;
            timeOutTimer.Stop();
        }
    }
}
