using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> dPersonAge = new Dictionary<string,int>();

            dPersonAge["david"] = 50;

            // trying to add 2 items with the same key will generate a runtime exception
            dPersonAge.Add("david", 65);

            // you can update existing values in the SortedList by referencing an existing key
            dPersonAge["david"] = 51;

            foreach (KeyValuePair<string, int> thisPerson in dPersonAge)
            {
                Console.WriteLine("person[{0}] = {1}", thisPerson.Key, thisPerson.Value);
            }

            SortedList<string, int> personAge = new SortedList<string, int>();

            personAge["david"] = 50;

            // trying to add 2 items with the same key will generate a runtime exception
            personAge.Add("david", 65);

            // you can update existing values in the SortedList by referencing an existing key
            personAge["david"] = 51;

            personAge.Add("joe", 80);

            // if you try to remove an index that doesn't exist, it will throw a runtime exception
            personAge.Remove("joe");

            foreach( KeyValuePair<string, int> thisPerson in personAge )
            {
                Console.WriteLine("person[{0}] = {1}", thisPerson.Key, thisPerson.Value);
            }

        }
    }
}
