using System;
using 抄书的一些代码;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyFirstClass.f1();
            MyFirstClass.f2();
            Console.WriteLine(MyFirstClass.f3);
            MyFirstClass.f4();

            int x = 1;
            x = A.plus(x);
            x = A.reduce(x);
            Console.WriteLine(x);

            Vector z, y;
            z = new Vector();
            
            z.Value = 30;
            y = z;
            Console.WriteLine(y.Value);
            y.Value = 50;
            Console.WriteLine(z.Value);

            StringExample.s();
            MainEntryPoint.fff();

            writegreeting(TimeOfDay.Morning);
           void writegreeting(TimeOfDay timeofday)
            {
                switch (timeofday)
                {
                    case TimeOfDay.Morning:
                        Console.WriteLine("Good morning!");break;
                    case TimeOfDay.Afternoon:
                        Console.WriteLine("Good Afternoon!");break;
                    case TimeOfDay.Evening:
                        Console.WriteLine("Good Evening!");break;
                    default:
                        Console.WriteLine("Hello!");break;
                }
            }
        }
    }
    class A
    {
        public static int plus(int x)
        {
            x += 1;
            return x;
        }
        public static int reduce(int x)
        {
            x -= 1;
            return x;
        }
    }
    public enum TimeOfDay
    {
        Morning=0,
        Afternoon=1,
        Evening=2
    }
}
