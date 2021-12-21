using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconFunction
{
     public abstract  class ROIBase
    {
        private ROIStatus m_ROIStatus = ROIStatus.UNION;
        
        public HObject Drawobject;

       public ROIStatus Status { get => m_ROIStatus; set => m_ROIStatus = value; }
       /// <summary>
       /// 绘制ROI
       /// </summary>
        public abstract void DarwRoi(HTuple HalconWindowControl);
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="color"></param>
        public abstract void SetColor(HTuple HalconWindowControl, string color);
        /// <summary>
        /// 设置线宽
        /// </summary>
        /// <param name="value"></param>
        public abstract void SetLineWidth(HTuple HalconWindowControl, int value);
        /// <summary>
        /// 是否填充
        /// </summary>
        /// <param name="value"></param>
        public abstract void SetDraw(HTuple HalconWindowControl, string value);
  
        /// <summary>
        /// 返回区域
        /// </summary>
        /// <returns></returns>
        public virtual HRegion getRegion()
        {
            return null;
        }



    }
}
