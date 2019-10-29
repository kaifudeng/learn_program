using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace 序列化对象
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product pd = new Product();
            pd.CategoryID = 100;
            pd.ProductName = "Serialize Objects";
            pd.UnitPrice = 1000;
            pd.QuantityPerUnit = "6";
            pd.SupplierID = 1;

            TextWriter tr = new StreamWriter("serialprod.xml");
            XmlSerializer sr = new XmlSerializer(typeof(Product));
            sr.Serialize(tr, pd);
            tr.Close();
            WebBrowser wb = new WebBrowser();
            wb.Navigate(AppDomain.CurrentDomain.BaseDirectory + "serialprod.xml");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product newpd;
            FileStream f = new FileStream("serialprod.xml", FileMode.Open);
            XmlSerializer newsr = new XmlSerializer(typeof(Product));
            newpd = (Product)newsr.Deserialize(f);
            f.Close();
            MessageBox.Show(newpd.ToString());

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlAttributes attrs = new XmlAttributes();
            attrs.XmlElements.Add(new XmlElementAttribute("book", typeof(BookProduct)));
            attrs.XmlElements.Add(new XmlElementAttribute("Product", typeof(Product)));
            XmlAttributeOverrides attrOver = new XmlAttributeOverrides();
            attrOver.Add(typeof(Inventory), "InventoryItems", attrs);
            Product newProd = new Product();
            BookProduct newbook = new BookProduct();
            newProd.ProductName = "Product Thing";
            newProd.SupplierID = 10;
            newbook.ProductName = "How to Use Your new Product Thing";
            newbook.SupplierID = 10;
            newbook.ISBN = "123456789";
            Product[] addProd = { newProd,newbook };
            Inventory inv = new Inventory();
            inv.InventoryItems = addProd;
            TextWriter tr = new StreamWriter("inventory.xml");
            XmlSerializer sr = new XmlSerializer(typeof(Inventory), attrOver);
            sr.Serialize(tr, inv);
            tr.Close();
            WebBrowser wb = new WebBrowser();
            wb.Navigate(AppDomain.CurrentDomain.BaseDirectory + "inventory.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlAttributes attrs = new XmlAttributes();
            attrs.XmlElements.Add(new XmlElementAttribute("Book", typeof(BookProduct)));
            attrs.XmlElements.Add(new XmlElementAttribute("Product", typeof(Product)));
            XmlAttributeOverrides attrOver = new XmlAttributeOverrides();
            attrOver.Add(typeof(Inventory), "InventoryItems", attrs);

            Product newProd = new Product();
            BookProduct newbook = new BookProduct();
            newProd.ProductName = "Product Thing";
            newProd.SupplierID = 10;
            newbook.ProductName = "How to Use Your Product Thing";
            newbook.SupplierID = 11;
            newbook.ISBN = "123456789";
            Product[] addProd = { newProd, newbook };

            Inventory inv = new Inventory();
            inv.InventoryItems = addProd;
            TextWriter tr = new StreamWriter("inventory.xml");
            XmlSerializer sr = new XmlSerializer(typeof(Inventory), attrOver);
            sr.Serialize(tr, inv);
            tr.Close();
        }
    }
}
