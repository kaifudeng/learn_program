using System;


namespace 数组
{
    public class Person:IComparable<Person>
    {
        public int CompareTo(Person other)
            {
              if(other==null)return 1;
              int result=string.Compare(this.LastName,other.LastName);
              if(result==0)
              {
                result=string.Compare(this.FirstName,other.FirstName);
              }
              return result;
            }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format("{0}  {1}",FirstName,LastName);
        }
    }
    public interface IComparable<Person>
        {CompareTo();
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

            //Setvalue（）方法
            racers.SetValue(new Person
                {
                FirstName="Alain",
                LastName="Prost"
                },index1:1,index2:10);
            racers.SetValue(new Person
                {
                FirstName="Emerson",
                LastName="Fittipaldi"
                },1,11);
            racers.SetValue(new Person
                {
                FirstName="Ayrton",
                LastName="Senna"},1,12);
            racers.SetValue(new Person
                {
                FirstName="Michael",
                LastName="Schumacher"},2,10);
            racers.SetValue(new Person
                {
                FirstName="Fernando",
                LastName ="Alonso"},2,11);

            Person[,] racers2=(Person[,])racers; 
            Person First=racers2[1,10];
            Person Last=racers2[2,12];

            //复制数组
            int[] intArray1={1,2};
            int[] intArray2=(int[])intArray1.clone();

            Person[] beatles={
                                              new Person{FirstName="John",LastName="Lennon"},
                                              new Person{FirstName="Paul",LastName="McCartney"}
                                        };
            Person[] beatlesClone=(Person[])beatles.clone();

            //数组排序
            string[] names=
                {
                  "AAA",
                  "BBB",
                  "CCC",
                  "DDD"
                };
            Array.Sort(names);
            foreach(var name in names)
                {
                Console.WriteLine(name);
                }

            Person[] persons=
                {
                new Person{FirstName="AAA",LastName="aaa"},
                new Person{FirstName="BBB",LastName="bbb"},
                new Person{FirstName="DDD",LastName="ddd"},
                new Person{FirstName="CCC",LastName="ccc"}
                };
            Array.Sort(persons);
            foreach(var p in persons)
                {
                Console.WriteLine(p);
                }
    }
}
}
