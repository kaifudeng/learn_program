using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class MenuContext:DbContext
    {
        private const string connectionString =
            @"server=(localdb)\v11.0;database=DemoMenus;" +
            "trusted_connection=true";
        public MenuContext():base(connectionString)
          
        {
        }

       
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCard> MenuCards { get; set; }
    }
}
