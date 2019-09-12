using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            x = A.plus(x);
            Console.WriteLine(x);
        }
    }
    class A
    {
        public static int plus(int x)
        {
            x += 1;
            return x;
        }
    }
}
