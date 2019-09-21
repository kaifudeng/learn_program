using System;
using System.Collections;
using System.Collections.Generic;

namespace 结构比较
{
    public class Person:IEquatable<Person>
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",Id,FirstName,LastName);
        }
        public override bool Equals(object obj)
        {
            if(obj==null)
            {
                return base.Equals(obj);
            }
            return Equals(obj as Person);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool Equals(Person other)
        {
            if(other ==null)
            {
                return base.Equals(other);
            }
            return this.Id == other.Id && this.FirstName == other.FirstName && this.LastName == other.LastName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var janet = new Person { FirstName = "jannet", LastName = "jackson" };
            Person[] persons1 = 
                {
            new Person
                {
                FirstName="Michael",
                LastName="Jackson"
                },
            janet
        };
        Person[] persons2 =
        {
            new Person
            {
                FirstName="Michael",
                LastName="Jackson"
            },
            janet
        };
            if (persons1 != persons2)
            {
                Console.WriteLine("not the same reference");
            }
            else { };
            if ((persons1 as IStructuralEquatable).Equals(persons2,EqualityComparer<Person>.Default))
            {
                Console.WriteLine("the same content");
            }
            else { };

            var t1 = Tuple.Create<int, string>(1, "Stephanie");
            var t2 = Tuple.Create<int, string>(1, "Stephanie");
            if (t1 != t2)
            {
                Console.WriteLine("not the same reference to the tuple");
            }
            else;
            if (t1.Equals(t2))
            {
                Console.WriteLine("the same content");
            }
            else;
            if (t1.Equals(t2,new TupleComparer()))
            {
                Console.WriteLine("epuals using TupleComparer");
            }
            else;
        }
        class TupleComparer:IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                return x.Equals(y);
            }
            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
