using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Menu
    {
        public int id { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public DateTime? Day { get; set; }
        public MenuCard MenuCard { get; set; }
        public int MenuCardId { get; set; }
    }
}
