using System;
using System.Reflection;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            ProduceInfoEx produceInfo = new ProduceInfoEx();
            foreach (var fi in produceInfo.GetType().GetProperties())
            {
                Console.WriteLine(fi.Name);
            }
            Console.Read();
        }
        public class ProduceInfoEx
        {
            public DateTime ProduceTime { get; set; } //生产时间

            public string BatteryCode { get; set; } //顶盖产品条码

            public string NgCount { get; set; } //投入产品生产NG次数

            public string OnloadTime { get; set; } //进站时间

            public short WeldSpeed { get; set; } //焊接速度

            public short HipotNumber { get; set; } //短路测试仪设备编号

            public string HipotResult { get; set; } //封口脉冲短路测试结果

            public string HipotResultItem { get; set; } //封口脉冲短路测试结果原因


            public short Hipot_AB_SetVoltage { get; set; } //A-B封口脉冲短路测试测试电压

            public short Hipot_AB_HoldVoltage { get; set; } //A-B封口脉冲短路测试保压电压

            public float Hipot_AB_SetChargTime { get; set; } //A-B封口脉冲短路测试充电时间

            public float Hipot_AB_ActChargTime { get; set; } //A-B封口脉冲短路测试时间

            public float Hipot_AB_ChargTime_LowLimit { get; set; } //A-B封口脉冲短路测试充电时间下限

            public float Hipot_AB_ChargTime_UpLimit { get; set; } //A-B封口脉冲短路测试充电时间上限

            public short Hipot_AB_Vd1 { get; set; } //A-B封口脉冲短路测试压降1

            public short Hipot_AB_Vd2 { get; set; } //A-B封口脉冲短路测试压降2

            public float Hipot_AB_Vd1Set { get; set; } //A-B封口脉冲短路测试压降1设定值

            public float Hipot_AB_Vd2Set { get; set; } //A-B封口脉冲短路测试压降2设定值

            public string Hipot_AB_Result { get; set; } //A-B封口脉冲短路测试结果


            public float Hipot_AC_ChargTime { get; set; } //封口脉冲短路测试A-C时间

            public string Hipot_AC_Result { get; set; } //封口脉冲短路测试A-C结果


            public short Hipot_BC_SetVoltage { get; set; } //封口脉冲短路测试B-C电压

            public short Hipot_BC_HoldVoltage { get; set; } //封口脉冲短路测试B-C保压电压

            public float Hipot_BC_ActChargTime { get; set; } //封口脉冲短路测试B-C测试时间

            public float Hipot_BC_ActResist { get; set; } //封口脉冲短路测试B-C电阻值

            public string Hipot_BC_Result { get; set; } //封口脉冲短路测试B-C结果


            public float TopRollRightAgnle { get; set; } //顶部滚压右角度值

            public float TopRollLeftAgnle { get; set; } //顶部滚压左角度值

            public float SideRollRightAgnle { get; set; } //侧面滚压右角度值

            public float SideRollLeftAgnle { get; set; } //侧面滚压左角度值

            public float TopRollPressure { get; set; } //顶部滚压压力

            public short WeldStation { get; set; } //焊接工位

            public float DefocusData { get; set; } //离焦量

            public float NitrogenFlow { get; set; } //保护氮气流量

            public string CCDCheckResult { get; set; } //焊接质量CCD检测结果

            public float LaserCenterPower1 { get; set; } //中心光斑功率1

            public float LaserCenterPower2 { get; set; } //中心光斑功率2

            public float LaserCenterPower3 { get; set; } //中心光斑功率3

            public float LaserCenterPower4 { get; set; } //中心光斑功率4

            public float LaserCenterPower5 { get; set; } //中心光斑功率5

            public float LaserAnnularPower1 { get; set; } //环形光斑功率1

            public float LaserAnnularPower2 { get; set; } //环形光斑功率2

            public float LaserAnnularPower3 { get; set; } //环形光斑功率3

            public float LaserAnnularPower4 { get; set; } //环形光斑功率4

            public float LaserAnnularPower5 { get; set; } //环形光斑功率5

            public short BatteryNGItem { get; set; } //电池NG原因

            public string TotalResult { get; set; } //总结果

            public string XMFK_CBRS { get; set; } //长边熔深

            public string XMFK_DBRS { get; set; } //短边熔深

            public string XMFK_CBRK { get; set; } //长边熔宽

            public string XMFK_DBRK { get; set; } //短边熔宽
        }
    }
}