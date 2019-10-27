using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用指针优化性能
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How big an array do you want?\n");
            string userinput = Console.ReadLine();
            uint size = uint.Parse(userinput);
            unsafe
            {
                long* parray = stackalloc long[(int)size];
                for(int i = 0; i < size; i++)
                {
                    parray[i] = i * i;
                }
                for(int i = 0; i < size; i++)
                {
                    Console.WriteLine("Element {0}={1}", i, *(parray+i));
                }
                Console.Read();
            }
        }
    }
}
