using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    public abstract class Person : IComparable<Person>
    {
        public string name;
        public int age;
        public string email;
        private int licenseId;

        public int LicenseId
        {
            get
            {
                // get will simply return licenseId but it can do any logic
                return licenseId;
            }

            set
            {
                // we will only set the licenseId if the person is older than 16
                if (age > 16)
                {
                    licenseId = value;
                }
            }
        }

        // if person1 < person2
        // if (Person)student1 < (Person)student2
        public static bool operator <(Person p1, Person p2)
        {
            return (p1.age < p2.age);
        }

        public static bool operator >(Person p1, Person p2)
        {
            return (p1.age > p2.age);
        }

        public static bool operator <=(Person p1, Person p2)
        {
            return (p1.age <= p2.age);
        }

        public static bool operator >=(Person p1, Person p2)
        {
            return (p1.age >= p2.age);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return (p1.age == p2.age);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return (p1.age != p2.age);
        }

        public virtual void Work()
        {
            Console.WriteLine("work work work");
        }

        public int CompareTo(Person p)
        {
            return this.name.CompareTo(p.name);
        }
    }

    public interface IStudent
    {
        void Party();
    }

    public interface IPerson
    {
        void Eat();
    }

    public class Student : Person, IPerson, IStudent
    {
        public double gpa;

        // if student1 < student2
        public static bool operator <(Student s1, Student s2)
        {
            return (s1.gpa < s2.gpa);
        }

        public static bool operator <=(Student s1, Student s2)
        {
            return (s1.gpa <= s2.gpa);
        }

        public static bool operator >(Student s1, Student s2)
        {
            return (s1.gpa > s2.gpa);
        }

        public static bool operator >=(Student s1, Student s2)
        {
            return (s1.gpa >= s2.gpa);
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return (s1.gpa == s2.gpa);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return (s1.gpa != s2.gpa);
        }

        public void Eat()
        {
            Console.WriteLine("Order a pizza!");
        }

        public void Party()
        {
            Console.WriteLine("Party on dude");
        }

    }

    public class Teacher : Person, IPerson
    {
        public string specialty;

        public override void Work()
        {
            // we can optionally call the parent's default method as well
            base.Work();
            Console.WriteLine($"I'll tell you all about {specialty}.");
        }

        public void Eat()
        {
            Console.WriteLine("I eat lots of apples.");
        }
    }

    // [+People|sortedList:SortedList<string, Person>|this:email;+Remove(email: string)]
    public class People
    {
        // the generic SortedList class uses a template <> to store indexed data
        // the first type is the data type to index on
        // the second type is the data type to store in the list
        // create a Sorted List indexed on email (string) and storing Person objects
        public SortedList<string, Person> sortedList = new SortedList<string, Person>();

        public void Remove(string email)
        {
            if (email != null)
            {
                sortedList.Remove(email);
            }
        }

        // indexer property allows array access to sortedList via the class object
        // and catching missing keys and duplicate key exceptions 
        // notice the indexer property definition shows how it will be used in the calling code:
        // if we have:
        //     People peopleList;
        // then we can call:
        //     peopleList[email] to access the Person object with that email address
        // and value will be the Person object (person) being added to the list in the case of:
        //     get example: profSchuh = peopleList['dxsigm@rit.edu']
        //     set example: peopleList[profSchuh.email] = profSchuh;
        public Person this[string email]
        {
            get
            {
                Person returnVal;
                try
                {
                    returnVal = (Person)sortedList[email];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    // we can add to the list using these 2 methods
                    //      sortedList.Add(email, value);
                    sortedList[email] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling
                }
            }
        }
    }

}