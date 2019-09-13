using System;

namespace 控制台练习
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 129;
            int j = 20;
            Console.WriteLine(" {0,5}\n +{1,4}\n--\n {2,5}", i, j, i + j);
            Console.WriteLine();

            /*decimal x = 940.22m;
            decimal y = 73.7m;
            Console.WriteLine("{0,10:C2}\n+{1,9:C2}\n--\n{2,10:C2}", x, y, x + y);*/
        }
    }
    ///<summary>
    ///控制台练习.Program.
    ///Provides a method to add two integers.
    /// </summary>
    public class newclass
    {
        ///<summary>
        ///The add method allows us to add two integers.
        /// </summary>
        /// <return>Result of the addtion (int)</return>
        /// <param name="x">first number to add</param>
        /// <param name="y">second number to add</param>
        public int add(int x, int y)
        {
            return x + y;
        }
    }
}
