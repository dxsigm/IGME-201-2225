using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        public class SingletonClass
        {
            // because the instance object is static, it is created as soon as the app runs
            private static SingletonClass instance = new SingletonClass();

            // notice for singletons that the constructor is private
            private SingletonClass()
            {

            }

            // the public GetInstance() method returns a reference to the static object
            public static SingletonClass GetInstance() 
            {
                return instance;
            }

            // singletons are useful for generating logs
            public void OpenLogFile()
            {
                // open the log file
            }

            public void WriteToLog(string message)
            {
                // write the log message to the log file
            }
        }
        static void Main(string[] args)
        {
            // use the GetInstance() method to fetch the reference to the class object
            // there will only ever be 1 SingletonClass object (thus it is a singleton!)
            SingletonClass singleton = SingletonClass.GetInstance();
        }
    }
}
