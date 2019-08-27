using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            c ccc = null;
           
            string[] strArray = new string[2];
            strArray[1] = "a";
            // strArray[1] = null;
            List<string> lll= strArray.ToList();
            
            foreach (string s in lll)
            {
                
                if (string.IsNullOrEmpty(s))
                { }
                else
                {
                    richTextBox1.AppendText(s);
                }
            }
           // Console.ReadKey();
        }
    }
}
class c
{ }
