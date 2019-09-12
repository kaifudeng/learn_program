using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MyFirstClass
    {
       public static void f1()
        {
            Console.WriteLine("Hello from Wrox.");
            
            return;
        }
        public static void f2()
        {
            var name = "bugs bunny";
            var age = 25;
            var israbbit = true;
            

            Type nametype = name.GetType();
            Type agetype = age.GetType();
            Type israbbittype = israbbit.GetType();

            Console.WriteLine("name is type " + nametype.ToString());
            Console.WriteLine("age is type " + agetype.ToString());
            Console.WriteLine("israbbit is type" + israbbittype.ToString());


        }
        public static int f3 = 20;
        public static void f4()
        {
            int f3 = 30;
            Console.WriteLine(f3);
            return;
        }

        
    }
}
