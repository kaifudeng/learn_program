using System;

namespace 用户定义的类型强制转换
{
    class Program
    {
        struct Currency
        {
            public uint Dollars;
            public ushort Cents;
            public Currency(uint dollars,ushort cents)
            {
                this.Dollars = dollars;
                this.Cents = cents;
            }
            public override string ToString()
            {
                return String.Format("${0}.{1,-2:00}", Dollars,Cents);
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
            public static implicit operator uint(Currency value)
            {
                return value.Dollars;
            }
        }
        static void Main(string[] args)
        {
            Currency balance = new Currency(10, 50);
            float f = balance;

            float amount = 45.63f;
            Currency amount2 = (Currency)amount;

            try
            {
                Currency balance2 = new Currency(50, 35);
                Console.WriteLine(balance2);
                Console.WriteLine("balance2 is " + balance2);
                Console.WriteLine("banlance2 is (Using ToString())" + balance2.ToString());
                float balance3 = balance2;
                Console.WriteLine("After converting to float, = " + balance3);
                balance2 = (Currency)balance3;
                Console.WriteLine("After converting back to Currency,=" + balance2);
                Console.WriteLine("Now attempt to convert out of range value of" +
                    "-$50.50 to a Currency:");

                checked
                {
                    balance2 = (Currency)(-50.50);
                    Console.WriteLine("result is " + balance2.ToString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
            }

            //类之间的转换
            object derivedObject = new Currency(40, 0);
            object baseObject = new object();
            Currency d1 = (Currency)derivedObject;
            

            //多重类型转换
            Currency bal = new Currency(10, 50);
            long amo = (long)bal;
            double amoD = bal;

            try
            {
                Currency b = new Currency(50, 35);
                Console.WriteLine(b);
                Console.WriteLine("b is  " + b);
                Console.WriteLine("b is (Using ToString())" + b.ToString());
                uint bu = (uint)b;
                Console.WriteLine("converting to uint gives " + bu);
            }
            catch { }
            
        }
    }
}
