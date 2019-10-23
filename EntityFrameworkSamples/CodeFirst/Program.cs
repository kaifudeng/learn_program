using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
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

            using(var data=new MenuContext())
            {
                
                MenuCard menuCard = data.MenuCards.Create();
                menuCard.Text = "Soups";
                data.MenuCards.Add(menuCard);

                Menu m = data.Menus.Create();
                m.Text = "Baked Potato Soup";
                m.Price = 4.80M;
                m.Day = new DateTime(2012, 9, 20);
                m.MenuCard = menuCard;
                data.Menus.Add(m);

                Menu m2 = data.Menus.Create();
                m2.Text = "Cheddar Broccoli Soup";
                m2.Price = 4.50M;
                m2.Day = new DateTime(2012, 9, 20);
                m2.MenuCard = menuCard;
                data.Menus.Add(m2);
                try 
                {
                    data.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Application.Run(new Form1());
        }
    }
}
