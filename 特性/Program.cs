using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple =false,
        Inherited =false)]
    public class FieldNameAttribute : Attribute
    {
        private string name;
        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public FieldNameAttribute(string name)
        {
            this.name = name;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FieldNameAttribute f = new FieldNameAttribute("kaifudeng");
            Console.WriteLine(f);
            Console.ReadLine();

        }
    }
}
