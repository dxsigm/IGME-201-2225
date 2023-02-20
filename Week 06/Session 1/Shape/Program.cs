using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public interface IDrawObject
    {
        void DrawMe();
    }

    public abstract class Shape : IDrawObject
    {
        public const double PI = Math.PI;
        public double x;
        protected double y;

        private int myInt;

        public Shape()
        {

        }

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual double Area()
        {
            double returnVal = x * y;
            return returnVal;
        }

        public abstract void DrawMe();
    }

    public class Blood : IDrawObject
    {
        public virtual void DrawMe()
        {
            // code to draw blood
        }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r,0)
        {

        }
        public override double Area()
        {
            double returnVal = PI * x * x;
            return returnVal;
        }

        public override void DrawMe()
        {
            /// code to specifically draw a circle
        }
    }

    internal class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {

        }
        public override double Area()
        {
            double returnVal = 4 * PI * x * x;
            return returnVal;
        }

        public override void DrawMe()
        {
            /// code to specifically draw a sphere
        }
    }

    internal class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h)
        {

        }
        public override double Area()
        {
            double returnVal = 2 * PI * x * x + 2 * PI * x * y; ;
            return returnVal;
        }

        public override void DrawMe()
        {
            /// code to specifically draw a cylinder
        }
    }

    internal class Rectangle : Shape
    {
        public Rectangle(double w, double h) : base(w, h)
        {

        }

        public bool IsSquare
        {
            get
            {
                if (x == y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void DrawMe()
        {
            /// code to specifically draw a rectangle
        }
    }

    public class Person
    {
        public string name;
    }

    public static class People
    {
        public static SortedList<string,Person> people = new SortedList<string,Person>();
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5.5);
            Cylinder cylinder = new Cylinder(3, 6);
            Rectangle rectangle = new Rectangle(1, 2);


            Person me = new Person();
            me.name = "david";
            People.people.Add(me.name, me);




            Shape shape;
            Rectangle pRectangle;
            Object obj;

            pRectangle = rectangle;
            obj = rectangle;

            // can implicitly set a parent type to a child type
            shape = rectangle;

            shape.x = 5;
            
            shape = circle;


            //Shape shape2 = new Shape();
            //Circle circle2;
            // cannot implicitly set a child type to a parent type
            //circle2 = shape2;



            PrintShapeArea(circle);
            PrintShapeArea(cylinder);

            Object myObj;
            object myObj2;

            myObj = circle;

            string myString = null;
            myObj = myString;

            List<Object> list= new List<Object>();
            list.Add("dave");
            list.Add(1);
            list.Add(circle);

            Blood blood = new Blood();

            DrawMyObject(blood);
            DrawMyObject(shape);

            DoSomethingWithMyObject(blood);
            DoSomethingWithMyObject(circle);
        }

        static void DrawMyObject(IDrawObject drawObject)
        {
            drawObject.DrawMe();
        }

        static void DoSomethingWithMyObject(Object obj)
        {

        }

        static void PrintShapeArea(Shape shape)
        {
            if ( shape.GetType() == typeof( Circle) )
            {
                Console.WriteLine("Your shape is a circle.");
            }

            // if our shape is a rectangle
            if (shape.GetType() == typeof(Rectangle))
            {
                // declare a reference Rectangle variable
                Rectangle r;

                // explicitly cast the parent shape variable to the child type
                r = (Rectangle)shape;

                // now we can access the IsSquare property
                if (r.IsSquare)
                {
                    Console.WriteLine("it's a square");
                }
                
            }

            if ( shape is Circle)
            {
                Console.WriteLine("Your shape is a circle.");
            }

            if( shape is IDrawObject)
            {
                IDrawObject drawObject = shape;
                drawObject.DrawMe();
            }

            Console.WriteLine("The area is: " + shape.Area());
        }
    }
}
