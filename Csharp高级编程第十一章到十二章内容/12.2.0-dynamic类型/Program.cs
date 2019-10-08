using System;

namespace _12._2._0_dynamic类型
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GetFullName()
        {
            return string.Concat(FirstName + " " + LastName);
        }
    }
    class StaticClass
    {
        public int IntValue = 100;
    }
    class DynamicClass
    {
        public dynamic DynValue = 100;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var staticperson = new Person();
            dynamic dynamicPerson = new Person();
            // staticperson.GetFullName("John", "Smith");
            //dynamicPerson.GetFullName("John", "Smith");

            dynamic dyn;
            dyn = 100;
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(dyn);
            dyn = "This is a string";
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(dyn);

            dyn = new Person() { FirstName = "Bugs", LastName = "Bunny" };
            Console.WriteLine(dyn.GetType());
            Console.WriteLine("{0} {1}", dyn.FirstName, dyn.LastName);

            StaticClass staticObject = new StaticClass();
            DynamicClass dynamicClass = new DynamicClass();
            Console.WriteLine(staticObject.IntValue);
            Console.WriteLine(dynamicClass.DynValue);
            Console.ReadLine();
        }
    }
}
