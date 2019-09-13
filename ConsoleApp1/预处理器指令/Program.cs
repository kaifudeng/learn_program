using System;

namespace 预处理器指令
{
    class Program
    {
        static void Main(string[] args)
        {

            int j=dosomework(0.1);
            int dosomework(double x)
            {
                int i= 1;
                return i;
#if DEBUG
                Console.WriteLine("x is"+x);
#endif
            }
#define ENTERPRISE
            
        }

    }
}
