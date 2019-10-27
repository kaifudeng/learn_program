using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 指针
{
    class Program
    {
       public struct MyStruct
        {
            public long x;
            public float F;
        }
        public class MyClass
        {
            public long x;
            public float f;
        }
        internal struct CurrencyStruct
        {
            public long Dollars;
            public byte Cents;

            public override string ToString()
            {
                return "$" + Dollars + "." + Cents;
            }
        }
        internal class CurrencyClass
        {
            public long Dollars;
            public byte Cents;
            public override string ToString()
            {
                return "$" + Dollars + "." + Cents;
            }
        }
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();


            /*unsafe
            {
                fixed (long* pObject = &(myClass.x))
                {
                    *pObject = 222222;
                    Console.WriteLine(myClass.x);
                }

                MyStruct* pStruct;
                MyStruct myStruct = new MyStruct();
                pStruct=&myStruct;
                pStruct->F = 3.4f;
                pStruct->x = 1000000;
                //………………
                int x = 10;
                int* px, py;
                px = &x;
                py = px;
                *py = 20;
                uint y = (uint)px;
                int* pd = (int*)y;
                Console.WriteLine("Address is {0}", (uint)px);
                Console.WriteLine("Address is {0}", (uint)py);
                Console.WriteLine("py&is {0}", (uint)&py);
                Console.Read();
            }*/
            unsafe
            {
                Console.WriteLine(
                    "Size of CurrencyStruct struct is " + sizeof(CurrencyStruct));
                CurrencyStruct amount1, amount2;
                CurrencyStruct* pAmount = &amount1;
                long* pdollars = &(pAmount->Dollars);
                byte* pcents = &(pAmount->Cents);

                Console.WriteLine("Address of amount1 is 0x{0:x}", (uint)&amount1);
                Console.WriteLine("Address of amount2 is 0x{0:x}", (uint)&amount2);
                Console.WriteLine("Address of pAmount is 0x{0:x}", (uint)&pAmount);
                Console.WriteLine("Address of pdollars is 0x{0:x}", (uint)&pdollars);
                Console.WriteLine("Address of pcents is 0x{0:x}", (uint)&pcents);
                pAmount->Dollars = 20;
                *pcents = 50;
                Console.WriteLine("amount1 contains" + amount1);
                --pAmount;
                Console.WriteLine("amount2 has address 0x{0:x} and contain{1}", 
                    (uint)pAmount, *pAmount);
                CurrencyStruct* ptempcurrency = (CurrencyStruct*)pcents;
                pcents = (byte*)(--ptempcurrency);
                Console.WriteLine("address of pcents is now 0x{0:x}", (uint)&pcents);
                Console.WriteLine("\nnow with classes");
                CurrencyClass amount3 = new CurrencyClass();
                fixed (long* pdollars2 = &(amount3.Dollars))
                    fixed(byte*pcents2=&(amount3.Cents))
                {
                    Console.WriteLine("amount3.dollars has address 0x{0:X}", (uint)pdollars2);
                    Console.WriteLine("amount3.cents has address 0x{0:X}", (uint)pcents2);
                    *pdollars2 = -100;
                    Console.WriteLine("amount3 contains" + amount3);
                }
                Console.Read();
            }
        }
        
    }
}
