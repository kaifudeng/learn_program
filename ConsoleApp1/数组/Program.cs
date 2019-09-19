using System;
using System.Collections;


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
        {public int CompareTo();
}
    class Program
    {
        static void Main(string[] args)
        {
            //GameMoves的测试
            var game = new GameMoves();
            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
            {
                enumerator = enumerator.Current as IEnumerator;
            }
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
            static int SumOfSegments(ArraySegment<int>[] segments)
            {
                int sum = 0;
                foreach(var segment in segments)
                {
                    for(int i = segment.Offset; i < segment.Offset + segment.Count; i++)
                    {
                        sum += segment.Array[i];
                    }
                }
                return sum;
            }
            int[] ar1 = { 1, 4, 5, 11, 13, 18 };
            int[] ar2 = { 3, 4, 5, 18, 21, 27 };
            var segments = new ArraySegment<int>(2)
            {
                new ArraySegment<int>(ar1,0,3),
                new ArraySegment<int>(ar2,3,3)
            };
            //枚举的部分
            IEnumerator<Person> enumerator = persons.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Person p = enumerator.Current;
                Console.WriteLine(p);
            }

    }
        static Person[] GetPerson()
        {
            return new Person[]
            {
                new Person{FirstName="dodo",LastName="dori"},
                new Person{FirstName="shit",LastName="act3"},
                new Person{FirstName="star",LastName="sign"}
            };
        }
        public class HelloCollection
        {
            /*public IEnumerator<string> GetEnumerator()
            {
                yield return "Hello";
                yield return "World";
            }*/
            public IEnumerator GetEnumerator()
            {
                return new Enumerator(0);
            }
            public class Enumerator:IEnumerator<string>,IEnumerator,IDisposable
            {
                private int state;
                private string current;

                public Enumerator(int state)
                {
                    this.state = state;
                }
                bool IEnumerator.MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            current = "Hello";
                            state = 1;
                            return true;
                        case 1:
                            current = "World";
                            state = 2;
                            return true;
                        case 2:
                            break;
                    }
                    return false;
                }
                void IEnumerator.Reset()
                {
                    throw new NotSupportedException();
                }
                string IEnumerator<string>.current
                {
                    get { return current; }
                }
                object IEnumerator.Current
                {
                    get { return current; }
                }
                void IDisposable.Dispose()
                { }
            }
        }
        public void HelloWorld()
        {
            var hellocollection = new HelloCollection();
            foreach (var s in hellocollection)
            {
                Console.WriteLine(s);
            }
        }
        public class MusicTitle
        {
            string[] names =
            {
                "Tubular Bells","Hergest Ridge","Ommadawn",
                "Platinum"
            };
            public IEnumerator<string> GetEnumerator()
            {
                for(int i=0;i<4 ;i++ )
                {
                    yield return names[i];
                }
            }
            public IEnumerator<string> Reverse()
            {
                for(int i=3;i>=0;i--)
                {
                    yield return names[i];
                }
            }
            public IEnumerable<string> Subset(int index,int length)
            {
                for(int i=index;i<index+length;i++)
                {
                    yield return names[i];
                }
            }

        }
        //yeild语句的练习
        public class GameMoves
        {
            private IEnumerator cross;
            private IEnumerator circle;
            public GameMoves()
            {
                cross = Cross();
                circle = Circle();
            }
            private int move = 0;
            const int MaxMove = 9;
            public IEnumerator Cross()
            {
                while (true)
                {
                    Console.WriteLine("Cross, Move{0}", move);
                    if(++move>=MaxMove)
                        yield break;
                    yield return circle;
                }
            }
            public IEnumerator Circle()
            {
                while(true)
                {
                    Console.WriteLine("Circle Move{0}",circle);
                    if(++move>=MaxMove)
                    {
                        yield break;
                    }
                    yield return cross;
                }
            }
        }
}
}
