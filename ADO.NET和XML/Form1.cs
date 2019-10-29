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
        string _connectString = "Server=.\\SQLExpress;Database=adventureworkslt;Trusted_Connection=Yes";

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
                ("SELECT Name,StandardCost From SalesLT.Product", conn);
            da.Fill(ds, "Products");
            dataGridView1.DataSource = ds.Tables["products"];

            MemoryStream memstrm = new MemoryStream();
            StreamReader strmread = new StreamReader(memstrm);
            StreamWriter strmWrite = new StreamWriter(memstrm);

            ds.WriteXml(strmWrite, XmlWriteMode.IgnoreSchema);
            memstrm.Seek(0, SeekOrigin.Begin);
            doc.Load(strmread);
            XmlNodeList nodelist = doc.SelectNodes("//XMLProducts/Products");
            richTextBox1.Text = "";
            foreach(XmlNode node in nodelist)
            {
                richTextBox1.Text += node.InnerText + "\r\n";
            }
        }
    }
}
