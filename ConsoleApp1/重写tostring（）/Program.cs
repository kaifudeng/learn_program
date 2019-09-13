using System;

namespace 重写tostring__
{
    class money
    {
        private decimal aomount;
        public decimal Aomount
        {
            get
            {
                return aomount;
            }
            set
            {
                aomount = value;
            }   
        }
        public override string ToString()
        {
            return"$"+ Aomount.ToString();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            money cash1 = new money();
            cash1.Aomount=40M;
            Console.WriteLine("cash1.Aomount.ToString="+cash1.ToString());

        }
    }
}
