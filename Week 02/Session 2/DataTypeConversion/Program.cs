using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversion
{
    // Class: Examples
    // Author: David Schuh
    // Purpose: Contains examples for Week 2
    // Restrictions: Only contains code snippets.  
    static internal class Examples
    {
        // Method: Main
        // Purpose: The main entry point for the executable. Code snippet examples.
        // Restrictions: None
        static void Main(string[] args)
        {
            {
                double doubleNum = 9999.999;
                float floatNum = 999.9F;
                long longInt = -12345678;   // Int64 (64-bit)
                ulong ulongInt = 12345678;  // UInt64
                int intNum = -786;          // Int32
                uint uintNum = 786;         // UInt32
                short shortInt = -789;      // Int16
                ushort ushortInt = 456;     // UInt16
                byte byteNum = 254;         // 8-bit unsigned
                sbyte sbyteNum = -123;      // 8-bit signed

                // you can implicitly set a data type equal to a lesser type
                longInt = shortInt;
                uintNum = byteNum;

                // this will generate a compile-time error
                //byteNum = shortInt;

                // Explicit Casting
                // but I can explicitly cast it
                // the source data will be truncated if it does not fit in the target variable
                // byteNum will only hold the lowest 8 bits of 16-bit shortInt
                byteNum = (byte)shortInt;

                // checked will raise a run-time exception if data will be lost
                byteNum = checked((byte)shortInt);

                // Convert.ToInt32()
                // we can also explicitly cast using the Convert Class
                // Convert also raises run-time exceptions if data will be lost
                byteNum = Convert.ToByte(shortInt);

                string sNumber = null;
                bool bValid = false;

                do
                {
                    // notice with TryParse() we do not need try/catch
                    bValid = int.TryParse(sNumber, out intNum);

                    if( !bValid)
                    {
                        Console.WriteLine("Please enter only digits.");
                    }

                    try
                    {
                        Console.Write("Enter a number: ");

                        sNumber = Console.ReadLine();

                        intNum = Convert.ToInt32(sNumber);

                        // each data type has a Parse() and TryParse() method to parse a string to the data type
                        // for example, Int32 which is the same as int
                        intNum = Int32.Parse(sNumber);
                        intNum = int.Parse(sNumber);

                        // if it reaches this line, then the conversion was successful and we can set bValid = true
                        bValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter only digits.");
                        bValid = false;
                    }
                } while (!bValid /* bValid == false */ );


            }
        }
    }
}
