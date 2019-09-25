using System;
using System.Text;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    class Program
    {
        //P231
        static void WriteMatchs(string text,MatchCollection matches)
        {
            Console.WriteLine("text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);

            foreach(Match next in matches)
            {
                int index = next.Index;
                string result = next.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5 ) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;
                Console.WriteLine("index:{0},\tString:{1},\t{2}",index,result,text.Substring(index-charsBefore,charsToDisplay));

            }
        }
        static void find()
        {
            string text = @"this comprehensive compendium provides a broad and thorough investigation of all aspects of programming
        with ASP.NET. Entirely revised and updated for the fourth release of .NET,this book will give you the information
        you need to master ASP.NET and build a dynamic,successful,enterprise Web application.";
            string p = @"\ba";
            MatchCollection matches = Regex.Matches(text, p, RegexOptions.IgnoreCase);
            WriteMatchs(text, matches);
        }
        //P232
        static void find2()
        {
            string text = @"http://www.wrox.com:4355";
            string p = @"\b(\S+)://([^:]+)(?::(\S))?\b";
            MatchCollection matches = Regex.Matches(text, p, RegexOptions.IgnoreCase);
            WriteMatchs(text, matches);
        }

        static void Main(string[] args)
        {
            const string myText =
        @"this comprehensive compendium provides a broad and thorough investigation of all aspects of programming
        with ASP.NET. Entirely revised and updated for the fourth release of .NET,this book will give you the information
        you need to master ASP.NET and build a dynamic,successful,enterprise Web application.";
            const string pattern = "ion";
            MatchCollection myMatches = Regex.Matches(myText, pattern, 
                RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            foreach(Match nextmatch in myMatches)
            {
                Console.WriteLine(nextmatch.Index);
            }
            const string pat2 = @"\bn";
            MatchCollection myMatches2 = Regex.Matches(myText, pat2,
                RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            Console.WriteLine();
            //P231
            find();
            Console.WriteLine();
            find2();
        }
    }
}
