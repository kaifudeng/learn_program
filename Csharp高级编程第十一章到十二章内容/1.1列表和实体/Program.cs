using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._1列表和实体
{
    class Program
    {
        [Serializable]
        public class Racer : IComparable<Racer>, IFormattable
        {
            public Racer(string firstName,string lastName,string country,int starts,int wins):
                this(firstName,lastName,country,starts,wins,null,null)
            {

            }
            public Racer(string firstName,string lastName,string country,int starts,int wins,
                IEnumerable<int> years,IEnumerable<string> cars)
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
            public IEnumerable<int> Years { get;private set; }
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
            public string ToString(string format,IFormatProvider formatProvider)
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
                        return string.Format("{0} {1},{2}; starts:{3},wins:{4}", FirstName, LastName,Country, Starts, wins);
                    default:throw new FormatException(string.Format("Format {0} not supported", format));
                }
            }
        }//赛车手类
        public class Team
        {
            public string Name { get;private set; }
            public IEnumerable<int> Years { get; private set; }
            public Team(string name,params int[] years)
            {
                this.Name = name;
                this.Years =new List<int>(years);
            }
        }//车队类
        public class Formulal
        {
            private static List<Racer> racers;
            public static IList<Racer> GetChampions()
            {
                if (racers == null)
                {
                    racers = new List<Racer>(40);
                    racers.Add(new Racer("Nino", "Farina", "Italy", 33, 5, new int[] { 1950 }, new string[] { "Alfa Romeo" }));
                    racers.Add(new Racer("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952,1953 }, new string[] { "Ferrari" }));
                    racers.Add(new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }));
                    racers.Add(new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }));
                    racers.Add(new Racer("Denny", "Hulme", "New zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }));
                    racers.Add(new Racer("kaifu", "deng", "china", 50, 50, new int[] { 1998 }, new string[] { "koishisegaiyiji!" })); ;
                }
                return racers;
            }
        }

        private static List<Team> teams;
        public static IList<Team> GetContructorChampions()
        {
            if (teams == null)
            {
                teams = new List<Team>()
                {
                    new Team("Vanwall",1958),
                    new Team("Cooper",1959,1960),
                    new Team("Ferrari",1961,1964,1975,1976,1977,1979),
                    new Team("Brabham",1966,1967),
                    new Team("Matra",1969),
                    new Team("koishisegaiyiji!",2006)

                };
                return teams;
            }return teams;
        }

        private static void LinqQuery()
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "china"
                        orderby r.wins descending
                        select r;
            foreach(Racer r in query)
            {
                Console.WriteLine("{0:A}",r);
            }
        }
        static void Main(string[] args)
        {
            LinqQuery();
            
        }
    }
}
