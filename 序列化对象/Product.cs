using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace 序列化对象
{
    public class Product
    {
        private int prodId;
        private string prodName;
        private int suppId;
        private int catId;
        private string qty;
        private decimal unit;
        private int disc;
        [XmlAttributeAttribute(AttributeName="Discount")]
        public int Discount
        {
            get { return disc; }
            set { disc = value; }
        }
        [XmlElementAttribute()]
        public string ProductName
        {
            get { return prodName; }
            set { prodName = value; }
        }
        [XmlElementAttribute()]
        public int SupplierID
        {
            get { return suppId; }
            set { suppId = value; }
        }
        [XmlElementAttribute()]
        public int CategoryID
        {
            get { return catId; }
            set { catId = value; }
        }
        [XmlElementAttribute()]
        public string QuantityPerUnit
        {
            get { return qty; }
            set { qty = value; }
        }
        [XmlElementAttribute()]
        public decimal UnitPrice
        {
            get { return unit; }
            set { unit = value; }
        }
        public override string ToString()
        {
            StringBuilder outText = new StringBuilder();
            outText.Append(prodId);
            outText.Append(" ");
            outText.Append(prodName);
            outText.Append(" ");
            outText.Append(unit);
            return outText.ToString();
        }

    }
}
