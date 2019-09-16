using System;

namespace 数组
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format("{0}  {1}",FirstName,LastName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person[] myperson = new Person[2];
            myperson[0] = new Person { FirstName = "oula!", LastName = "muda!" };
            myperson[1] = new Person { FirstName = "jotairo", LastName = "dio" };

            int[][] juchi = new int[3][];//锯齿数组
            juchi[0] = new int[5] { 1,1,4,5,1};
            juchi[1] = new int[1] { 4 };
            juchi[2] = new int[4] { 5, 1, 1, 4 };
            for(int i=0;i<juchi.Length;i++)
            {
                for(int j=0;j<juchi[i].Length; j++)
                {
                    Console.Write(juchi[i][j]+"   ");
                }Console.WriteLine();
            }

            Array intArray = Array.CreateInstance(typeof(int),5);
            for(int i=0;i<5;i++)
            {
                intArray.SetValue(33,i);
            }
            for(int i=0;i<5; i++)
            {
                Console.WriteLine(intArray.GetValue(i));
            }

            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { 4, 5, 6 };
            Array racers = Array.CreateInstance(typeof(Person),arr1,arr2);

        }
    }
}
