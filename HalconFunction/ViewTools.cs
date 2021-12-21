using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconFunction
{
    [Category("枚举类") ,Description("表示窗口缩放以及绘制ROI使用的工具(包含矩形圆直线等)")]
    public  enum ViewTools
    {
        Arrow=1,
        ZoomIn=2,
        ZommOut=4,
        Hand=8,
        Rectangle=16,
        RotateRectangle=32,
        Circle=64,
        Ellipse=128,
        Line=256
    }

}
