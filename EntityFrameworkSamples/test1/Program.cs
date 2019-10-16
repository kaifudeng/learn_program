using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DimArea dimArea = new DimArea();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using(var data =new BIDWDemoEntities())
            {
                foreach (var area in data.DimHour)
                {
                    Console.WriteLine(area.HourKey);
                }
            }
            Console.Read();
        }
    }
    
}
