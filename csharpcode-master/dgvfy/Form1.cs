using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;//这个是我博客另外一篇文章里面讲解的不需要使用oracle的客户端就能够使用vs链接oracle数据库的引用
namespace dgvfy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgv.AutoGenerateColumns = true;
            this.source = new DataSet();
            this.pageSize = 30;
            this.CurrentPage = 1;
            using (OracleConnection conn = new OracleConnection())
            {
                conn.ConnectionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=testdb.domain)));USER ID=xzp;Password=xzp;";
                conn.Open();
                string sql = "select * from student_tb";
                OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);
                adapter.Fill(source,"tb");
            }
            BindPage();
        }

        int pageCount = 0;

        public int PageCount
        {
            get
            {
                if (source != null)
                {
                    pageCount = (int)Math.Ceiling(source.Tables[0].Rows.Count * 1.0 / pageSize);
                }
                return pageCount;
            }
        }

        DataSet source;//用于存储数据库中的查询出来的数据
        int pageSize = 0;//每页条目数
        int currentPage = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (value <= 1)
                {
                    value = 1;
                    this.bdFirstItem.Enabled = false;
                    this.bdPreviousItem.Enabled = false;
                    this.bdNextItem.Enabled = true;
                    this.bdLastItem.Enabled = true;
                }
                else if (value >= PageCount)
                {
                    value = pageCount;
                    this.bdFirstItem.Enabled = true;
                    this.bdPreviousItem.Enabled = true;
                    this.bdNextItem.Enabled = false;
                    this.bdLastItem.Enabled = false;
                }
                else
                {
                    this.bdFirstItem.Enabled = true;
                    this.bdPreviousItem.Enabled = true;
                    this.bdNextItem.Enabled = true;
                    this.bdLastItem.Enabled = true;
                    
                }
                currentPage = value;
            }
        }
        int currentRow ;
        /// <summary>
        /// 每页首行索引
        /// </summary>
        public int CurrentRow
        {
            get
            {
                if (CurrentPage == 1)
                {
                    currentRow = 0;
                }
                else
                {
                    currentRow = (CurrentPage - 1) * pageSize;
                }
                return currentRow;
            }
        }
        int max = 0;
        /// <summary>
        /// 每页行数最大值索引
        /// </summary>
        public int Max
        {
            get
            {
                if (CurrentPage == pageCount)
                {
                    max = source.Tables[0].Rows.Count;
                }
                else
                {
                    max = pageSize * CurrentPage;
                }
                return max;
            }
        }
        /// <summary>
        /// 绑定combobox中的页码
        /// </summary>
        private void BindPage()
        {
            this.bdCountItem.Text = PageCount.ToString();
            this.tspcbo.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                this.tspcbo.Items.Add("第" + i + "页");
            }
            this.tspcbo.SelectedIndex = 0;
        }
        /// <summary>
        /// 分页绑定数据
        /// </summary>
        private void BindSourceFY()
        {
            DataTable dt = new DataTable();
            dt.TableName = "tb";//这个可以没有
            //下面这个循环比较有用，没有这个循环直接绑定的话datagridview是不显示数据的
            //原因是在dt这个对象里面那个columns集合是空，所以这个datagridview没有办法自动绑定
            for (int i = 0; i < source.Tables[0].Columns.Count; i++)
            {
                dt.Columns.Add(source.Tables[0].Columns[i].ToString());
            }
            for (int i = CurrentRow; i < Max; i++)
            {
                dt.ImportRow(source.Tables[0].Rows[i]);
            }
            this.dgv.DataSource = dt;
            //this.dgv.DataMember = "tb";
            
        }

        private void tspcbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = this.tspcbo.SelectedIndex + 1;
            this.bdPositionItem.Text = CurrentPage.ToString();
            BindSourceFY();
        }

        private void bdFirstItem_Click(object sender, EventArgs e)
        {
            this.tspcbo.SelectedIndex = 0;
        }
        /// <summary>
        /// 前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdPreviousItem_Click(object sender, EventArgs e)
        {
            this.tspcbo.SelectedIndex = CurrentPage - 2;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNextItem_Click(object sender, EventArgs e)
        {
            this.tspcbo.SelectedIndex = CurrentPage;
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdLastItem_Click(object sender, EventArgs e)
        {
            this.tspcbo.SelectedIndex = PageCount - 1;
        }
    }
}
