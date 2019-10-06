using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _4._0表达式树
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
    }//赛车手类
    class Program
    {
        private static void DisplayTree(int indent,string message ,Expression expression)
        {
            string output = String.Format("{0} {1} ! NodeType:{2} ;Expr{3} ", 
                "".PadLeft(indent, '>'), message, expression.NodeType, expression);
            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    LambdaExpression lambdaExpr = (LambdaExpression)expression;
                    foreach (var parameter in lambdaExpr.Parameters)
                    {
                        DisplayTree(indent, "Parameter", parameter);
                    }
                    DisplayTree(indent, "Body", lambdaExpr.Body);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constExpr = (ConstantExpression)expression;
                    Console.WriteLine("{0} Const Value:{1}", output, constExpr.Value);
                    break;
                case ExpressionType.Parameter:
                    ParameterExpression paramExpr = (ParameterExpression)expression;
                    Console.WriteLine("{0} Param Type:{1} ",output,paramExpr.Type.Name);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                    BinaryExpression binExpr = (BinaryExpression)expression;
                    if (binExpr.Method != null)
                    {
                        Console.WriteLine("{0} Method: {1}", output, binExpr.Method.Name);
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    DisplayTree(indent, "Left", binExpr.Left);
                    DisplayTree(indent, "Right", binExpr.Right);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpr = (MemberExpression)expression;
                    Console.WriteLine("{0} Member Name:{1} ,Type:{2}", output,
                        memberExpr.Member.Name, memberExpr.Type.Name);
                    DisplayTree(indent, "member Expr", memberExpr.Expression);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("{0} {1} ", expression.NodeType, expression.Type.Name);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Expression<Func<Racer, bool>> expression =
                r => r.Country == "china" && r.wins > 6;
            DisplayTree(0, "lambda", expression);
        }
    }
}
