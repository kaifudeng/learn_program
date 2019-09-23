using System;
using System.Collections.Generic;
namespace BubbleSorter
{
    class Program
    {
        public class BubbleSorter
        {
            static public void Sort<T>(IList<T> sortArray,Func<T,T,bool> comparsion)
            {
                bool swapped = true;
                do
                {
                    swapped = false;
                    for (int i = 0; i < sortArray.Count - 1; i++)
                    {
                        if (comparsion(sortArray[i + 1], sortArray[i]))
                        {
                            T temp = sortArray[i];
                            sortArray[i] = sortArray[i + 1];
                            sortArray[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
        }
        class Employee
        {
            public Employee(string name,decimal salary)
            {
                this.Name = name;
                this.Salary = salary;
            }
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public override string ToString()
            {
                return string.Format("{0}, {1:c}", Name, Salary);
            }
            public static bool CompareSalary(Employee e1,Employee e2)
            {
                return e1.Salary > e2.Salary;
            }
        }
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("kaifudeng",20000),
                new Employee("kaifudeng2",10000),
                new Employee("kaifudeng3",25000),
                new Employee("kaifudeng4",100000.38m),
                new Employee("kaifudeng5",23000),
                new Employee("kaifudeng6",50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach(var employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
