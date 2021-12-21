using Machine.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ConnectControl a = new ConnectControl();
        private void Form1_Load(object sender, EventArgs e)
        {
           
            a.NameStr = "PLC";
            a.IsConnect = false;
            flowLayoutPanel1.Controls.Add(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.IsConnect = true;
        }
    }
}
