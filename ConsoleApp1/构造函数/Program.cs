﻿using System;
using System.Drawing;

namespace 构造函数
{
    public class UserPreferences
    {
        public static readonly ConsoleColor backcolor;
        static UserPreferences()
        {
            DateTime Now = DateTime.Now;
            if (Now.DayOfWeek == DayOfWeek.Saturday || Now.DayOfWeek == DayOfWeek.Sunday)
                backcolor = ConsoleColor.Green;
            else backcolor = ConsoleColor.Red;
        }
        private UserPreferences() { }
    }

    class Car
    {
        private string description;
        private uint nWheels;
        readonly int i;
        public Car(string description,uint nWheels)
        {
            this.description = description;
            this.nWheels = nWheels;

        }
        public Car(string description):this(description,4)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(UserPreferences.backcolor.ToString());
            Car newcar = new Car("process");
            

        }
    }
}
