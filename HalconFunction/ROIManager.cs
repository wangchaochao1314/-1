using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconFunction
{
     public  class ROIManager
    {
        private int m_maxcount = 1;

        private List<ROIBase> m_listROIs = new List<ROIBase>();

        public int ROICount { get => m_listROIs.Count; }

        public void SetMaxCount(int count)
        {
            m_maxcount = count;
        }
        public void ResetROIs()
        {
            for (int i = 0; i < m_listROIs.Count ; i++)
            {
                m_listROIs[i].Drawobject.Dispose();
            }
            m_listROIs = new List<ROIBase>();
        }
        public void SetROIs(List<ROIBase> rois)
        {
            for (int i = 0; i < m_listROIs.Count; i++)
            {
                m_listROIs[i].Drawobject.Dispose();
            }
            m_listROIs = rois;
        }
        public List<ROIBase> GetROIs()
        {
            return m_listROIs;
        }
        //获取ROI的索引
        public ROIBase GetROIByIndex(int index)
        {
            if (index >= 0 && index < m_listROIs.Count - 1)
            {
                return m_listROIs[index];
            }
            return null;
        }
        public bool AddROI(ROIBase roi)
        {
            if (m_listROIs.Count< m_maxcount)
            {
                m_listROIs.Add(roi);
                return true;
            }
            return false;
        }
        //public void  DeleteROI(int index)
        //{
        //    for (int i = 0; i < m_listROIs.Count; i++)
        //    {
        //        if (m_listROIs[i].Drawobject.== index)
        //        {
        //            m_listROIs[i].Drawobject.Dispose();
        //            m_listROIs.RemoveAt(i);
        //            return;
        //        }
        //    }
        //}
    }
}
