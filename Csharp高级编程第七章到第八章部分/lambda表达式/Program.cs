using System;
using System.Collections.Generic;

namespace lambda表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            string mid = ",middle part";
            Func<string, string> lambda = param =>
               {
                   param += mid;
                   param += " and this was added to the string";
                   return param;
               };
            Console.WriteLine(lambda("start of string"));

            //使用foreach语句的闭包
            var values = new List<int>() { 10, 20, 30 };
            var funcs = new List<Func<int>>();
            foreach(var val in values)
            {
                funcs.Add(()=>val);
            }
            foreach(var f in funcs)
            {
                Console.WriteLine(f());
            }
        }
    }
}
