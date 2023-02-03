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
    enum GenderPronoun // : int by default
    {
        him,  // 0
        her,
        them
    }

    enum CollegeYear : byte
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
        enum ClassEnum
        {
            IGME_200,
            IGME_201,
            IGME_202
        }

        static void Main(string[] args)
        {
            int i = (int)ConsoleColor.Black;

            {
                StudentStruct student = new StudentStruct();
                StudentStruct maxStudent = new StudentStruct("Max Lama");
                maxStudent.dGrade = 3.5;

            }
        }
    }
}
