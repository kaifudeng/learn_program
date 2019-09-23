using System;

namespace 委托
{
    class Program
    {
        struct Currency
        {
            public uint Dollars;
            public ushort Cents;
            public Currency(uint dollars, ushort cents)
            {
                this.Dollars = dollars;
                this.Cents = cents;
            }
            public override string ToString()
            {
                return String.Format("${0}.{1,-2:00}", Dollars, Cents);
            }
            public static implicit operator float(Currency value)
            {
                return value.Dollars + (value.Cents / 100.0f);
            }
            public static explicit operator Currency(float value)
            {
                checked
                {
                    uint dollars = (uint)value;
                    ushort cents = Convert.ToUInt16((value - dollars) * 100);
                    return new Currency(dollars, cents);
                }
            }
            public static implicit operator Currency(uint value)
            {
                return new Currency(value, 0);
            }
            public static string GetCurrencyUint()
            {
                return "Dollar";
            }
            public static implicit operator uint(Currency value)
            {
                return value.Dollars;
            }
        }
        class MathOperations
        {
            public static double MultiplyByTwo(double value)
            {
                return value * 2;
            }
            public static double square(double value)
            {
                return value * value;
            }
        }
        public delegate string GetAString();
        public delegate double DoubleOp(double x);
        static void ProcessAndDisplayNumber(DoubleOp action,double value)
        {
            double result = action(value);
            Console.WriteLine("value is {0},result of opreation is {1}",value,result);
        }
        static void Main(string[] args)
        {
            int x = 40;
            GetAString firstStringMethod = new GetAString(x.ToString);
            Console.WriteLine("string is {0}", firstStringMethod());
            Currency balance = new Currency(34, 50);
            firstStringMethod = balance.ToString;
            Console.WriteLine("string is {0}", firstStringMethod());
            firstStringMethod = new GetAString(Currency.GetCurrencyUint);
            Console.WriteLine("string is {0}", firstStringMethod());

            //委托的简单例子 P195
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.square
            };
            for (int i=0;i<operations.Length ;i++ )
            {
                Console.WriteLine("Using operations[{0}]: ", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i],7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            
        }
    }
}
