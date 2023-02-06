using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace MethodsEnumStruct
{
    // enums can be declared in namespace or within class
    // these enums are accessible to all code in the namespace

    // private by default
    enum GenderPronoun // : int by default
    {
        him,  // 0
        her,
        them
    }

    // can specify public accessibility
    public enum CollegeYear : byte
    {
        freshman = 26,
        sophomore = 25,
        junior = 24,
        senior = 23
    }

    struct StudentStruct
    {
        public string sName;
        private string sPassword;
        public GenderPronoun eGender;
        public CollegeYear eCollegeYear;
        public double dGrade;

        // property = meth-ield
        // studentStruct.Password = "password1234";  // this will call Pass.set(value = "password1234")
        public string Password  // read-write property with complex get/set methods
        {
            get
            {
                return (Decrypt(this.sPassword));
            }

            set
            {
                this.sPassword = Encrypt(value);
            }
        }

        private string Decrypt(string pw)
        {
            string decryptedValue = "";
            char[] cPassword;

            cPassword = pw.ToCharArray();
            foreach (char c in cPassword)
            {
                decryptedValue += (c + 1);
            }

            return decryptedValue;
        }

        private string Encrypt(string pw)
        {
            string decryptedValue = "";
            char[] cPassword;

            cPassword = pw.ToCharArray();
            foreach (char c in cPassword)
            {
                decryptedValue += (c - 1);
            }

            return decryptedValue;
        }

        // int nAge
        public int Age  // read/write property with only the default get/set methods, so it acts just like an int field
        {
            get;
            set;
        }

        public double Grade  // read-only property
        {
            get
            {
                return (this.dGrade);
            }
        }

        public CollegeYear PCollegeYear  // write-only property
        {
            set
            {
                this.eCollegeYear = value;
            }
        }


        // int s = studentStruct.SelfRefProperty;
        // AVOID SELF-REFERENTIAL PROPERTIES!!!
        public int SelfRefProperty
        {
            get
            {
                return (this.SelfRefProperty);
            }

            set
            {
                this.SelfRefProperty = value;
            }
        }

        public StudentStruct(string sName, double dGrade)
        {
            this.eCollegeYear = CollegeYear.freshman;
            this.eGender = GenderPronoun.them;
            this.sName = sName;
            this.dGrade = dGrade;
            sPassword = "";
            Age = 0;
            // don't have to initialize Properties that have code blocks
        }

        public StudentStruct(string sName)
        {
            this.eCollegeYear = CollegeYear.freshman;
            this.eGender = GenderPronoun.them;
            this.sName = sName;
            this.dGrade = 4;
            sPassword = "";
            Age = 0;
        }

    }

    static internal class Program
    {
        // enums can be declared for use within a class as well
        public enum ClassEnum
        {
            IGME_200,
            IGME_201,
            IGME_202
        }

        public struct ZFunction
        {
            public double dX;
            public double dY;
            public double dZ;

            public ZFunction(double dX, double dY)
            {
                this.dX = dX;
                this.dY = dY;
                this.dZ = 2 * Math.Pow(dX, 3) + 3 * Math.Pow(dY, 3) + 6;
                this.dZ = Math.Round(this.dZ, 3);
            }
        }

        static void Main(string[] args)
        {
            int i = (int)ConsoleColor.Black;

            {
                StudentStruct sStudent;
                StudentStruct student = new StudentStruct();
                StudentStruct maxStudent = new StudentStruct("Max Lama");
                StudentStruct maxGStudent = new StudentStruct("Max Lama", 3.5);
                maxStudent.dGrade = 3.5;

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
                //double[,,] zFunc = new double[81, 36, 3];
                ZFunction[] zArray = new ZFunction[81 * 36];

                int dataPointCntr = 0;

                for (x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        ZFunction thisDataPoint = new ZFunction(x, y);
                        zArray[dataPointCntr++] = thisDataPoint;

                        // zArray[dataPointCntr++] = new ZFunction(x,y);
                    }
                }
            }

        }
    }
}
