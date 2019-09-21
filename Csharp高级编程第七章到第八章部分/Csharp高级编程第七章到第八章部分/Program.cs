using System;

namespace 运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            //递增运算符前置与后置的区别
            int x = 5;
            if (++x == 6)
            {
                Console.WriteLine("This will execute");
            }
            if (x++ == 7)
            {
                Console.WriteLine("this won't");
            }
            else;

            //三元运算符
            string s = x + " ";
            s += (x == 1 ? "man" : "men");
            Console.WriteLine(s);

            //checked运算符
            byte b = 254;
            checked
            {
                b++;
            }
            unchecked
            {
                b++;
            }
            Console.WriteLine(b);

            //is运算符
            int i = 10;
            if (i is object)
            {
                Console.WriteLine("i is an object");
            }

            //as运算符
            object obj1 = "some string";
            object obj2 = 5;
            string s1 = obj1 as string;
            string s2 = obj2 as string;
            Console.WriteLine(s1, s2);

            //sizeof运算符
            Console.WriteLine(sizeof(int));

            //typeof运算符
            Console.WriteLine(typeof(string));

            //可空类型和运算符
            int? a =null;
            int? v = a + 4;
            int? c = a * 5;
            int? d = -5;
            if (a >= b)
            {
                Console.WriteLine("a>=b");
            }
            else
                Console.WriteLine("a<b");

            //空合并运算符
            int e;
            e = a ?? 10;//e get 10
            a = 3;         //if a!=null
            e = a ?? 10;//e get a 

            //类型转换
            byte value1 = 10;
            byte value2 = 23;
            long total;
            total = value1 + value2;
            Console.WriteLine(total);

            //显式转换
            double price = 25.30;
            int approximatePrice = (int)(price + 0.5);//四舍五入

            ushort f = 43;
            char symbol = (char)f;
            Console.WriteLine(symbol);//会输出“+”

            double[] Price = { 25.30, 26.20, 15, 20, 42.40 };
            ItemDetails id;
            id.Description = "hello there.";
            id.ApproxPrice = (int)(Price[0] + 0.5);

            string str = "100";
            int j = int.Parse(str);
            Console.WriteLine(j + 50);

            //装箱和拆箱
            int myint = 20;
            object box = myint;
            int mysecint = (int)box;

            //ReferenceEquals()方法
            SomeClass z, y;
            z = new SomeClass();
            y = new SomeClass();
            bool b1 = ReferenceEquals(null, null);
            bool b2 = ReferenceEquals(null, z);
            bool b3 = ReferenceEquals(z, y);

            
        }
        public class SomeClass
        { }
        struct ItemDetails
        {
            public string Description;
            public int ApproxPrice;
        }

    }
}
