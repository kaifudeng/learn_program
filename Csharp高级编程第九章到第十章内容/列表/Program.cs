using System;

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
    class Program
    {

        static void Main(string[] args)
        {
           
        }
    }
}
