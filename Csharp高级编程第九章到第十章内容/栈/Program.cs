using System;
using System.Collections.Generic;

namespace 栈
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = new Stack<char>();
            alphabet.Push('a');
            alphabet.Push('b');
            alphabet.Push('c');
            Console.WriteLine("First iteration: ");
            foreach(char i in alphabet)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine("Second iteration: ");
            while (alphabet.Count > 0)
            {
                Console.WriteLine(alphabet.Pop());
            }
            Console.WriteLine();
        }
    }
}
