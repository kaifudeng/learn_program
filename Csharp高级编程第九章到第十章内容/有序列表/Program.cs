using System;
using System.Collections.Generic;
namespace 有序列表
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new SortedList<string, string>();
            books.Add("WPF Programming", "978-0-470-04180-2");
            books.Add("ASP.NET MVC 3", "978-0-1180-7658-3");
            books["beginning Visual C# 2010"] = "978-0-470-50225-6";
            books["C# 4 and.NET 4"] = "978-0-470-50225-9";
            foreach(string book in books.Values)
            {
                Console.WriteLine(book);
            }
            foreach(string key in books.Keys)
            {
                Console.WriteLine(key);
            }

            string isbn;
            string title = "C# 4 and.NET 4";
            if (!books.TryGetValue(title, out isbn))
            {
                Console.WriteLine("{0} not found", title);
            }
            else Console.WriteLine("found {0}", title);
        }
    }
}
