using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._0标准的查询操作符
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
    public class Team
    {
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public Team(string name, params int[] years)
        {
            this.Name = name;
            this.Years = new List<int>(years);
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
                racers.Add(new Racer("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Denny", "Hulme", "New zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }));
                racers.Add(new Racer("kaifu", "deng", "china", 50, 50, new int[] { 1998 }, new string[] { "koishisegaiyiji!" })); ;
            }
            return racers;
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
            }
            return teams;
        }
        private static List<Championship> championships;
        public static IEnumerable<Championship> GetChampionships()
        {
            if (championships == null)
            {
                championships = new List<Championship>();
                championships.Add(new Championship
                {
                    year = 1950,
                    first = "Nino Far",
                    second = "Juan Man",
                    third = "Luigi Fag"
                });
                championships.Add(new Championship
                {
                    year = 1951,
                    first = "Juan Man",
                    second = "Alberto Mix",
                    third = "Froilan Gon"
                });
                championships.Add(new Championship
                {
                    year = 1952,
                    first = "Duang duang",
                    second = "Clberto Asc",
                    third = "lilyan Liz"
                });
                return championships;
            }return championships;
        }
    }
    public class Championship
    {
        public int year { get; set; }
        public string first { get; set; }
        public string second { get; set; }
        public string third { get; set; }
    }
    public class RacerInfo
    {
        public int year { get; set; }
        public int position { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public static class StringExrension
    {
        public static string FirstName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(0, ix);
        }
        public static string LastName(this string name)
        {
            int ix = name.LastIndexOf(" ");
            return name.Substring(ix + 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var racers = from r in Formulal.GetChampions()
                         where r.wins > 15 && (r.Country == "china" || r.Country == "italy")
                         select r;
            foreach(Racer racer in racers)
            {
                Console.WriteLine("{0:A}",racer);
            }

            var racers2 = Formulal.GetChampions().Where(r=>r.wins>5&&
            (r.Country=="china"||r.Country=="Italy")).Select (r=>r);
            foreach (Racer racer in racers2)
            {
                Console.WriteLine("{0:A}", racer);
            }

            var racers3 = Formulal.GetChampions().Where((r, Index) => r.LastName.StartsWith("A")
           && Index % 2 != 0);
            foreach(Racer r in racers3)
            {
                Console.WriteLine("{0:A}", r);
            }

            //Oftype方法
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query = data.OfType<string>();
            foreach(var s in query)
            {
                Console.WriteLine(s);
            }

            //复合的from子句
            var ferrariDrivers = from r in Formulal.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;
           foreach(var r in ferrariDrivers)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine();
            //排序
            var racers4 = from r in Formulal.GetChampions()
                          where r.Country == "Italy"
                          orderby r.wins descending
                          select r;
            foreach(var r in racers4)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();

            var racers5 = (from r in Formulal.GetChampions()
                           orderby r.Country, r.LastName, r.FirstName
                           select r).Take(5);
            foreach(var r in racers5)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine();
            //分组
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 1
                            select new
                            {
                                Country = g.Key,
                                count = g.Count(),
                                Racers = from r1 in g
                                         orderby r1.LastName
                                         select r1.FirstName + " " + r1.LastName
                            };
            foreach (var item in countries)
            {
                Console.WriteLine("{0,-10} {1}", item.Country, item.count);
                foreach(var name in item.Racers)
                {
                    Console.Write("{0};", name);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //内连接 左外连接
            var racers6 = from r in Formulal.GetChampions()
                          from y in r.Years
                          select new
                          {
                              Year = y,
                              Name = r.FirstName + " " + r.LastName
                          };
            var teams = from t in Formulal.GetContructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };
            var racersAndteams = (from r in racers6
                                  join t in teams on r.Year equals t.Year
                                  into rt from t in rt.DefaultIfEmpty()
                                  select new
                                  {
                                      r.Year,
                                      Champion = r.Name,
                                      Constructor=t==null?"no constructor championship":t.Name
                                  }).Take(5);
            Console.WriteLine("Year world champion\t Constructor Title");
            foreach(var item in racersAndteams)
            {
                Console.WriteLine("{0}:{1,-20} {2}", item.Year, item.Champion, item.Constructor);
            }

            Console.WriteLine();
            //组连接
            var racers7 = Formulal.GetChampionships()
                .SelectMany(cs => new List<RacerInfo>()
                {
                    new RacerInfo
                    {
                        year=cs.year,
                        position=1,
                        firstname=cs.first.FirstName(),
                        lastname=cs.first.LastName(),
                    },
                    new RacerInfo
                    {
                        year=cs.year,
                        position=1,
                        firstname=cs.second.FirstName(),
                        lastname=cs.second.LastName(),
                    },
                    new RacerInfo
                    {
                        year=cs.year,
                        position=1,
                        firstname=cs.third.FirstName(),
                        lastname=cs.third.LastName(),
                    }

                });
            var q = (from r in Formulal.GetChampions()
                     join r2 in racers7 on
                     new
                     {
                         FirstName = r.FirstName,
                         LastName = r.LastName
                     }
                     equals
                     new
                     {
                         FirstName = r2.firstname,
                         LastName = r2.lastname
                     }
                     into yearResults
                     select new
                     {
                         FirstName = r.FirstName,
                         LastName=r.LastName,
                         Wins=r.wins,
                         Starts=r.Starts,
                         Result=yearResults
                     }
                     );
            foreach(var r in q)
            {
                Console.WriteLine("{0} {1}", r.FirstName, r.LastName);
                foreach(var result in r.Result)
                {
                    Console.WriteLine("{0} {1}.", result.year, result.position);
                }
            }

        }
    }
}
