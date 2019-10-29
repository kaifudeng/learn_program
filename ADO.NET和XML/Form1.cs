using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.IO;

namespace ADO.NET和XML
{
    public partial class Form1 : Form
    {
        string _connectString = "Server=.;Database=adventureworkslt;Trusted_Connection=Yes";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            DataSet ds = new DataSet("XMlProducts");
            SqlConnection conn = new SqlConnection(_connectString);
            SqlDataAdapter da = new SqlDataAdapter
                ("SELECT Name,StandardCost From Products", conn);
            da.Fill(ds, "Products");
            dataGridView1.DataSource = ds.Tables["products"];

            MemoryStream memstrm = new MemoryStream();
            StreamReader strmread = new StreamReader(memstrm);
            StreamWriter strmWrite = new StreamWriter(memstrm);

            ds.WriteXml(strmWrite, XmlWriteMode.IgnoreSchema);
            memstrm.Seek(0, SeekOrigin.Begin);
            doc.Load(strmread);
            XmlNodeList nodelist = doc.SelectNodes("//Products");
            richTextBox1.Text = "";
            foreach(XmlNode node in nodelist)
            {
                richTextBox1.Text += node.InnerText + "\r\n";
            }
            string file = "products.xml";
            ds.WriteXml(file);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDataDocument doc;
            DataSet ds = new DataSet("XMLProducts");
            SqlConnection conn = new SqlConnection(_connectString);
            SqlDataAdapter da = new SqlDataAdapter
                ("SELECT Name,StandardCost FROM Products", conn);
            da.Fill(ds, "Products");
            ds.WriteXml("sample.xml", XmlWriteMode.WriteSchema);
            dataGridView1.DataSource = ds.Tables[0];
            doc = new XmlDataDocument(ds);
            XmlNodeList list = doc.GetElementsByTagName("Products");
            richTextBox1.Text = "";
            foreach(XmlNode node in list)
            {
                richTextBox1.Text += node.InnerText + "\r\n";
            }
            ds.WriteXml("sample.xml",XmlWriteMode.WriteSchema);
        }    private XmlDataDocument doc;

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            DataSet ds = new DataSet("Products");
            SqlConnection conn = new SqlConnection(_connectString);
            SqlDataAdapter daProduct = new SqlDataAdapter
                ("SELECT Name,StandardCost,ID FROM Products ",conn);
            SqlDataAdapter daCategory = new SqlDataAdapter
                ("SELECT ID,食物,生活场所 FROM Attribute", conn);
            daProduct.Fill(ds, "Products");
            daCategory.Fill(ds, "Attribute");
            ds.Relations.Add(ds.Tables["Attribute"].Columns["ID"],
                ds.Tables["Products"].Columns["ID"]);
            
            ds.WriteXml("Products.xml", XmlWriteMode.WriteSchema);
            dataGridView1.DataSource = ds.Tables[1];
            
            doc = new XmlDataDocument(ds);
            XmlNodeList list = doc.SelectNodes("//Attribute");
            
            richTextBox1.Text = "";
            foreach(XmlNode node in list)
            {
                richTextBox1.Text += node.InnerText + "\r\n";
            }
            ds.WriteXml("AAA.xml", XmlWriteMode.WriteSchema);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("Products");
            ds.ReadXml("Products.xml");
            dataGridView1.DataSource = ds.Tables[0];
            richTextBox1.Text = "";
            foreach(DataTable dt in ds.Tables)
            {
                richTextBox1.Text += dt.TableName + "\r\n";
                foreach(DataColumn col in dt.Columns)
                {
                    richTextBox1.Text += "\t" + col.ColumnName + "-" + col.DataType.FullName +
                        "\r\n";
                }
            }
        }
    }
}
