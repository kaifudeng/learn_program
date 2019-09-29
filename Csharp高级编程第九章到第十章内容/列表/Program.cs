using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace 列表
{
    
    public class Racer:IComparable<Racer>,IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Country { get; set; }
        public int Wins { get; set; }
        public Racer(int id,string firstname,string lastname,string country):this(id,firstname,lastname,country,wins:0)
        {
        }
        public Racer (int id,string firstname,string lastname,string country ,int wins)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Country = country;
            this.Wins = wins;
        }
        public override string ToString()
        {
            return string.Format("{0}    {1}", FirstName, LastName);
        }

        public string ToString(string format,IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch(format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return string.Format("{0}, Wins: {1}",ToString(),Wins);
                case "C":
                    return string.Format("{0}, Country: {1}", ToString(), Country);
                case "A":
                    return string.Format("{0}, {1} Wins: {2}", ToString(), Country, Wins);
                default: throw new FormatException(String.Format(formatProvider, "Format {0} is not supported", format));

            }
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            int compare = string.Compare(this.LastName, other.LastName);
            if(compare==0)
            return string.Compare(this.FirstName, other.FirstName);
            return compare;
            
        }
       
    }

    public class FindCountry
    {
        public FindCountry(string country)
        {
            this.country = country;
        }
        private string country;
        public bool findcountryPredicate(Racer racer)
        {
            Contract.Requires<ArgumentNullException>(racer != null);
            return racer.Country==country;
        }
    }
    public class RacerComparer : IComparer<Racer>
    {
        public enum ComparerType
        {
            FirstName,
            LastName,
            Country,
            Wins
        }
        private ComparerType comparerType;
        public RacerComparer(ComparerType comparerType)
        {
            this.comparerType = comparerType;
        }
        public int Compare(Racer x,Racer y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return 1;
            int result;
            switch (comparerType)
            {
                case ComparerType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case ComparerType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                case ComparerType.Country:
                    result = string.Compare(x.Country, y.Country);
                    if (result == 0)
                    {
                        return string.Compare(x.LastName, y.LastName);
                    }
                    else return result;
                case ComparerType.Wins:
                    return x.Wins.CompareTo(y.Wins);
                default:throw new ArgumentException("Invaild Compare Type");
            }
        }
    }

    public class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var grham = new Racer(7, "Grham", "Hill","UK",14);
            var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
            var mario = new Racer(16, "Mario", "Andretti", "USA", 12);
            var racers = new List<Racer>(20) { grham, emerson, mario };
            racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
            racers.Add(new Racer(27, "mika", "Hakkinen", "Finland", 20));

            racers.AddRange(new Racer[]
            {
                new Racer(14,"niki","lauda","austria",25),
                new Racer(21,"alain","prost","france",51)
            });

            racers.Insert(3, new Racer(6, "Phil", "Hill", "USA", 3));

            Racer r1 = racers[3];

            for (int i = 0; i < racers.Count; i++)
            {
                Console.WriteLine(racers[i]);
            }

            foreach(Racer r in racers)
            {
                Console.WriteLine(r);
            }
            //删除
            if(!racers.Remove(grham))
            {
                Console.WriteLine("object not found in collection");
            }
            racers.RemoveRange(1,2);

            //搜索
            int index1 = racers.IndexOf(mario);
            int index2 = racers.FindIndex(new FindCountry("Finland").findcountryPredicate);
            int index3 = racers.FindIndex(r => r.Country == "finland");
            List<Racer> Rlist = racers.FindAll(r => r.Wins > 20);
            foreach (Racer a in racers)
            {
                Console.WriteLine("{0:A}", a);
            }

            //排序
            racers.Sort();
            racers.ForEach(Console.WriteLine);

            racers.Sort(new RacerComparer(RacerComparer.ComparerType.Country));
            racers.ForEach(Console.WriteLine);

            //格式转换
            List<Person> people = racers.ConvertAll<Person>(r => new Person(r.FirstName + " " + r.LastName));

            //lookup类P265
            var lookupracers = racers.ToLookup(r => r.Country);
            foreach(Racer r  in lookupracers["Michael"])
            {
                Console.WriteLine(r);
            }

        }
        
        
    }
}
