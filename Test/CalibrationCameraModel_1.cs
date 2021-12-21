using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
	[Serializable]
	public class CalibrationCameraModel_1
	{
        // Token: 0x060003F8 RID: 1016 RVA: 0x0003A054 File Offset: 0x00038254
        //public CalibrationCameraModel_1(HWindowControl HWIN)
        //{
        //	HTuple htuple = 5472;
        //	HTuple htuple2 = 3648;
        //	this._initCamParam = new HTuple(new HTuple[]
        //	{
        //		"area_scan_telecentric_division",
        //		0.064,
        //		0,
        //		2.4E-06,
        //		2.4E-06,
        //		htuple / 2,
        //		htuple2 / 2,
        //		htuple,
        //		htuple2
        //	});
        //	this._calibObjectPath = "DATA//caltab.descr";
        //	this.Hwinex = HWIN;
        //	this.CreateCalibationDataModel();
        //}
        public CalibrationCameraModel_1(HWindowControl HWIN)
        {
            HTuple htuple = 1280;
            HTuple htuple2 = 1024;
            this._initCamParam = new HTuple(new HTuple[]
            {
                "area_scan_telecentric_division",
                0.064,
                0,
                5.3E-06,
                5.3E-06,
                htuple / 2,
                htuple2 / 2,
                htuple,
                htuple2
            });
            this._calibObjectPath = "D:/模板/测量拟合/标定/BJB1.descr";
            this.Hwinex = HWIN;
            this.CreateCalibationDataModel();
        }
        // Token: 0x060003F9 RID: 1017 RVA: 0x0003A168 File Offset: 0x00038368
        private void CreateCalibationDataModel()
		{

			HOperatorSet.CreateCalibData("calibration_object", 1, 1, out this.CalibDataID);
			HOperatorSet.SetCalibDataCamParam(this.CalibDataID, 0, "area_scan_division", this._initCamParam);
			HOperatorSet.SetCalibDataCalibObject(this.CalibDataID, 0, this._calibObjectPath);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0003A1D4 File Offset: 0x000383D4
		private bool FindCalibObject(HObject img, int idx)
		{
			bool result;
			try
			{
				HOperatorSet.DispObj(img, Hwinex.HalconWindow);
				HOperatorSet.FindCalibObject(img, this.CalibDataID, 0, 0, idx, new HTuple(), new HTuple());
				HObject hObj;
				HOperatorSet.GetCalibDataObservContours(out hObj, this.CalibDataID, "caltab", 0, 0, idx);
				HObject hObj2;
				HOperatorSet.GetCalibDataObservContours(out hObj2, this.CalibDataID, "marks", 0, 0, idx);

				HOperatorSet.SetColor(Hwinex.HalconWindow, "green");	
				//HOperatorSet.SetColor("green", Hwinex.HalconWindow);
				HOperatorSet.DispObj(hObj, Hwinex.HalconWindow);
				HOperatorSet.SetColor(Hwinex.HalconWindow, "blue");
				HOperatorSet.DispObj(hObj2, Hwinex.HalconWindow);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("未找到标定板" + ex.ToString()); 
				result = false;
			}
			return result;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0003A2C4 File Offset: 0x000384C4
		public bool FindCalibObject(HObject img, bool isAddToModel)
		{
			bool flag = this.FindCalibObject(img, 0);
			bool result;
			if (flag)
			{
				if (isAddToModel)
				{
					this.ObserveImageList.Add(img.Clone());
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0003A304 File Offset: 0x00038504
		public double Calibration()
		{
			for (int i = 0; i < this.ObserveImageList.Count; i++)
			{
				this.FindCalibObject(this.ObserveImageList[i], i);
			}
			HTuple htuple;
			HOperatorSet.CalibrateCameras(this.CalibDataID, out htuple);
			HOperatorSet.GetCalibData(this.CalibDataID, "camera", 0, "params", out this.CameraInParamerer);
			HOperatorSet.GetCalibData(this.CalibDataID, "calib_obj_pose", new HTuple(new int[2]), "pose", out this.CameraOutParamerer);
			this.CalibError = htuple;
			bool flag = this.ObserveImageList.Count > 0;
			if (flag)
			{
				HTuple htuple2;
				HTuple htuple3;
				HOperatorSet.GetImageSize(this.ObserveImageList[0], out htuple2, out htuple3);
				HTuple row = new HTuple(new int[]
				{
					0,
					0,
					htuple3.I
				});
				int[] array = new int[3];
				array[1] = htuple2.I;
				HTuple htuple4;
				HTuple htuple5;
				this.ImagePointsToWordPlane(row, new HTuple(array), out htuple4, out htuple5);
				HTuple htuple6;
				HOperatorSet.DistancePp(htuple4[0], htuple5[0], htuple4[1], htuple5[1], out htuple6);
				HTuple htuple7;
				HOperatorSet.DistancePp(htuple4[0], htuple5[0], htuple4[2], htuple5[2], out htuple7);
				this.ImagePort.X = (float)htuple2.D;
				this.ImagePort.Y = (float)htuple3.D;
				this.ViewPort.X = (float)htuple6.D;
				this.ViewPort.Y = (float)htuple7.D;
			}
			return htuple.D;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0003A4EC File Offset: 0x000386EC
		public double ImagePointsToWordPlane(HTuple row, HTuple column, out HTuple x, out HTuple y)
		{
			HOperatorSet.ImagePointsToWorldPlane(this.CameraInParamerer, this.CameraOutParamerer, row, column, "mm", out x, out y);
			return (double)x.Length;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0003A527 File Offset: 0x00038727
		public void AddData(HObject img)
		{
			this.ObserveImageList.Add(img);
		}

		public void RemoveData(int inx)
		{
			this.ObserveImageList.RemoveAt(inx);
		}

		public HObject GetImage(int inx)
		{
			return this.ObserveImageList[inx];
		}


		private HTuple _initCamParam = null;

		private HTuple _calibObjectPath = null;

		[NonSerialized]
		public List<HObject> ObserveImageList = new List<HObject>();
		[NonSerialized]
		public HWindowControl Hwinex = null;

		[NonSerialized]
		public HTuple CalibDataID = null;


		public HTuple CameraInParamerer = null;


		public HTuple CameraOutParamerer = null;


		public HTuple CalibError = null;

		public PointF ImagePort = PointF.Empty;

		public PointF ViewPort = PointF.Empty;
	}
}
