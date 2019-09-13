using System;


namespace 类和结构
{
    class PhoneCustomer
    {
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;
        public string FirstName;
        public string LastName;
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
    class ParameterTest
    {
        static void SomeFuntion(int[] ints,ref int i)
        {
            ints[0] = 100;
            i = 100;
        }
        public static void f2()
        {
            int i = 0;
            int[] ints = {0,1,2,4,8 };
            Console.WriteLine("i="+i);
            Console.WriteLine("ints[0]="+ints[0]);
            Console.WriteLine("Calling SomeFuntion");

            SomeFuntion(ints,ref i);
            Console.WriteLine("i="+i);
            Console.WriteLine("ints[0]="+ints[0]);
            Console.WriteLine(" ");
        }

    }
    class test
    {
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhoneCustomer Customer1 = new PhoneCustomer();
            Customer1.FirstName = "Simon";
            Console.WriteLine("Hello World! {0}",Customer1.FirstName);
            MathEntryPoint.f1();
            ParameterTest.f2();
        }
    }
    class MathEntryPoint
    {
        public static void f1 ()
        {
            Console.WriteLine("PI is "+MathTest.GetPI());
            int x = MathTest.GetSqureOf(5);
            Console.WriteLine("Squre Of 5 is "+x );
            MathTest mathTest = new MathTest();
            mathTest.value = 30;
            Console.WriteLine("Squre of 30 is"+mathTest.GetSquare());



        }
    }
}
