using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StringExample
    {
        public static  void s()
        {
            string s1 = "a string";
            string s2 = s1;
            Console.WriteLine("s1 is"+s1);
            Console.WriteLine("s2 is"+s2);
            s1 = "another string";
            Console.WriteLine("s1 is now" +s1);
            Console.WriteLine("s2 is now"+s2);

        }
    }
}
