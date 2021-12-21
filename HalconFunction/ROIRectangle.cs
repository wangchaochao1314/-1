using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconFunction
{
     public   class ROIRectangle:ROIBase
    {
        public double Row1 { get; set; } = 0;

        public double Column1 { get; set; } = 0;

        public double Row2 { get; set; } = 0;

        public double Column2 { get; set; }

   

        public override void DarwRoi(HTuple HalconWindowControl)
        {
            HTuple row1, co1umn1, row2, column2 = null;
            HOperatorSet.DrawRectangle1(HalconWindowControl, out row1, out co1umn1, out row2, out column2);
            Row1 = row1;
            Column1 = co1umn1;
            Row2 = row2;
            Column2 = column2;

        }
        public virtual void SetColors(HTuple HalconWindowControl, string color)
        {
            HOperatorSet.SetColor(HalconWindowControl, color);
        }
        public override void SetColor(HTuple HalconWindowControl, string color)
        {
            HOperatorSet.SetColor(HalconWindowControl,color);
        }
        public override void SetDraw(HTuple HalconWindowControl, string value)
        {
            HOperatorSet.SetDraw(HalconWindowControl, value);
        }

        public override void SetLineWidth(HTuple HalconWindowControl, int value)
        {
            HOperatorSet.SetDraw(HalconWindowControl, value);
        }
        public override HRegion getRegion()
        {
         HObject region = null;
          HOperatorSet.GenRectangle1(out region, Row1, Column1, Row2, Column2);
         return (HRegion)region;
        }

     
    }
}
