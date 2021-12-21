using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconFunction
{
  public  class ShowObject
   {
        public HObject ShowHObject { get; set; }

        public string ShowColor { get; set; } = "red";

        public string DrawMode { get; set; } = "margin";
        public  ShowObject(HObject hObject,string Color="red",string drawMode="margin")
        {
            ShowHObject = hObject;
            ShowColor = Color;
            DrawMode = drawMode;
        }
   }
}
