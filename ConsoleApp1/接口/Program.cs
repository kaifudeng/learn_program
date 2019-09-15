using System;
using 接口.JupiterBank;
using 接口.VenusBank;
namespace 接口
{
    public interface IBankAccount
    {
        void PayIn(decimal amount);
        bool Withdraw(decimal amount);
        decimal Balance { get; }
    }

    namespace VenusBank
    {
        public class SaverAccount : IBankAccount
        {
            private decimal balance;
            public void PayIn(decimal amout)
            {
                balance += amout;
            }
            public bool Withdraw(decimal amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    Console.WriteLine("Withdrawal attempt failed.");
                }
                return false;
            }
            public decimal Balance
            {
                get { return balance; }

            }
            public override string ToString()
            {
                return String.Format("Venus Bank Saver:Balance={0,6:c}",balance);
            }
        }
    }
    namespace JupiterBank
    {
        public class GoldAccount : IBankAccount
        {
            private decimal balance;
            public void PayIn(decimal amount)
            {
                balance += amount;
            }
            public bool Withdraw(decimal amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    return true;
                }
                else { Console.WriteLine("余额不足。"); return false; }
            }
            public decimal Balance
            {
                get { return balance; }
            }
            public override string ToString()
            {
                return String.Format("账户余额：{0,6:c}", balance);
            }
        }
    }
    class Program
    {
    static void Main(string[] args)
     {
            IBankAccount VensAccount = new SaverAccount();
            IBankAccount JupiterAccount = new GoldAccount();
            VensAccount.PayIn(200);
            VensAccount.Withdraw(100);
            Console.WriteLine(VensAccount.ToString());
            JupiterAccount.PayIn(500);
            JupiterAccount.Withdraw(600);
            JupiterAccount.Withdraw(100);
            Console.WriteLine(JupiterAccount.ToString());

            
            
        }
    }
}

