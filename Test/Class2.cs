using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
	public class GlobalData_SpotUp
	{
        public CaliCfg CaLi
        {
            get
            {
                return GG_CFG.Instance.CaLi;
            }
            set
            {
                this.CaLi = value;
            }
        }
     
        [NonSerialized]
        private static GlobalData_SpotUp _instance;
       


        public static GlobalData_SpotUp Instance
        {
            get
            {
                bool flag = GlobalData_SpotUp._instance == null;
                if (flag)
                {
                    new GlobalData_SpotUp();
                }
                return GlobalData_SpotUp._instance;
            }
            set
            {
                GlobalData_SpotUp._instance = value;
            }
        }

    
        // Token: 0x06000211 RID: 529 RVA: 0x00011BE8 File Offset: 0x0000FDE8
        public int ReadData()
        {
           string path = CONFIG.Path_Product + "spotup.cfg";
            bool flag = !File.Exists(path);
            int result;
            if (flag)
            {
                result = -1;
            }
            else
            {
                try
                {
                    GlobalData_SpotUp instance;
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        instance = (GlobalData_SpotUp)binaryFormatter.Deserialize(fileStream);
                        fileStream.Close();
                    }
                    GlobalData_SpotUp.Instance = instance;
                    try
                    {
                        GG_CFG.Instance.ReadData();
                    }
                    catch (Exception)
                    {
                    }
                }
                catch (Exception ex)
                {
                //  LOG.LogError("读取焊点检测数据出错," + ex.ToString());
                    return -2;
                }
                result = 0;
            }
            return result;
        }

        // Token: 0x06000212 RID: 530 RVA: 0x00011CC0 File Offset: 0x0000FEC0
        public int WriteData()
        {
            try
            {
                 string path = CONFIG.Path_Product + "spotup.cfg";
                GlobalData_SpotUp instance = GlobalData_SpotUp.Instance;
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, instance);
                fileStream.Close();
            }
            catch (Exception ex)
            {
               // LOG.LogError("存储数据出错:" + ex.ToString());
                MessageBox.Show("存储数据出错:" + ex.ToString());
            }
            try
            {
                GG_CFG.Instance.WriteData();
            }
            catch (Exception)
            {
            }
            return 0;
        }



        internal class GG_CFG
        {
            // Token: 0x17000020 RID: 32
            // (get) Token: 0x06000207 RID: 519 RVA: 0x0001195C File Offset: 0x0000FB5C
            // (set) Token: 0x06000208 RID: 520 RVA: 0x00011985 File Offset: 0x0000FB85
            public static GG_CFG Instance
            {
                get
                {
                    bool flag = GG_CFG._instance == null;
                    if (flag)
                    {
                        new GG_CFG();
                    }
                    return GG_CFG._instance;
                }
                set
                {
                    GG_CFG._instance = value;
                }
            }

            // Token: 0x06000209 RID: 521 RVA: 0x00011990 File Offset: 0x0000FB90
            public GG_CFG()
            {
                GG_CFG.Instance = this;
                bool flag = this.ReadData() != 0;
                if (flag)
                {
                    MessageBox.Show("加载焊点检测参数错误:请查看错误日志");
                }
            }

            // Token: 0x0600020A RID: 522 RVA: 0x000119D4 File Offset: 0x0000FBD4
            public int ReadData()
            {
                string path = CONFIG.Path_Data + "gl.ini";
                bool flag = !File.Exists(path);
                int result;
                if (flag)
                {
                    result = -1;
                }
                else
                {
                    try
                    {
                        GG_CFG instance;
                        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            instance = (GG_CFG)binaryFormatter.Deserialize(fileStream);
                            fileStream.Close();
                        }
                        GG_CFG.Instance = instance;
                    }
                    catch (Exception ex)
                    {
                        //LOG.LogError("读取焊点检测数据出错," + ex.ToString());
                        return -2;
                    }
                    result = 0;
                }
                return result;
            }

            // Token: 0x0600020B RID: 523 RVA: 0x00011A8C File Offset: 0x0000FC8C
            public int WriteData()
            {
                try
                {
                    string path = CONFIG.Path_Data + "gl.ini";
                    GG_CFG instance = GG_CFG.Instance;
                    FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, instance);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                //  LOG.LogError("存储数据出错:" + ex.ToString());
                    MessageBox.Show("存储数据出错:" + ex.ToString());
                }
                return 0;
            }

            // Token: 0x0400011B RID: 283
            [NonSerialized]
            private static GG_CFG _instance;

            // Token: 0x0400011C RID: 284
            public CaliCfg CaLi = new CaliCfg();
        }


        #region
        public class CONFIG
        {
            // Token: 0x17000018 RID: 24
            // (get) Token: 0x060001A4 RID: 420 RVA: 0x0000B74C File Offset: 0x0000994C
            public static string Path_Product
            {
                get
                {
                    return CONFIG.Path_Data + CONFIG.CurrentProductName + "//";
                }
            }

            // Token: 0x17000019 RID: 25
            // (get) Token: 0x060001A5 RID: 421 RVA: 0x0000B774 File Offset: 0x00009974
            // (set) Token: 0x060001A6 RID: 422 RVA: 0x0000B79A File Offset: 0x0000999A
            public static string CurrentProductName
            {
                get
                {
                    // return INI.GetString("Product", "Name", CONFIG.Path_MainConfigFile);
                    return "";
                }
                set
                {
                }
            }

            // Token: 0x060001A7 RID: 423 RVA: 0x0000B7A0 File Offset: 0x000099A0
            public static string GetCaliDataPath(int index)
            {
                return CONFIG.Path_Data + "cali" + index.ToString() + ".tup";
            }

            // Token: 0x060001A8 RID: 424 RVA: 0x0000B7D0 File Offset: 0x000099D0
            //public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
            //{
            //    MemberExpression memberExpression2 = (MemberExpression)memberExpression.Body;
            //    return memberExpression2.Member.Name;
            //}

            // Token: 0x060001A9 RID: 425 RVA: 0x0000B7FC File Offset: 0x000099FC
            public static string GetStartPath()
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                bool flag = !baseDirectory.Contains(":");
                string result;
                if (flag)
                {
                    result = "D://TCO//Debug";
                }
                else
                {
                    result = baseDirectory;
                }
                return result;
            }

            // Token: 0x04000080 RID: 128
            public static bool ISTEST = false;

            // Token: 0x04000081 RID: 129
            public static string Path_Data = CONFIG.GetStartPath() + "//Data//";

            // Token: 0x04000082 RID: 130
            public static string Path_MainConfigFile = CONFIG.GetStartPath() + "//Data//Config.ini";

            // Token: 0x04000083 RID: 131
            public static int NgRestartCount = 3;

            // Token: 0x04000084 RID: 132
            public static int CameraCount = 3;

            // Token: 0x04000085 RID: 133
            public static string[] CameraNames = new string[]
            {
            "尺寸测量",
            "正面焊点",
            "反面焊点"
            };

            // Token: 0x04000086 RID: 134
            public static string ImageSavePath = "D:\\TImages\\";

            // Token: 0x04000087 RID: 135
            public static bool IsCommunication = true;

            // Token: 0x04000088 RID: 136
            public static int ExceptionDX = 0;

            // Token: 0x04000089 RID: 137
            public static int ExceptionDY = 0;

            // Token: 0x0400008A RID: 138
            public static int ExceptionDU = 0;

            // Token: 0x0400008B RID: 139
            public static int ExceptionParallel = 20;

            // Token: 0x0400008C RID: 140
            public static int ExceptionVertical = 20;

            // Token: 0x0400008D RID: 141
            public static int MHandWork = 0;

            // Token: 0x0400008E RID: 142
            public static int DrawCount = 0;
        }

        #endregion

        /*
        public Point6D m_get_spot_position(HObject ho_Image, HTuple hv_InRow, HTuple hv_InCol, HTuple hv_Radius, HTuple hv_CircuitBreakerValue)
        {
            HObject hobject = null;
            HTuple htuple = new HTuple();
            HTuple htuple2 = new HTuple();
            HTuple htuple3 = new HTuple();
            HTuple htuple4 = new HTuple();
            HTuple htuple5 = new HTuple();
            HTuple htuple6 = new HTuple();
            HObject hobject2;
            HOperatorSet.GenEmptyObj(out hobject2);
            HObject hobject3;
            HOperatorSet.GenEmptyObj(out hobject3);
            HObject hobject4;
            HOperatorSet.GenEmptyObj(out hobject4);
            HOperatorSet.GenEmptyObj(out hobject);
            hobject2.Dispose();
            HOperatorSet.GenRectangle2(out hobject2, hv_InRow, hv_InCol, 0, 3 * hv_Radius, 3 * hv_Radius);
            hobject3.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, hobject2, out hobject3);
            hobject4.Dispose();
            HOperatorSet.InvertImage(hobject3, out hobject4);
            HTuple htuple7 = hv_InRow.Clone();
            HTuple htuple8 = hv_InCol.Clone();
            HTuple radius = hv_Radius.Clone();
            HTuple htuple9 = 0;
            while (htuple9 <= 5000)
            {
                bool flag = new HTuple(htuple9.TupleEqual(0)) != 0;
                if (flag)
                {
                    htuple = htuple7.Clone();
                    htuple2 = htuple8.Clone();
                }
                hobject.Dispose();
                HOperatorSet.GenCircle(out hobject, htuple, htuple2, radius);
                HOperatorSet.GrayFeatures(hobject, hobject4, new HTuple("row").TupleConcat("column"), out htuple3);
                htuple4 = htuple3.TupleSelect(0);
                htuple5 = htuple3.TupleSelect(1);
                HOperatorSet.DistancePp(htuple4, htuple5, htuple, htuple2, out htuple6);
                HTuple t = 10000;
                HOperatorSet.DistancePp(htuple4, htuple5, hv_InRow, hv_InCol, out t);
                bool flag2 = new HTuple(htuple6.TupleLess(0.1)).TupleOr(new HTuple(hv_CircuitBreakerValue.TupleLess(t))) != 0;
                if (flag2)
                {
                    break;
                }
                htuple = htuple4.Clone();
                htuple2 = htuple5.Clone();
                htuple9++;
            }
            hobject2.Dispose();
            hobject3.Dispose();
            hobject4.Dispose();
            hobject.Dispose();
            return new Point6D(htuple4.D, htuple5.D, 0.0, 0.0, 0.0, 0.0, "");
        }

        */
    }
}
