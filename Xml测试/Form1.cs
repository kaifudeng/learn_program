using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace Xml测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                {
                    richTextBox1.AppendText(rdr.Value + "\r\n");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (!rdr.EOF)
            {
                /*if (rdr.MoveToContent() == XmlNodeType.Element && rdr.Name == "title")
                {
                    richTextBox1.AppendText(rdr.ReadElementString() + "\r\n");
                }
                else
                {
                    rdr.Read();
                }*/
                if (rdr.MoveToContent() == XmlNodeType.Element)
                {
                    LoadTextBox(rdr);
                }
                else
                {
                    rdr.Read();
                }
            }
        }

        private void LoadTextBox(XmlReader reader)
        {
            try
            {
                richTextBox1.AppendText(reader.ReadElementString() + "\r\n");
            }
            catch(XmlException er) 
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    if (rdr.Name == "price")
                    {
                        decimal price = rdr.ReadElementContentAsDecimal();
                        richTextBox1.AppendText("Current Price =" + price + "\r\n");
                        price += price * (decimal).25;
                        richTextBox1.AppendText("New Price = " + price + "\r\n\r\n");
                    }
                    else if (rdr.Name == "title")
                    {
                        richTextBox1.AppendText(rdr.ReadElementContentAsString() + "\r\n");

                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read()) 
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    for(int i = 0; i < rdr.AttributeCount; i++)
                    {
                        richTextBox1.AppendText(rdr.GetAttribute(i) + "\r\n");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
