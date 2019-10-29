using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 序列化对象
{
   public class BookProduct:Product
    {
        private string isbnNum;
        public BookProduct() { }
        public string ISBN
        {
            get { return isbnNum; }
            set { isbnNum = value; }
        }

    }
}
