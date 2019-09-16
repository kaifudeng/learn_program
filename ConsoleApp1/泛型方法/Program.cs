using System;

namespace 泛型方法
{
    public class Account
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public Account(string name,Decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
    
    class Program
    {
       public void Swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        /*public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source)
        where TAccount:IAccount
        {
            decimal sum = 0;
            foreach(TAccount a in source)
            {
                sum += a.balance;
            }
            return sum;

        }
        public class Account:IAccount
        { }
        public interface IAccount
        {
            decimal balance { get; }
            string name { get; }
        }
        */
        public class MethodOverloads
        {
            public void foo<T>(T obj)
            {
                Console.WriteLine("Foo<T>(T obj), obj type:{0}", obj.GetType().Name);
            }
            public void foo(int x)
            {
                Console.WriteLine("Foo(int x)");
            }
            public void Bar<T>(T obj)
            {
                foo(obj);
            }
        }
        static void Main(string[] args)
        {
            int i, j;
            i = 4;
            j = 5;
            //Swap(ref i, ref j);

            

            var test = new MethodOverloads();
            test.foo(300);
            test.foo("abc");
            test.Bar(44);

        }
    }
}
