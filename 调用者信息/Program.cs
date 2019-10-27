using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace 调用者信息
{
    class Program
    {
        public void log([CallerLineNumber] int line = -1,
            [CallerFilePath] string path=null,
            [CallerMemberName] string name = null)
        {
            Console.WriteLine((line < 0) ? "No line" : "Line" + line);
            Console.WriteLine((path == null) ? "No file path " : path);
            Console.WriteLine((name == null) ? "No member name" : name);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.log();
            p.SomeProperty = 33;
            Action a1 = () => p.log();
            a1();
            Console.Read();
        }
        private int someProperty;
        public int SomeProperty
        {
            get { return someProperty; }
            set 
            {
                this.log();
                someProperty = value;
            }
        }
    }
}
