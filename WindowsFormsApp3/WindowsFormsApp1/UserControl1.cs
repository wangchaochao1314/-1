using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Machine.UI
{
    public partial class ConnectControl : UserControl
    {
        public ConnectControl()
        {
            InitializeComponent();

            Version v = System.Environment.Version;

            if (v.Major < 2)
            {
                this.SetStyle(ControlStyles.DoubleBuffer, true);
            }
            else
            {
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private bool bConnect = false;

        [Category("行为特性")]
        [DefaultValue(typeof(bool), "false")]
        [Description("是否连接")]
        public bool IsConnect { get { return bConnect; } set { bConnect = value; Invalidate(); } }


        private string nameStr = "PLC";
        [Category("行为特性")]
        [DefaultValue(typeof(string), "PLC")]
        [Description("名称")]
        public string NameStr { get { return nameStr; } set { nameStr = value; Invalidate(); } }

        public void SetSize(int nWidth, int nHeight)
        {
            Width = nWidth;
            Height = nHeight;
        }

        /// <summary>
        /// 重绘数据区
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int iHeight = this.Height;
            int iWidth = this.Width;

            Rectangle CircleRect;
            CircleRect = new Rectangle(5, 3, iHeight - 10, iHeight - 10);


            Color zcl;
            if (bConnect)
            {
                zcl = Color.Lime;

            }
            else
            {
                zcl = Color.Red;
            }

            g.FillEllipse(new SolidBrush(zcl), CircleRect);

            GraphicsPath gp = new GraphicsPath();

            Rectangle rec = new Rectangle(5 + 5, 5 + 3, iHeight - 10 - 10, iHeight - 10 - 10);
            gp.AddEllipse(rec);

            Color[] surroundColor = new Color[] { zcl };
            PathGradientBrush pb = new PathGradientBrush(gp);
            pb.CenterColor = Color.White;
            pb.SurroundColors = surroundColor;
            g.FillPath(pb, gp);

            gp.Dispose();
            pb.Dispose();

            Rectangle textRect;
            textRect = new Rectangle(CircleRect.Right + 5, 2, iWidth - 20 - (iHeight - 10), iHeight - 4);

            SizeF textSize = new SizeF();
            textSize = g.MeasureString(nameStr, this.Font);   //测量文字长度  
            PointF strPoint = new PointF(5 + (iHeight - 10) + 5, (this.Size.Height - textSize.Height) / 2);
            Brush brush = new SolidBrush(this.ForeColor);
            g.DrawString(nameStr, this.Font, brush, strPoint);
        }
    }
}