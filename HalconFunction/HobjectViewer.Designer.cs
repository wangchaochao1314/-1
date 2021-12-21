
namespace HalconFunction
{
    partial class HobjectViewer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HobjectViewer));
            this.ViewerControl = new HalconDotNet.HWindowControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel_Size = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripsLableSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSize1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelChannel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusrgbValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRegistered = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbArrow = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbHand = new System.Windows.Forms.ToolStripButton();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbRotateRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbCircle = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemUNION = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemINTERSECTION = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDIFFERENCE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewerControl
            // 
            this.ViewerControl.BackColor = System.Drawing.Color.Black;
            this.ViewerControl.BorderColor = System.Drawing.Color.Black;
            this.ViewerControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.ViewerControl.Location = new System.Drawing.Point(0, 3);
            this.ViewerControl.Name = "ViewerControl";
            this.ViewerControl.Size = new System.Drawing.Size(782, 569);
            this.ViewerControl.TabIndex = 0;
            this.ViewerControl.WindowSize = new System.Drawing.Size(782, 569);
            this.ViewerControl.HMouseMove += new HalconDotNet.HMouseEventHandler(this.ViewerControl_HMouseMove);
            this.ViewerControl.HMouseDown += new HalconDotNet.HMouseEventHandler(this.ViewerControl_HMouseDown);
            this.ViewerControl.HMouseUp += new HalconDotNet.HMouseEventHandler(this.ViewerControl_HMouseUp);
            this.ViewerControl.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.ViewerControl_HMouseWheel);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 574);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 64);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel_Size,
            this.StatusLabelSize,
            this.ToolStripsLableSize,
            this.toolStripStatusLabelSize1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelChannel,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelCoordinate,
            this.toolStripStatusLabel4,
            this.toolStripStatusrgbValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 32);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(441, 31);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel_Size
            // 
            this.StatusLabel_Size.Name = "StatusLabel_Size";
            this.StatusLabel_Size.Size = new System.Drawing.Size(0, 24);
            // 
            // StatusLabelSize
            // 
            this.StatusLabelSize.Image = global::HalconFunction.Properties.Resources.dimensions;
            this.StatusLabelSize.Name = "StatusLabelSize";
            this.StatusLabelSize.Size = new System.Drawing.Size(24, 24);
            // 
            // ToolStripsLableSize
            // 
            this.ToolStripsLableSize.Name = "ToolStripsLableSize";
            this.ToolStripsLableSize.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripStatusLabelSize1
            // 
            this.toolStripStatusLabelSize1.Name = "toolStripStatusLabelSize1";
            this.toolStripStatusLabelSize1.Size = new System.Drawing.Size(100, 24);
            this.toolStripStatusLabelSize1.Text = "                  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::HalconFunction.Properties.Resources.channel;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripStatusLabelChannel
            // 
            this.toolStripStatusLabelChannel.Name = "toolStripStatusLabelChannel";
            this.toolStripStatusLabelChannel.Size = new System.Drawing.Size(25, 24);
            this.toolStripStatusLabelChannel.Text = "   ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::HalconFunction.Properties.Resources.arrow480;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripStatusLabelCoordinate
            // 
            this.toolStripStatusLabelCoordinate.Name = "toolStripStatusLabelCoordinate";
            this.toolStripStatusLabelCoordinate.Size = new System.Drawing.Size(75, 24);
            this.toolStripStatusLabelCoordinate.Text = "             ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::HalconFunction.Properties.Resources.rgb;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripStatusrgbValue
            // 
            this.toolStripStatusrgbValue.Name = "toolStripStatusrgbValue";
            this.toolStripStatusrgbValue.Size = new System.Drawing.Size(120, 24);
            this.toolStripStatusrgbValue.Text = "                      ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemZoom,
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemSaveWindow,
            this.toolStripMenuItemRegistered});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 154);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItemZoom
            // 
            this.toolStripMenuItemZoom.Name = "toolStripMenuItemZoom";
            this.toolStripMenuItemZoom.Size = new System.Drawing.Size(152, 30);
            this.toolStripMenuItemZoom.Text = "适应窗体";
            this.toolStripMenuItemZoom.Click += new System.EventHandler(this.toolStripMenuItemZoom_Click);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(152, 30);
            this.toolStripMenuItemOpen.Text = "打开图片";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(152, 30);
            this.toolStripMenuItemSave.Text = "保存图片";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemSaveWindow
            // 
            this.toolStripMenuItemSaveWindow.Name = "toolStripMenuItemSaveWindow";
            this.toolStripMenuItemSaveWindow.Size = new System.Drawing.Size(152, 30);
            this.toolStripMenuItemSaveWindow.Text = "保存窗口";
            this.toolStripMenuItemSaveWindow.Click += new System.EventHandler(this.toolStripMenuItemSaveWindow_Click);
            // 
            // toolStripMenuItemRegistered
            // 
            this.toolStripMenuItemRegistered.Name = "toolStripMenuItemRegistered";
            this.toolStripMenuItemRegistered.Size = new System.Drawing.Size(152, 30);
            this.toolStripMenuItemRegistered.Text = "注册模板";
            this.toolStripMenuItemRegistered.Click += new System.EventHandler(this.toolStripMenuItemRegistered_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbArrow,
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbHand,
            this.tsbRectangle,
            this.tsbRotateRectangle,
            this.tsbEllipse,
            this.tsbCircle,
            this.tsbRemove,
            this.tsbClear,
            this.toolStripDropDownButtonStatus,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 575);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(396, 33);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbArrow
            // 
            this.tsbArrow.BackColor = System.Drawing.Color.Transparent;
            this.tsbArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbArrow.Image = global::HalconFunction.Properties.Resources.Arrow;
            this.tsbArrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArrow.Name = "tsbArrow";
            this.tsbArrow.Size = new System.Drawing.Size(34, 28);
            this.tsbArrow.Text = "toolStripButton1";
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Image = global::HalconFunction.Properties.Resources.ZoomIn;
            this.tsbZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomIn.Text = "toolStripButton2";
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = global::HalconFunction.Properties.Resources.ZoomOut;
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomOut.Text = "toolStripButton1";
            // 
            // tsbHand
            // 
            this.tsbHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHand.Image = ((System.Drawing.Image)(resources.GetObject("tsbHand.Image")));
            this.tsbHand.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHand.Name = "tsbHand";
            this.tsbHand.Size = new System.Drawing.Size(34, 28);
            this.tsbHand.Text = "toolStripButton1";
            // 
            // tsbRectangle
            // 
            this.tsbRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRectangle.Image = global::HalconFunction.Properties.Resources.Rectangle;
            this.tsbRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRectangle.Name = "tsbRectangle";
            this.tsbRectangle.Size = new System.Drawing.Size(34, 28);
            this.tsbRectangle.Text = "toolStripButton1";
            // 
            // tsbRotateRectangle
            // 
            this.tsbRotateRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotateRectangle.Image = global::HalconFunction.Properties.Resources.RotateRectangle;
            this.tsbRotateRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotateRectangle.Name = "tsbRotateRectangle";
            this.tsbRotateRectangle.Size = new System.Drawing.Size(34, 28);
            this.tsbRotateRectangle.Text = "toolStripButton1";
            // 
            // tsbCircle
            // 
            this.tsbCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCircle.Image = global::HalconFunction.Properties.Resources.Ellipse;
            this.tsbCircle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCircle.Name = "tsbCircle";
            this.tsbCircle.Size = new System.Drawing.Size(34, 28);
            this.tsbCircle.Text = "toolStripButton1";
            // 
            // tsbEllipse
            // 
            this.tsbEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEllipse.Image = global::HalconFunction.Properties.Resources.Circle;
            this.tsbEllipse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEllipse.Name = "tsbEllipse";
            this.tsbEllipse.Size = new System.Drawing.Size(34, 28);
            this.tsbEllipse.Text = "toolStripButton2";
            // 
            // tsbRemove
            // 
            this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemove.Image = global::HalconFunction.Properties.Resources.Remove;
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(34, 28);
            this.tsbRemove.Text = "删除选中项";
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClear.Image = global::HalconFunction.Properties.Resources.Clear;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(34, 28);
            this.tsbClear.Text = "删除所有";
            // 
            // toolStripDropDownButtonStatus
            // 
            this.toolStripDropDownButtonStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUNION,
            this.toolStripMenuItemINTERSECTION,
            this.toolStripMenuItemDIFFERENCE});
            this.toolStripDropDownButtonStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonStatus.Name = "toolStripDropDownButtonStatus";
            this.toolStripDropDownButtonStatus.Size = new System.Drawing.Size(18, 28);
            this.toolStripDropDownButtonStatus.Text = "集合类型";
            // 
            // toolStripMenuItemUNION
            // 
            this.toolStripMenuItemUNION.Name = "toolStripMenuItemUNION";
            this.toolStripMenuItemUNION.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItemUNION.Text = "并集";
            // 
            // toolStripMenuItemINTERSECTION
            // 
            this.toolStripMenuItemINTERSECTION.Name = "toolStripMenuItemINTERSECTION";
            this.toolStripMenuItemINTERSECTION.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItemINTERSECTION.Text = "交集";
            // 
            // toolStripMenuItemDIFFERENCE
            // 
            this.toolStripMenuItemDIFFERENCE.Name = "toolStripMenuItemDIFFERENCE";
            this.toolStripMenuItemDIFFERENCE.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItemDIFFERENCE.Text = "差集";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::HalconFunction.Properties.Resources.INTERSECTION;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // HobjectViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ViewerControl);
            this.Name = "HobjectViewer";
            this.Size = new System.Drawing.Size(782, 641);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl ViewerControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_Size;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelSize;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripsLableSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSize1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelChannel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoordinate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusrgbValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveWindow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegistered;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbArrow;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbHand;
        private System.Windows.Forms.ToolStripButton tsbRectangle;
        private System.Windows.Forms.ToolStripButton tsbRotateRectangle;
        private System.Windows.Forms.ToolStripButton tsbEllipse;
        private System.Windows.Forms.ToolStripButton tsbCircle;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUNION;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemINTERSECTION;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDIFFERENCE;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
