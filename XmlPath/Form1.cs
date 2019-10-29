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
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
namespace XmlPath
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
            XPathDocument doc = new XPathDocument("books.xml");

            XPathNavigator nav = ((IXPathNavigable)doc).CreateNavigator();

            XPathNodeIterator iter = nav.Select("/bookstore/book[@genre='novel']");
            richTextBox1.Text = "";
            while (iter.MoveNext())
            {
                XPathNodeIterator newIter =
                    iter.Current.SelectDescendants(XPathNodeType.Element, false);
                while (newIter.MoveNext())
                {
                    richTextBox1.Text += newIter.Current.Name + ":" +
                        newIter.Current.Value + "\r\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XPathDocument doc = new XPathDocument("books.xml");
            XPathNavigator nav = ((IXPathNavigable)doc).CreateNavigator();
            XPathNodeIterator iter = nav.Select("/bookstore/book");
            richTextBox1.Text = "";
            while (iter.MoveNext())
            {
                XPathNodeIterator newIter =
                    iter.Current.SelectDescendants(XPathNodeType.Element, false);
                while (newIter.MoveNext())
                {
                    richTextBox1.Text += newIter.Current.Name + ":" + newIter.Current.Value +
                        "\r\n";
                }
            }
            richTextBox1.Text += "==============" + "\r\n";
            richTextBox1.Text += "Tatal Cost= " + nav.Evaluate("sum(/bookstore/book/price)");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("books.xml");
            XPathNavigator nav = doc.CreateNavigator();
            if (nav.CanEdit)
            {
                XPathNodeIterator iter = nav.Select("/bookstore/book/price");
                while (iter.MoveNext())
                {
                    iter.Current.InsertAfter("<disc>5</disc>");
                }
            }
            doc.Save("newbooks.xml");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("books.xsl");
            trans.Transform("books.xml", "out.html");
            WebBrowser web = new WebBrowser();
            web.Navigate(AppDomain.CurrentDomain.BaseDirectory + "out.html");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XPathDocument doc = new XPathDocument("books.xml");
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("booksarg.xsl");
            XmlWriter xw = new XmlTextWriter("argSample.xml", null);
            XsltArgumentList argbook = new XsltArgumentList();
            BookUtils bu = new BookUtils();
            argbook.AddExtensionObject("urn:XslSample", bu);
            XPathNavigator nav = doc.CreateNavigator();
            trans.Transform(nav, argbook, xw);
            xw.Close();
            WebBrowser web = new WebBrowser();
            web.Navigate(AppDomain.CurrentDomain.BaseDirectory + "argSample.xml");
        }
        public class BookUtils
        {
            public BookUtils()
            { }
            public string ShowText()
            {
                return "This came from the ShowText method!";
            }
        }
    }
}
