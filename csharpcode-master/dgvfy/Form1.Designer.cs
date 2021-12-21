namespace dgvfy
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bdFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bdPreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bdPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNextItem = new System.Windows.Forms.ToolStripButton();
            this.bdLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tspcbo = new System.Windows.Forms.ToolStripComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 626);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bindingNavigator1);
            this.splitContainer1.Size = new System.Drawing.Size(1155, 626);
            this.splitContainer1.SplitterDistance = 577;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1155, 577);
            this.dgv.TabIndex = 0;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bdCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bdFirstItem,
            this.bdPreviousItem,
            this.bindingNavigatorSeparator,
            this.bdPositionItem,
            this.bdCountItem,
            this.bindingNavigatorSeparator1,
            this.bdNextItem,
            this.bdLastItem,
            this.bindingNavigatorSeparator2,
            this.tspcbo});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bdFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bdLastItem;
            this.bindingNavigator1.MoveNextItem = this.bdNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bdPreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bindingNavigator1.PositionItem = this.bdPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1155, 38);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bdCountItem
            // 
            this.bdCountItem.Name = "bdCountItem";
            this.bdCountItem.Size = new System.Drawing.Size(46, 33);
            this.bdCountItem.Text = "/ {0}";
            this.bdCountItem.ToolTipText = "总项数";
            // 
            // bdFirstItem
            // 
            this.bdFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bdFirstItem.Image")));
            this.bdFirstItem.Name = "bdFirstItem";
            this.bdFirstItem.RightToLeftAutoMirrorImage = true;
            this.bdFirstItem.Size = new System.Drawing.Size(34, 33);
            this.bdFirstItem.Text = "移到第一条记录";
            this.bdFirstItem.Click += new System.EventHandler(this.bdFirstItem_Click);
            // 
            // bdPreviousItem
            // 
            this.bdPreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdPreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bdPreviousItem.Image")));
            this.bdPreviousItem.Name = "bdPreviousItem";
            this.bdPreviousItem.RightToLeftAutoMirrorImage = true;
            this.bdPreviousItem.Size = new System.Drawing.Size(34, 33);
            this.bdPreviousItem.Text = "移到上一条记录";
            this.bdPreviousItem.Click += new System.EventHandler(this.bdPreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bdPositionItem
            // 
            this.bdPositionItem.AccessibleName = "位置";
            this.bdPositionItem.AutoSize = false;
            this.bdPositionItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bdPositionItem.Name = "bdPositionItem";
            this.bdPositionItem.Size = new System.Drawing.Size(73, 30);
            this.bdPositionItem.Text = "0";
            this.bdPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bdNextItem
            // 
            this.bdNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNextItem.Image")));
            this.bdNextItem.Name = "bdNextItem";
            this.bdNextItem.RightToLeftAutoMirrorImage = true;
            this.bdNextItem.Size = new System.Drawing.Size(34, 33);
            this.bdNextItem.Text = "移到下一条记录";
            this.bdNextItem.Click += new System.EventHandler(this.bdNextItem_Click);
            // 
            // bdLastItem
            // 
            this.bdLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bdLastItem.Image")));
            this.bdLastItem.Name = "bdLastItem";
            this.bdLastItem.RightToLeftAutoMirrorImage = true;
            this.bdLastItem.Size = new System.Drawing.Size(34, 33);
            this.bdLastItem.Text = "移到最后一条记录";
            this.bdLastItem.Click += new System.EventHandler(this.bdLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tspcbo
            // 
            this.tspcbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tspcbo.Name = "tspcbo";
            this.tspcbo.Size = new System.Drawing.Size(133, 38);
            this.tspcbo.SelectedIndexChanged += new System.EventHandler(this.tspcbo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 626);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bdCountItem;
        private System.Windows.Forms.ToolStripButton bdFirstItem;
        private System.Windows.Forms.ToolStripButton bdPreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bdPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bdNextItem;
        private System.Windows.Forms.ToolStripButton bdLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripComboBox tspcbo;
    }
}

