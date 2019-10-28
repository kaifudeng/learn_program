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
using System.Xml.Schema;

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

        void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, "books.xsd");
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler +=
                new System.Xml.Schema.ValidationEventHandler(settings_ValidationEventHandler);
            XmlReader rdr = XmlReader.Create("books.xml",settings);
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                {
                    richTextBox1.AppendText(rdr.Value + "\r\n");
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create("newbook.xml", settings);
            writer.WriteStartDocument();

            writer.WriteStartElement("book");
            writer.WriteAttributeString("genre", "Mystery");
            writer.WriteAttributeString("publicationdate", "2001");
            writer.WriteAttributeString("ISBN", "123456789");
            writer.WriteElementString("title", "Case of the Missing Cookie");
            writer.WriteStartElement("author");
            writer.WriteElementString("name", "Cookie Monster");
            writer.WriteEndElement();
            writer.WriteElementString("Price", "9.99");
            writer.WriteEndElement();
            

            writer.Flush();
            writer.Close();*/


            //doc.Load("books.xml");

            XmlDeclaration newDec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(newDec);
            XmlElement newRoot = doc.CreateElement("newBookstore");
            doc.AppendChild(newRoot);
            XmlElement newbook = doc.CreateElement("book");
            newbook.SetAttribute("genre", "Mystery");
            newbook.SetAttribute("publicationdate", "2001");
            newbook.SetAttribute("ISBN", "123456789");

            XmlElement newTitle = doc.CreateElement("title");
            newTitle.InnerText = "Case of the Missing Cookie";
            newbook.AppendChild(newTitle);

            XmlElement newAuthor = doc.CreateElement("author");
            newbook.AppendChild(newAuthor);

            XmlElement newName = doc.CreateElement("Name");
            newName.InnerText = "Cookie Monster";
            newAuthor.AppendChild(newName);

            XmlElement newPrice = doc.CreateElement("price");
            newPrice.InnerText = "9.95";
            newbook.AppendChild(newPrice);

            doc.DocumentElement.AppendChild(newbook);

            XmlTextWriter tr = new XmlTextWriter("booksEdit.xml", null);
            tr.Formatting = Formatting.Indented;
            doc.WriteContentTo(tr);
            tr.Close();

            XmlNodeList nodeList = doc.GetElementsByTagName("title");
            richTextBox1.Text = "";
            foreach(XmlNode x in nodeList)
            {
                richTextBox1.Text += x.OuterXml + "\r\n";
            }
        }

        private XmlDocument doc = new XmlDocument();
        private void button7_Click(object sender, EventArgs e)
        {
            doc.Load("books.xml");
            XmlNodeList nodeList = doc.GetElementsByTagName("title");
            richTextBox1.Text = "";
            foreach(XmlNode node in nodeList)
            {
                richTextBox1.Text += node.OuterXml + "\r\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            doc.Load("books.xml");
            XmlNodeList nodeList = doc.SelectNodes("/bookstore/book/title");
            richTextBox1.Text = "";
            foreach(XmlNode x in nodeList)
            {
                richTextBox1.Text += x.OuterXml + "\r\n";
            }
        }
    }
}
