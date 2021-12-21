using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HalconDotNet.HDrawingObject;

namespace HalconFunction
{
    public partial class HobjectViewer : UserControl
    {
        private bool m_bIsShowToolbar = true;
        [Category("自定义"),Description ("是否显示工具栏"),Browsable(true)] //是否显示当前属性在控件对象中。
        public bool ShowToolbar
        {
            get { return m_bIsShowToolbar; }

            set {
                m_bIsShowToolbar = value;
                this.tableLayoutPanel1.RowStyles[0].Height = m_bIsShowToolbar ? 30F : 30F;
                this.tableLayoutPanel1.Height = m_bIsShowToolbar ? 60 : 30;
                }
        }
        
        private ViewTools m_activeTool = ViewTools.Arrow;
        [Category("DataBindings"), Description("默认激活工具"), Browsable(true)]

        //因为这个委托是用鼠标事件来响应的，所以的它的参数类型和事件的定义相同且无返回值。
        //
        public delegate void ToolChangedEventHandler(object sender, ToolEventArgs e );
        public event ToolChangedEventHandler onToolChanged;
        //用属性来监控控件选择项的改变 ,当你双击这个控件时，我就将你当前选择的枚举对象赋值给当前的对象值，
        //然后做出对应的改变
        public ViewTools ActiveTool
        {
            get { return m_activeTool; }
            set
            {
                m_activeTool = value;
                if (onToolChanged!=null)
                {
                    onToolChanged(null, new ToolEventArgs(m_activeTool));
                }
            }
        }
        //自定义事件的数据类
        //它的数据源 来自于上述ViewTools 属性值改变时传进来的数值,
        public class ToolEventArgs
        {
            public ViewTools ActiveTool = ViewTools.Arrow;
            public ToolEventArgs (ViewTools tool)
            {
                ActiveTool = tool;
            }
        }
        private HTuple M_windowID, m_imageWidth, m_imageHeight; //窗口句柄,图像宽高
        private double m_rowMouseDown;
        private double m_colMouseDown;
        private HImage m_sourceImage; //图像变量
        //源图像
        public HImage SourceImage
        {
            get { return m_sourceImage; }
            set {
                if (m_sourceImage != null)
                {
                    m_sourceImage.Dispose();
                }
                m_sourceImage = value;
                if (m_sourceImage != null)
                {
                    HTuple channel;
                    //计算通道数
                    HOperatorSet.CountChannels(m_sourceImage,out channel);
                    toolStripStatusLabelChannel.Text = channel.I.ToString();
                    HOperatorSet.GetImageSize(m_sourceImage, out m_imageWidth, out m_imageHeight);//获取图像大小。
                    m_dbCrossRow = m_imageHeight / 2;
                    m_dbCrossCol = m_imageWidth / 2;
                }
            }
        }
        public HobjectViewer()
        {
            InitializeComponent();
            onToolChanged += ToolChangeEvent;
            M_windowID = ViewerInstance.HalconWindow;
            OnImageChanged += Image_ChangeEvent;
        }

        private void ToolChangeEvent(object sender, ToolEventArgs e)
        {
            for (int i = 0; i < m_listTools.Count; i++)
            {
                m_listTools[i].BackColor = Color.Transparent;
            }
            if (toolStrip1.Items["tsb"+e.ActiveTool.ToString()]!=null)
            {
                toolStrip1.Items["tsb" + e.ActiveTool.ToString()].BackColor = Color.PeachPuff;
            }
        }

        private void Image_ChangeEvent(bool isZoom,EventArgs e)
        {
            try
            {
                if(SourceImage!=null)
                {
                    HOperatorSet.ClearWindow(M_windowID);
                    toolStripStatusLabelSize1.Text = m_imageWidth.I.ToString() + "*" + m_imageHeight.I.ToString();
                    HTuple row1, column1, row2, column2;
                    //如果是在缩放
                    if (isZoom)
                    {
                        ZoomToFit(out row1, out column1, out row2, out column2);
                    }
                    else
                    {
                        HOperatorSet.GetPart(M_windowID, out row1, out column1, out row2, out column2);
                    }
                    HOperatorSet.SetPart(M_windowID, row1, column1, row2, column2);
                    HOperatorSet.DispObj(m_sourceImage,M_windowID);
                    if (m_bIsShowCross)
                    {
                        HOperatorSet.SetColor(M_windowID, "blue");
                        HOperatorSet.DispLine(M_windowID, 0, m_dbCrossCol, m_imageHeight, m_dbCrossCol);
                        HOperatorSet.DispLine(M_windowID, m_dbCrossRow, 0, m_dbCrossRow, m_imageWidth);
                    }
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ZoomToFit(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
        {
            double ratioWidth = (1.0) * m_imageWidth[0].I / ViewerControl.Width;
            double ratioHeight = (1.0) * m_imageHeight[0].I / ViewerControl.Height;

            row1 = 0;
            column1 = 0;
            row2 = 0;
            column2 = 0;
            //if ((ratioWidth >= 1) || (ratioHeight >= 1))
            //{
            if (ratioWidth >= ratioHeight)
            {
                double overSize = ((ViewerControl.Height * ratioWidth) - m_imageHeight) / 2;
                row1 = -overSize;
                column1 = 0;
                row2 = m_imageHeight + overSize;
                column2 = m_imageWidth - 1;
            }
            else
            {
                double overSize = ((ViewerControl.Width * ratioHeight) - m_imageWidth) / 2;
                row1 = 0;
                column1 = -overSize;
                row2 = m_imageHeight - 1;
                column2 = m_imageWidth + overSize;
            }
         
        }
        private bool m_bIsShowCross = false;

        //public bool IsShowCross
        //{
        //  get { return m_bIsShowCross; }
        //  set {
        //        m_bIsShowCross = value;
                    
        //      }
        //}

        private bool m_bCanImageMove = false; //图像是否可以移动
        //变量定义
        private double m_dbCrossRow = 0;  //图像的中心线坐标。
        private double m_dbCrossCol = 0;
        private int m_nSelectedRoi = -1; //选择ROI的索引
        private bool m_bIsRoIselected = false; //是否选择ROI
        private object m_showImgLock = new object(); //是否显示图像的互斥锁。
        //定义一个泛型用来表示所有StripButton按钮的集合
        private List<ToolStripButton> m_listTools = new List<ToolStripButton>();//工具控件
        private List<ShowObject> m_listShowObjects = new List<ShowObject>();// 显示对象
        private List<ShowText> m_listshowTexts = new List<ShowText>();    //显示文字
        private ROIManager m_roiManager = new ROIManager();//ROI集合
        private Action ExecuteImageHandle;


        public bool IsSetCross { get; set; } = false;
       /// <summary>
       /// 返回窗体类型的对象
       /// </summary>
        public HWindowControl ViewerInstance { get => ViewerControl; }
        /// <summary>
        /// 鼠标按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewerControl_HMouseDown(object sender, HMouseEventArgs e)
        {
            if (m_imageHeight != null)
            {
                if (e.Button==MouseButtons.Middle)
                {
                    if (!m_bCanImageMove)
                    {
                        m_bCanImageMove = true;
                    }
                }
                try
                {
                    HTuple Row, Column, Button;
                    HOperatorSet.GetMposition(M_windowID, out Row, out Column, out Button);
                    m_rowMouseDown = Row;
                    m_colMouseDown = Column;
                }
                catch (Exception)
                {
                }
            }
            //如果按下的不是鼠标右键
            else if(e.Button==MouseButtons.Left)
            {
                if (ActiveTool==ViewTools.Rectangle)
                {
                    ROIRectangle rOIRectangle = new ROIRectangle();
                    rOIRectangle.SetColor(M_windowID, "red");
                    rOIRectangle.SetDraw(M_windowID, "margin");
                    rOIRectangle.SetLineWidth (M_windowID, 2);
                    rOIRectangle.DarwRoi(M_windowID);
                    HRegion regions=  rOIRectangle.getRegion();
                    if (SourceImage != null)
                    {
                        HOperatorSet.DispObj(m_sourceImage, M_windowID);
                        HOperatorSet.DispObj(regions, M_windowID);
                    }
                }
            }
        }

        private void ViewerControl_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Middle)
            {
                if (m_bCanImageMove)
                {
                    if (m_imageHeight!=null)
                    {
                        HOperatorSet.SetSystem("flush_graphic", "false");
                        HTuple row1, col1, row2, col2, Row, Column, Button;
                        HOperatorSet.GetMposition(M_windowID, out Row, out Column, out Button);
                        double RowMove = Row - m_rowMouseDown;   //鼠标移动时的行坐标减去按下时的行坐标，得到行坐标的移动值
                        double ColMove = Column - m_colMouseDown;//鼠标移动时的列坐标减去按下时的列坐标，得到列坐标的移动值
                        HOperatorSet.GetPart(M_windowID, out row1, out col1, out row2, out col2);//得到当前的窗口坐标
                        HOperatorSet.SetPart(M_windowID, row1 - RowMove, col1 - ColMove, row2 - RowMove, col2 - ColMove);
                        HOperatorSet.ClearWindow(M_windowID);
                        HOperatorSet.SetSystem("flush_graphic", "true");
                        HOperatorSet.DispObj(m_sourceImage, M_windowID);
                        if (m_bIsShowCross)
                        {
                            HOperatorSet.SetColor(M_windowID, "blue");
                            HOperatorSet.DispLine(M_windowID, 0, m_dbCrossCol, m_imageHeight, m_dbCrossCol);
                            HOperatorSet.DispLine(M_windowID, m_dbCrossRow, 0, m_dbCrossRow, m_imageWidth);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请加载一张图片");
                    }
                }
            }
            if (m_imageHeight != null)
            {
                try
                {
                    HTuple Row, Column, Button, pointGray;
                    HOperatorSet.GetMposition(M_windowID, out Row, out Column, out Button);//获取当前鼠标的坐标值
                    if (m_imageHeight != null && (Row > 0 && Row < m_imageHeight) && (Column > 0 && Column < m_imageWidth))//判断鼠标在图像上
                    {
                        HOperatorSet.GetGrayval(m_sourceImage, Row, Column, out pointGray);//获取当前点的灰度值
                        toolStripStatusLabelCoordinate.Text = Column.ToString() + "," + Row.ToString();
                        toolStripStatusrgbValue.Text = pointGray.ToString();
                    }
                    else
                    {
                        pointGray = "_";
                    }
                }
                catch
                { }
            }
        }
        #region
        /// <summary>
        /// 菜单内容按钮打开时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemZoom.Enabled = (m_sourceImage != null);
            toolStripMenuItemSave.Enabled = (m_sourceImage != null);
            toolStripMenuItemSaveWindow.Enabled = (m_sourceImage != null);
            toolStripMenuItemRegistered.Enabled = (m_sourceImage != null);
        }

        private void toolStripMenuItemZoom_Click(object sender, EventArgs e)
        {
            ResetWndCtrl(true);
        }
        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BMP File|*.bmp|PNG File|*.png|JPEG File|*.jpg|All|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    if (m_sourceImage != null)
                    {
                        m_sourceImage.Dispose();
                    }
                    //HOperatorSet.ReadImage(out source_Image, ofd.FileName);
                    m_sourceImage = new HImage(ofd.FileName);
                    if (m_sourceImage != null)
                    {
                        HTuple channel;
                        HOperatorSet.CountChannels(m_sourceImage, out channel);
                        toolStripStatusLabelChannel.Text = channel.I.ToString();
                        HOperatorSet.GetImageSize(m_sourceImage, out m_imageWidth, out m_imageHeight);//获取图像大小
                        m_dbCrossRow = m_imageHeight / 2;
                        m_dbCrossCol = m_imageWidth / 2;
                    }
                    ResetWndCtrl(true);
                }
            }
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP File|*.bmp|PNG File|*.png|JPEG File|*.jpg|All|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(sfd.FileName))
                {
                    HOperatorSet.WriteImage(m_sourceImage, Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);
                }
            }
        }

        private void toolStripMenuItemSaveWindow_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP File|*.bmp|PNG File|*.png|JPEG File|*.jpg|All|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(sfd.FileName))
                {
                    HObject hObject;
                    HOperatorSet.DumpWindowImage(out hObject, M_windowID);
                    HOperatorSet.WriteImage(hObject, Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);
                    hObject.Dispose();
                }
            }
        }

        private void toolStripMenuItemRegistered_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + @"\ModelImage"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\ModelImage");
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath + @"\ModelImage";
            sfd.Filter = "PNG File|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(sfd.FileName))
                {
                    HOperatorSet.WriteImage(m_sourceImage, "png", 0, sfd.FileName);
                }
            }
        }
        public void ResetWndCtrl(bool isZoom)
        {
            lock (m_showImgLock)
            {
                if (OnImageChanged != null)
                {
                    ViewerControl.BeginInvoke((MethodInvoker)delegate ()
                    {
                        OnImageChanged(isZoom, new EventArgs());
                    });
                }
            }
        }
        #endregion

        #region 刷新显示的对象和文本
        public void  ResetShowObjects()
        {
            lock(m_showImgLock)
            {
                for (int i = 0; i < m_listShowObjects.Count; i++)
                {
                    m_listShowObjects[i].ShowHObject.Dispose();
                }
                m_listShowObjects = new List<ShowObject>();
            }
        }

        public void SetShowObjcts(List<ShowObject> objects)
        {
            lock(m_showImgLock)
            {
                for (int i = 0; i < m_listShowObjects.Count; i++)
                {
                    m_listShowObjects[i].ShowHObject.Dispose();
                }
                m_listShowObjects = objects;
            }
        }
        public void AddShowObject(ShowObject hobject)
        {
            lock(m_showImgLock)
            {
                m_listShowObjects.Add(hobject);
            }
        }
        public void RefreshShowObjects()
        {
            for (int i = 0; i < m_listShowObjects.Count; i++)
            {
                HOperatorSet.SetColor(M_windowID, m_listShowObjects[i].ShowColor);
                HOperatorSet.SetDraw(M_windowID, m_listShowObjects[i].DrawMode);
                HOperatorSet.DispObj(m_listShowObjects[i].ShowHObject, M_windowID);
            }
        }
        public void ResetShowTexts()
        {
            lock (m_showImgLock)
            {
                m_listshowTexts = new List<ShowText>();
            }
        }

        public void SetTexts(List<ShowText> objects)
        {
            lock (m_showImgLock)
            {
                m_listshowTexts = objects;
            }
        }

        public void AddShowText(ShowText hObject)
        {
            lock (m_showImgLock)
            {
                m_listshowTexts.Add(hObject);
            }
        }

        public void RefreshShowTexts()
        {
            for (int i = 0; i < m_listshowTexts.Count; i++)
            {
                HOperatorSet.SetColor(M_windowID, m_listshowTexts[i].ShowColor);
                HOperatorSet.SetTposition(M_windowID, m_listshowTexts[i].PositionY, m_listshowTexts[i].PositionX);
                HOperatorSet.WriteString(M_windowID, m_listshowTexts[i].ShowContent);
            }
        }
        #endregion

        public void SetROICount(int count)
        {
            m_roiManager.SetMaxCount(count);
        }
        public void ResetRoIs()
        {
            m_roiManager.ResetROIs();
        }
        public void SetROIs(List<ROIBase> rois)
        {
            m_roiManager.SetROIs(rois);
        }
        public void AddROI(ROIBase rois)
        {
            m_roiManager.AddROI(rois);
        }

        ~HobjectViewer()
        {
            ReleaseRam();
        }
        public void ReleaseRam()
        {
            ViewerControl.Dispose();
            for (int i = 0; i < m_listShowObjects.Count; i++)
            {
                m_listShowObjects[i].ShowHObject.Dispose();
            }
            for (int i = 0; i < m_roiManager.ROICount; i++)
            {
                m_roiManager.GetROIByIndex(i).Drawobject.Dispose();
            }
            if (m_sourceImage != null)
            {
                m_sourceImage.Dispose();
            }
            if (SourceImage != null)
            {
                SourceImage.Dispose();
            }
            this.Dispose();
            GC.Collect();
        }

        private void ViewerControl_HMouseUp(object sender, HMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (m_bCanImageMove)
                {
                    m_bCanImageMove = !m_bCanImageMove;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (m_bIsRoIselected)
                {
                    if (ExecuteImageHandle != null)
                    {
                        ExecuteImageHandle.Invoke();
                    }
                    m_bIsRoIselected = false;
                }
            }
        }

        private void ViewerControl_HMouseWheel(object sender, HMouseEventArgs e)
        {
            if (m_sourceImage != null)
            {
                try
                {
                    HTuple Zoom, MouseRow, MouseCol, Button;
                    HTuple ImageLeftRow, ImageLeftCol, ImageRightRow, ImageRightCol, DisplayHeight, DisplayWidth, DisplayLeftRow, DisplayLeftCol, DisplayRightRow, DisplayRightCol;
                    if (e.Delta > 0)
                    {
                        Zoom = 1.5;
                    }
                    else
                    {
                        Zoom = 0.5;
                    }
                    HOperatorSet.GetMposition(M_windowID, out MouseRow, out MouseCol, out Button);//获取当前鼠标位置
                    HOperatorSet.GetPart(M_windowID, out ImageLeftRow, out ImageLeftCol, out ImageRightRow, out ImageRightCol);//获取显示在窗口中的图像内容像素位置
                    DisplayHeight = ImageRightRow - ImageLeftRow;
                    DisplayWidth = ImageRightCol - ImageLeftCol;
                    if (DisplayHeight * DisplayWidth < 32000 * 32000 || Zoom == 1.5)//普通版halcon能处理的图像最大尺寸是32K*32K。如果无限缩小原图像，导致显示的图像超出限制，则会造成程序崩溃
                    {
                        DisplayLeftRow = (ImageLeftRow + ((1 - (1.0 / Zoom)) * (MouseRow - ImageLeftRow)));
                        DisplayLeftCol = (ImageLeftCol + ((1 - (1.0 / Zoom)) * (MouseCol - ImageLeftCol)));
                        DisplayRightRow = DisplayLeftRow + (DisplayHeight / Zoom);
                        DisplayRightCol = DisplayLeftCol + (DisplayWidth / Zoom);
                        HOperatorSet.SetPart(M_windowID, DisplayLeftRow, DisplayLeftCol, DisplayRightRow, DisplayRightCol);
                        HOperatorSet.ClearWindow(M_windowID);
                        HOperatorSet.DispObj(m_sourceImage, M_windowID);
                        if (m_bIsShowCross)
                        {
                            HOperatorSet.SetColor(M_windowID, "blue");
                            HOperatorSet.DispLine(M_windowID, 0, m_dbCrossCol, m_imageHeight, m_dbCrossCol);
                            HOperatorSet.DispLine(M_windowID, m_dbCrossRow, 0, m_dbCrossRow, m_imageWidth);
                        }
                        RefreshShowObjects();
                        RefreshShowTexts();
                    }
                }
                catch (HOperatorException he)
                { }
            }
        }

        /// <summary>
        /// 图像改变事件
        /// </summary>
        /// <param name="isZoom"></param>
        /// <param name="e"></param>
        public delegate void ImageChangedEventHandler(bool isZoom, EventArgs e);
        public event ImageChangedEventHandler OnImageChanged;


       
    }
}
