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
using System.Xml.Linq;
namespace linq_to_xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"Hamlet.xml");
            richTextBox1.Text += xdoc.Root.Name.ToString()+"\r\n";
            richTextBox1.Text += xdoc.Root.HasAttributes.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XNamespace xn = "http://www.google.com";
            

            XElement xe = new XElement(xn+"Company", new XElement("CompanyName", "Lipper"),
                new XElement("CompanyAddress", new XElement("Address", "123 Main Street"),
                new XElement("City", "St.Louis"),
                new XElement("State", "Mo"),
                new XElement("Country", "USA")));
            richTextBox1.Text = "";
            richTextBox1.Text += xe.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xd = new XDocument();
            XComment xc = new XComment("here is a Comment");
            xd.Add(xc);
            XElement xe = new XElement("Company", new XElement("CompanyName", "Lipper"),
            new XElement("CompanyAddress",new XComment("here is another Comment"),
            new XElement("Address", "123 Main Street"),
            new XElement("City", "St.Louis"),
            new XElement("State", "Mo"),
            new XElement("Country", "USA")));
            richTextBox1.Text = "";
            xd.Add(xe);
            richTextBox1.Text += xd.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument xd = new XDocument();
            XElement xe = new XElement("Company", new XAttribute("MyAttribute","aAttribute"),
            new XElement("CompanyName", "Lipper"),
            new XElement("CompanyAddress", new XComment("here is another Comment"),
            new XElement("Address", "123 Main Street"),
            new XElement("City", "St.Louis"),
            new XElement("State", "Mo"),
            new XElement("Country", "USA")));
            richTextBox1.Text = "";
            xd.Add(xe);
            richTextBox1.Text += xd.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument xd = XDocument.Load("hamlet.xml");
            var query = from people in xd.Descendants("PERSONA")
                        select people.Value;
            richTextBox1.Text = "";
            richTextBox1.Text += query.Count()+"\r\n";
            foreach(var item in query)
            {
                richTextBox1.Text += item+"\r\n";
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            XDocument xd = XDocument.Load(@"http://geekswithblogs.net/evjen/Rss.aspx");
            var query = from rss in xd.Descendants("channel")
                        select new
                        {
                            Title = rss.Element("title").Value,
                            descr = rss.Element("description").Value,
                            Link = rss.Element("link").Value
                        };
            richTextBox1.Text = "";
            foreach(var item in query)
            {
                richTextBox1.Text+= "TITLE:" + item.Title+"\r\n";
                richTextBox1.Text+= "DESCRIPTION:" + item.descr + "\r\n";
                richTextBox1.Text+= "LINK:" + item.Link + "\r\n";
            }
            richTextBox1.Text += "\r\n";

            /*var queryPosts = from myposts in xd.Descendants("item")
                             select new
                             {
                                 title = myposts.Element("title").Value,
                                 pub = DateTime.Parse(
                                     myposts.Element("pubDate").Value),
                                 desc = myposts.Element("edscription").Value,
                                 url = myposts.Element("link").Value,
                                 com = myposts.Element("comments").Value
                             };
            foreach(var item in queryPosts)
            {
                richTextBox1.Text += item.title;
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XDocument xd = XDocument.Load("hamlet.xml");
            richTextBox1.Text = "";
            richTextBox1.Text += xd.Element("PLAY").Element("TITLE").Value;

            richTextBox1.Text += "\r\n\n";
            richTextBox1.Text += xd.Element("PLAY").Element("PERSONAE").Element("PERSONA").Value;

            richTextBox1.Text += "\r\n\n";

            xd.Element("PLAY").Element("PERSONAE").Element("PERSONA").SetValue("Bill Evjen,king of Denmark");
            richTextBox1.Text+=(xd.Element("PLAY").Element("PERSONAE").Element("PERSONA").Value);

            richTextBox1.Text += "\r\n\n";

            XElement xe = new XElement("PERSONA",
                "Bill Evjen,king of Denmark");
            xd.Element("PLAY").Element("PERSONAE").Add(xe);
            var query = from people in xd.Descendants("PERSONA")
                        select people.Value;
            richTextBox1.Text += query.Count() + " Players Found" + "\r\n";
            foreach(var q in query)
            {
                richTextBox1.Text += q+"\r\n";
            }
        }
    }
}
