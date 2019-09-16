using System;

namespace 泛型接口
{
    public interface IComparable<in T>
    {
        int CompareTo(T other);
    }
    public class Person:IComparable<Person>
    {
        public string LastName;
        public int CompareTo(Person other)
        {
            
            return this.LastName.CompareTo(other.LastName);
        }
    }

    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return String.Format("Width:{0}  Height{1}",Width,Height);
        }

    }
    public class Rectangle:Shape
    {

    }
    public interface index<out T>
    {
        T this[int index] { get; }
        int Count { get; }
    }
    public class RectangleCollection:index<Rectangle>
    {
        private Rectangle[] data = new Rectangle[3]
        {
            new Rectangle{Height=2,Width=5 },
            new Rectangle{Height=3,Width=7},
            new Rectangle{Height=4.5,Width=10}
        };
        private static RectangleCollection coll;
        public static RectangleCollection GetRectangles()
        {
            return coll ?? (coll = new RectangleCollection());


        }
        public Rectangle this[int index]
        {
            get {
                if (index<0||index>data.Length)
                    throw new ArgumentOutOfRangeException("index");
                    return data[index];
                
                    }
        }
        public int Count
        {
            get
            {
                return data.Length;
            }
        }
    }

    public interface IDisplay<in T>
    {
        void Show(T item);
    }
    public class ShapeDisplay:IDisplay<Shape>
    {
        public void Show(Shape s)
        {
            Console.WriteLine("{0}Width:{1},Height{2}",s.GetType().Name,s.Width,s.Height);
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            void Display(Shape O)
            { }

            var r = new Rectangle { Width = 50,Height=100 };
            Display(r);

            Console.WriteLine("Hello World!");

            index<Rectangle> rectangles = RectangleCollection.GetRectangles();
            index<Shape> shapes = rectangles;
            for(int i=0;i<shapes.Count;i++)
            {
                Console.WriteLine(shapes[i]);
            }
            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(rectangles[0]);
        }
    }
}
