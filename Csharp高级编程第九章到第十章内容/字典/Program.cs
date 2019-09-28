using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
namespace 字典
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private readonly EmployeeId id;
        public Employee(string name,decimal salary,EmployeeId id)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public override string ToString()
        {
            return string.Format("{0}:{1,-20} {2:C}", id.ToString(), name, salary);
        }
    }
    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;
        public EmployeeId(string Id)
        {
            //Contract.Requires<ArgumentNullException>(Id != null);
            prefix = (Id.ToUpper())[0];
            int numlength = Id.Length - 1;
            try
            {
                number = int.Parse(Id.Substring(1, numlength > 6 ? 6 : numlength));
            }
            catch (FormatException)
            {
                throw new EmployeeIdException("Invalid EmployeeId format");
            }
        }
        public override string ToString()
        {
            return prefix.ToString() + string.Format("{0,6:00000}", number);
        }
        public override int GetHashCode()
        {
            return (number ^ number << 16) * 0x15051505;
        }
        public bool Equals(EmployeeId other)
        {
            if (other == null) return false;
            return (prefix == other.prefix && number == other.number);
        }
        public override bool Equals(object obj)
        {
            return Equals((EmployeeId)obj);
        }
        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(EmployeeId left,EmployeeId right)
        {
            return !(left == right);
        }
    }
    public class EmployeeIdException : Exception
    {
        public EmployeeIdException(string message) : base(message) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Dictionary<EmployeeId, Employee>();
            var idTony = new EmployeeId("C3755");
            var tony = new Employee( "tony stewart", 379025.00m,idTony );
            employees.Add(idTony, tony);
            Console.WriteLine(tony);
            var idcarl = new EmployeeId("F3547");
            var car1 = new Employee("carl",403466.00m,idcarl);
            employees.Add(idcarl, car1);
            Console.WriteLine(car1);
            var idkevin = new EmployeeId("C3386");
            var Kevin = new Employee("Kevin",415261.00m,idkevin);
            employees.Add(idkevin,Kevin);
            Console.WriteLine(Kevin);
            var idmatt = new EmployeeId("F3323");
            var matt = new Employee("Matt", 1589390.00m, idmatt);
            employees[idmatt] = matt;
            Console.WriteLine(matt);
            var idbrad = new EmployeeId("D3234");
            var brad = new Employee("brad", 322295.00m, idbrad);
            employees[idbrad] = brad;

            while (true)
            {
                Console.WriteLine("Enter employee id (X to exit)>>");
                var userinput = Console.ReadLine();
                userinput = userinput.ToUpper();
                if (userinput == "X") break;
                EmployeeId id;
                try
                {
                    id = new EmployeeId(userinput);
                    Employee employee;
                    if(!employees.TryGetValue(id,out employee))
                    {
                        Console.WriteLine("employee with id {0} is not found", id);
                    }
                    else
                    {
                        Console.WriteLine(employee);
                    }

                }catch(EmployeeIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
    }
}
