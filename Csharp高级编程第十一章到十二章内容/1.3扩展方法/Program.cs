using System;
using System.Linq;
namespace _1._3扩展方法
{
    public static class StringExtension
    {

        public static void Foo(this string s)
        {
            Console.WriteLine("Foo invoked for {0}", s);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {


            string s = "hello";
            s.Foo();
        
        }
    }
}
