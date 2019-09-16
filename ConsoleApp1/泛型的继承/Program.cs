using System;

namespace 泛型的继承
{
    public abstract class Calc<T>
    {
        public abstract T Add(T x, T y);
        public abstract T Sub(T x, T y);
    }
    public class IntCalc:Calc<int>
    {
        public override int Add(int x,int y)
        { return x + y; }
        public override int Sub(int x,int y)
        { return x - y; }
    }
    public class StaticDemo<T>
    { public static int x; }

    class Program
    {
        
            
        static void Main(string[] args)
        {
            StaticDemo<int>.x = 5;
            StaticDemo<string>.x = 4;
            Console.WriteLine(StaticDemo<int>.x);
            Console.WriteLine(StaticDemo<string>.x);
        }
    }
}
