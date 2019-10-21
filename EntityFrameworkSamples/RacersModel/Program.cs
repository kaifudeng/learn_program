using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacersModel
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TrackingDemo();
            Application.Run(new Form1());

        }
        private static void TrackingDemo()
        {
            using(var data=new Formula1v2Entities())
            {
                Racers niki1 = (from r in data.Racers
                                where r.Nationality == "Austria" && r.LastName == "Lauda"
                                select r).First();
                Racers niki2 = (from r in data.Racers
                                where r.Nationality == "Austria"
                                orderby r.Wins descending
                                select r).First();
                if (Object.ReferenceEquals(niki1, niki2))
                {
                    Console.WriteLine("Same Object");
                }
            }
        }
        private static void ObjectStateManager_ObjectStateManagerChanged(
            object sender,CollectionChangeEventArgs e)
        {
            Console.WriteLine("Object state change --action:{0}", e.Action);
            Racers r = e.Element as Racers;
            if (r != null)
            {
                Console.WriteLine("Racer {0}", r.LastName);
            }
        }
    }
}
