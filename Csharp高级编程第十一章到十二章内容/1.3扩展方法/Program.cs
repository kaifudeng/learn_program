using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._3扩展方法
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public Racer(string firstName, string lastName, string country, int starts, int wins) :
            this(firstName, lastName, country, starts, wins, null, null)
        {

        }
        public Racer(string firstName, string lastName, string country, int starts, int wins,
            IEnumerable<int> years, IEnumerable<string> cars)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.wins = wins;
            this.Country = country;
            this.Starts = starts;
            this.Years = years;
            this.Cars = cars;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public int wins { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.LastName, other.LastName);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return wins.ToString();
                case "A":
                    return string.Format("{0} {1},{2}; starts:{3},wins:{4}", FirstName, LastName, Country, Starts, wins);
                default: throw new FormatException(string.Format("Format {0} not supported", format));
            }
        }
    }
    public class Formulal
    {
        private static List<Racer> racers;
        public static IList<Racer> GetChampions()
        {
            if (racers == null)
            {
                racers = new List<Racer>(40);
                racers.Add(new Racer("Nino", "Farina", "Italy", 33, 5, new int[] { 1950 }, new string[] { "Alfa Romeo" }));
                racers.Add(new Racer("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Denny", "Hulme", "New zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }));
                racers.Add(new Racer("kaifu", "deng", "china", 50, 50, new int[] { 1998 }, new string[] { "koishisegaiyiji!" })); ;
            }
            return racers;
        }
    }
    public static class StringExtension
    {

        public static void Foo(this string s)
        {
            Console.WriteLine("Foo invoked for {0}", s);
        }

        public static IEnumerable<TSource> where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        
    }

    
    class Program
    {
        public void ExtensionMethods()
        {
            var champions = new List<Racer>(Formulal.GetChampions());
            IEnumerable<Racer> brazilChampions =
                champions.where(r => r.Country == "china").OrderByDescending
                (r => r.wins).Select(r => r);
            foreach(Racer racer in brazilChampions)
            {
                Console.WriteLine("{0:A}",racer);
            }
                

        }

        static void Main(string[] args)
        {


            string s = "hello";
            s.Foo();
        
        }
    }
}
