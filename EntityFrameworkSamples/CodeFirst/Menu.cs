using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Menu
    {
        public int id { get; set; }
        [StringLength(50)]public string Text { get; set; }
        public decimal Price { get; set; }
        public DateTime? Day { get; set; }
        public MenuCard MenuCard { get; set; }
        public int MenuCardId { get; set; }
    }
}
