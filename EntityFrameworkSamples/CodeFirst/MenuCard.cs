﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class MenuCard
    {
        public int id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
