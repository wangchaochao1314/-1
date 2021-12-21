using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextFile;

namespace Test
{
    public partial class Form1 : Form
    {
        Queue qBarCode;
        public Form1()
        {
            InitializeComponent();
            qBarCode = new Queue();
            this.Load += Form1_LoadS;

        }

        private void Form1_LoadS(object sender, EventArgs e)
        {
            LogHelper txt = new LogHelper();
            string path = Application.StartupPath + "//" + "data";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(path + "//" + "测试标准" + ".txt"))
            {
                File.Create(path + "//" + "测试标准" + ".txt");
            }

            string str = txt.ReadFile(path + "//" + "测试标准" + ".txt");

        }
          private void Form1_Load(object sender, EventArgs e)
        {
            string str10 = string.Empty;
            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            int str4 = 0;
            string[] str20 = new string[2] { "ERROR", (1).ToString() };
            qBarCode.Enqueue(str20);
            object parameters = qBarCode.Dequeue();
            GetValues(parameters, out str1, out str2);
            str3 = str1.ToString();
            str4 = int.Parse(str2);
        }
        public void GetValues(object Parameter, out string str1, out string str2)
        {
            object[] para = (object[])Parameter;
            str1 = (string)para[0];
            str2 = (string)para[1];
        }
    }
}
