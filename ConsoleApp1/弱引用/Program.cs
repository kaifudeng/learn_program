using System;

namespace 弱引用
{
    class Program
    {
        static void Main(string[] args)
        {
            WeakReference weak = new WeakReference(new MathTest());
            MathTest math;
            if (weak.IsAlive)
            {
                math = weak.Target as MathTest;
                math.value = 30;
                Console.WriteLine("Vaule Field of math variable contains "+math.value);
                Console.WriteLine("square of 30 is "+math.GetSquare());
            }
            else
            {
                Console.WriteLine("weak is not available.");
            }
            GC.Collect();
            if (weak.IsAlive)
            {
                math = weak.Target as MathTest;
            }
            else
            {
                Console.WriteLine("weak is not available.");
            }
            
        }

    }
    class MathTest
    {
        public int value;

        public int GetSquare()
        {
            return value * value;
        }
        public static int GetSqureOf(int x)
        {
            return x * x;
        }
        public static double GetPI()
        {
            return 3.1415926;
        }
    }

}
