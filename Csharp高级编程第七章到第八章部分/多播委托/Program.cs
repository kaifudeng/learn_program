using System;

namespace 多播委托
{
    class Program
    {
        class MathOperations
        {
            public static void MultiplyByTwo(double value)
            {
                double result = 2 * value;
                Console.WriteLine("Multiplying by 2:{0} gives {1}",value,result);
            }
            public static void Square(double value)
            {
                double result = value * value;
                Console.WriteLine("Multiplying by 2: {0} gives {1}",value,result);
            }
            
        }
        public static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            Console.WriteLine();
            Console.WriteLine("ProcessAndDisplayNumber called with value={0}", value);
            action(value);
        }
        static void Main(string[] args)
        {
            Action<double> operations = MathOperations.MultiplyByTwo;
            operations += MathOperations.Square;
            ProcessAndDisplayNumber(operations,2.0);
            ProcessAndDisplayNumber(operations, 7.94);
            ProcessAndDisplayNumber(operations, 1.414);
            Console.WriteLine();
        }
    }
}
