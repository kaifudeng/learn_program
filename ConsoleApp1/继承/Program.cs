using System;

namespace 继承
{
    class CustomerAccount
    {
        public virtual decimal CalculatePrice()
        {
            return 0.0M;
        }
    }
    class GoldAccount:CustomerAccount
    {
        public override decimal CalculatePrice()
        {
            return base.CalculatePrice()*0.9M;
        }
    }
    abstract class Building //抽象类的构建
    {
        public abstract decimal CalculateHeatingCost();
    }

    public abstract class GenericCustomer
    {
        private string name;
        public GenericCustomer(string name):base()
        {
            this.name = name;
        }
    }
    class Nevermore60Customer : GenericCustomer
    {
        private int highCostMinutesUsed;
        private string referrerName;
        public Nevermore60Customer(string name,string referrername):base(name) 
        {
            this.referrerName = referrername;
        }
        public Nevermore60Customer(string name):this(name,"<None>")
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericCustomer customer = new Nevermore60Customer("");

        }
    }
}
