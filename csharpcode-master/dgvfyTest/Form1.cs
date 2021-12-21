using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace dgvfyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int pagesize = 0;
        int max = 0;

        public int Max
        {
            get
            {
                if (currentpage == pagecount)
                {
                    max = dset.Tables[0].Rows.Count;
                }
                else 
                {
                    max = pagesize+currentRow;
                }
                return max; 
            }
        }
        int currentpage = 1;

        public int Currentpage
        {
            get
            {
                return currentpage; 
            }
            set 
            {
                if (value <= 1)
                {
                    value = 1;

                    this.bindingNavigatorMoveFirstItem.Enabled = false;
                    this.bindingNavigatorMovePreviousItem.Enabled = false;
                    this.bindingNavigatorMoveLastItem.Enabled = true;
                    this.bindingNavigatorMoveNextItem.Enabled = true;
                }
                else if (value == pagecount)
                {
                    this.bindingNavigatorMoveFirstItem.Enabled = true;
                    this.bindingNavigatorMovePreviousItem.Enabled = true;
                    this.bindingNavigatorMoveLastItem.Enabled = false;
                    this.bindingNavigatorMoveNextItem.Enabled = false;
                    value = pagecount;
                }
                else
                {
                    this.bindingNavigatorMoveFirstItem.Enabled = true;
                    this.bindingNavigatorMovePreviousItem.Enabled = true;
                    this.bindingNavigatorMoveLastItem.Enabled = true;
                    this.bindingNavigatorMoveNextItem.Enabled = true;
                }
                currentpage = value; 
            }
        }
        int currentRow = 0;//当前行用于table复制的起始行

        public int CurrentRow
        {
            get 
            {
                if (currentpage == 1)
                {
                    currentRow = 0;
                }
                else 
                {
                    currentRow = (Currentpage - 1) * pagesize;
                }
                return currentRow; 
            }
        }
        int pagecount = 0;

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            
            Currentpage = 1;
            this.toolStripComboBox1.SelectedIndex = Currentpage - 1;
        }
        private DataSet dset;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.bindingNavigatorMoveFirstItem.Enabled = true;
            this.bindingNavigatorMoveLastItem.Enabled = true;
            this.bindingNavigatorMoveNextItem.Enabled = true;
            this.bindingNavigatorMovePreviousItem.Enabled = true;
            this.bindingNavigatorCountItem.Enabled = true;
            this.bindingNavigatorPositionItem.Enabled = true;
            this.toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            pagesize = 30;
            this.toolStripTextBox1.Text = pagesize.ToString();
            Currentpage = 1;
            this.bindingNavigatorPositionItem.Text = currentpage.ToString();
            string constr = @"data source = (DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=testdb.domain)));user id=xzp;password=xzp";
            using (OracleConnection conn = new OracleConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                dset = new DataSet();
                string sql = "select * from student_tb";
                OracleDataAdapter adapter = new OracleDataAdapter(sql,conn);
                adapter.Fill(dset, "tb");
            }
           pagecount = (int)Math.Ceiling(dset.Tables[0].Rows.Count*1.0/pagesize);
            this.bindingNavigatorCountItem.Text =  pagecount.ToString();
            
            BindPage();
            BindSource();
        }

        private void BindSource()
        {
            DataTable pageTable = new DataTable();
            pageTable.TableName = "tb";
            for (int i = 0; i < dset.Tables[0].Columns.Count; i++)
            {
                pageTable.Columns.Add(dset.Tables[0].Columns[i].ToString());
            }
            for (int i = CurrentRow; i < Max; i++)
            {
                pageTable.ImportRow(dset.Tables[0].Rows[i]);
            }
            this.dataGridView1.DataSource = pageTable;
            //this.dataGridView1.DataMember = "tb";
        }
        private void BindPage()
        {
            this.bindingNavigatorMovePreviousItem.Text = currentpage.ToString();
            this.toolStripComboBox1.Items.Clear();
            for (int i = 1; i <= pagecount; i++)
            {
                this.toolStripComboBox1.Items.Add("第" + i + "页");
            }
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Currentpage--;
            this.toolStripComboBox1.SelectedIndex = Currentpage - 1;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Currentpage = this.toolStripComboBox1.SelectedIndex + 1;
            BindSource();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            Currentpage++;
            this.toolStripComboBox1.SelectedIndex = Currentpage - 1;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            Currentpage = pagecount;
            this.toolStripComboBox1.SelectedIndex = Currentpage - 1;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            //this.pagesize =int.Parse( this.toolStripTextBox1.Text);
            //BindPage();
            //Currentpage = 1;
            //this.toolStripComboBox1.SelectedIndex = Currentpage - 1;
        }


        
    }
}
