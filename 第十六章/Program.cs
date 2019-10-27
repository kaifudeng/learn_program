using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第十六章
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string userinput;
                    Console.WriteLine("Input a number between 0`5" +
                        "(or just hit return to exit)>");
                    userinput = Console.ReadLine();
                    if (userinput == "")
                    {
                        break;      
                    }
                    int index = Convert.ToInt32(userinput);
                    if (index < 0 || index > 5)
                    {
                        throw new IndexOutOfRangeException("You typed in " + userinput);

                    }
                    Console.WriteLine("Your number was " + index);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Exception: " +
                        "number should be between 0 and 5.{0}", ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(
                        "An exception was thrown.Message was :{0}", ex.Message);

                }
                finally
                {
                    Console.WriteLine("Thank you!");
                }
            }
        }
    }
}
