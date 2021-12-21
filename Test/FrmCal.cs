using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class FrmCal : Form
    {
        public FrmCal()
        {
            InitializeComponent();
            this.Load += FrmCal_Load;
        }

        private void FrmCal_Load(object sender, EventArgs e)
        {

			hv_CameraParameters = new HTuple();
			hv_CameraPose = new HTuple();
			HOperatorSet.ReadCamPar(@"C:/Users/Administrator/Desktop/新建文件夹/compar223.dat", out hv_CameraParameters);
			HOperatorSet.ReadPose(@"C:/Users/Administrator/Desktop/新建文件夹/compar333.dat", out hv_CameraPose);
            HTuple x, y = new HTuple();

            HTuple row = 100;
            HTuple Cloumn = 100;
         
            HOperatorSet.ImagePointsToWorldPlane(hv_CameraParameters, hv_CameraPose, row, Cloumn, "mm", out x, out y);

        }

        private CalibrationCameraModel_1 _cali1;


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
			bool flag = this._cali1 == null;
			if (flag)
			{
				this._cali1 = new CalibrationCameraModel_1(this.hWindowControl1);
			}
			HObject img = this.GrabImage(0);
			bool flag2 = this._cali1.FindCalibObject(img, true);
			if (flag2)
			{
				this.UpdateImageList(this._cali1);
			}
		}
		private void UpdateImageList(CalibrationCameraModel_1 cm)
		{
			this.lb_LengthWidthImageList.Items.Clear();
			for (int i = 0; i < cm.ObserveImageList.Count; i++)
			{
				this.lb_LengthWidthImageList.Items.Add(string.Format("图像{0}", i + 1));
			}
		}

        private void lb_LengthWidthImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
			bool flag = this.lb_LengthWidthImageList.SelectedIndex > -1;
			if (flag)
			{
				this._cali1.FindCalibObject(this._cali1.ObserveImageList[this.lb_LengthWidthImageList.SelectedIndex], false);
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			bool flag = this.lb_LengthWidthImageList.SelectedIndex > -1;
			if (flag)
			{
				this._cali1.RemoveData(this.lb_LengthWidthImageList.SelectedIndex);
				this.UpdateImageList(this._cali1);
			}
		}
		//定义
		HTuple hv_CameraParameters = new HTuple();
		HTuple hv_CameraPose = new HTuple();
		private void btnCalibration_Click(object sender, EventArgs e)
		{
			double num = this._cali1.Calibration();
			string text = string.Concat(new string[]
			{
				string.Format("标定精度为: {0} pix \r\n", num),
				"内参为:",
				this._cali1.CameraInParamerer.ToString(),
				"\r\n外参为:",
				this._cali1.CameraOutParamerer.ToString(),
				"\r\n",
				string.Format("图像尺寸为:{0} pix x {1} pix\r\n", this._cali1.ImagePort.X, this._cali1.ImagePort.Y),
				string.Format("视野尺寸为:{0} mm x {1} mm\r\n", this._cali1.ViewPort.X, this._cali1.ViewPort.Y)
			});
			MessageBox.Show(text);
			


			//	WriteParameter(@"C:\Users\Administrator\Desktop\新建文件夹\compar222.stu");

			hv_CameraParameters = new HTuple();

		     string [] str=this._cali1.CameraInParamerer.ToString().Split(','); 

	    	hv_CameraParameters[0] = "area_scan_division";
			hv_CameraParameters[1] =   double.Parse(str[1]);
			hv_CameraParameters[2] = double.Parse(str[2]);
			hv_CameraParameters[3] = double.Parse(str[3]);
			hv_CameraParameters[4] = double.Parse(str[4]);
			hv_CameraParameters[5] = double.Parse(str[5]);
			hv_CameraParameters[6] = double.Parse(str[6]);
			hv_CameraParameters[7] = double.Parse(str[7]);
		      string newstr1=	 str[8].Replace("]", "").Trim();
			hv_CameraParameters[8] = double.Parse(newstr1);

			string[] PoseStr = this._cali1.CameraOutParamerer.ToString().Split(',');
			hv_CameraPose = new HTuple();
			hv_CameraPose[0] =double.Parse(PoseStr[0].Replace("[", "").Trim());
			hv_CameraPose[1] = double.Parse(PoseStr[1]);
			hv_CameraPose[2] = double.Parse(PoseStr[2]);
			hv_CameraPose[3] = double.Parse(PoseStr[3]);
			hv_CameraPose[4] = double.Parse(PoseStr[4]);
			hv_CameraPose[5] = double.Parse(PoseStr[5]);
			hv_CameraPose[6] = double.Parse(PoseStr[6].Replace("]", "").Trim());

			HOperatorSet.WriteCamPar(hv_CameraParameters, @"C:/Users/Administrator/Desktop/新建文件夹/compar223.dat");
			HOperatorSet.WritePose(hv_CameraPose, @"C:/Users/Administrator/Desktop/新建文件夹/compar333.dat");
			//HOperatorSet.WriteCamPar(hv_CameraParameters, @"C:\Users\Administrator\Desktop\新建文件夹\compar222.dat");
			//HOperatorSet.WritePose(_cali1.CameraOutParamerer.ToString(), @"C:\Users\Administrator\Desktop\新建文件夹\compar333.dat");
			//LOG.LogWarn(text);

		}

		private HObject GrabImage(int i = 0)
		{
			HObject hobject;
			HTuple width;
			HTuple height;
			//调一下主界面采图的方法
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = true;//该值确定是否可以选择多个文件
			dialog.Title = "请选择文件夹";
			dialog.Filter = "所有文件(*.*)|*.*";
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				//     string file = dialog.FileName;
			}
			string file = dialog.FileName;
			//HOperatorSet.CountSeconds(out T1);
			if (file == "")
			{
				return null;
			}
			//hWindow_Final1.ClearWindow();
			HOperatorSet.ReadImage(out hobject, file);
			HOperatorSet.GetImageSize(hobject, out width, out height);
			HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, height, width);

			//HObject hobject = FrmMain.Instance.Cameras.GrabImage(i);

			HOperatorSet.DispObj(hobject, hWindowControl1.HalconWindow);
			return hobject;
		}

		private void WriteParameter(string path)
        {
			System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, FileAccess.ReadWrite);
		
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fs, _cali1);
			MessageBox.Show("保存成功");
		}


		private void ReadParameter(string path)
        {
			System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, FileAccess.ReadWrite);
			BinaryFormatter formatter = new BinaryFormatter();
			_cali1=(CalibrationCameraModel_1) formatter.Deserialize(fs);

			
		}
	}
}
