using DocumentFormat.OpenXml.Math;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._3._0_包含DLR_ScriptRuntime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string scriptToUse;
            if (CostRadioButton.IsChecked.Value)
            {
                scriptToUse = "AmountDisc.py";
            }
            else
            {
                scriptToUse = "CountDisc.py";
            }
            ScriptRuntime scriptRuntime = ScriptRuntime.CreateFromConfiguration();
            ScriptEngine pythEng = scriptRuntime.GetEngine("Python");
            ScriptSource source = pythEng.CreateScriptSourceFromFile(scriptToUse);
            ScriptScope scope = pythEng.CreateScope();
            scope.SetVariable("prodCount", Convert.ToInt32(totalItems.Text));
            scope.SetVariable("amt", Convert.ToDecimal(totalAmt.Text));
            source.Execute(scope);
            label1.Content = scope.GetVariable("retAmt").toString();
        }

        private void CostRadioButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
