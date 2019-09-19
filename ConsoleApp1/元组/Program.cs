using System;

namespace 元组
{
    public class MyClass
    {
        public static Tuple<int, int> Divide(int divdend, int divisor)
        {
            int result = divdend / divisor;
            int reminder = divdend % divisor;
            return Tuple.Create<int, int>(result, reminder);
        }
    }
    public class Tuple<T1,T2,T3,T4,T5,T6,T7,TRest>
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            var result = MyClass.Divide(5, 2);
            Console.WriteLine("result of division: {0},reminder: {1}", result.Item1, result.Item2);
            var tuple = Tuple.Create<string, string, int, int, string, double, int,Tuple<int, int>>
                ("ABC","CDE",1,2,"CBA",1.2,1,Tuple.Create<int, int>( 52,3490));    
        }
    }
}
