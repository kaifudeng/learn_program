using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace 序列化对象
{
    public class Inventory
    {
        private Product[] stuff;
        public Inventory() { }
        //[XmlArrayItem("Prod",typeof(Product)),
          //  XmlArrayItem("Book",typeof(BookProduct))]
        public Product[] InventoryItems
        {
            get { return stuff; }
            set { stuff = value; }
        }
        /*public override string ToString()
        {
            StringBuilder outText = new StringBuilder();
            foreach(Product prod in stuff)
            {
                outText.Append(prod.ProductName);
                outText.Append("\r\n");
            }
            return outText.ToString();
        }*/
    }
}
