using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
       public static  List<Point> Poi = new List<Point>();
        public static List<Vison> VISON = new List<Vison>();
        static void Main(string[] args)
        {
            Line L1 = new Line();
            L1.StrName = "直线检测1";
            L1.StrType = "直线检测";
            Line L2 = new Line();
            L2.StrName = "直线检测2";
            L2.StrType = "直线检测";
            Line L3 = new Line();
            L3.StrName = "直线检测3";
            L3.StrType = "直线检测";
            Circle C1 = new Circle();
            C1.StrName = "圆检测1";
            C1.StrType = "圆检测";
            Circle C2 = new Circle();
            C2.StrName = "圆检测2";
            C2.StrType = "圆检测";
            Circle C3 = new Circle();
            C3.StrName = "圆检测3";
            C3.StrType = "圆检测";
            VISON.Add(L1);
            VISON.Add(L2);
            VISON.Add(L3);
            VISON.Add(C1);
            VISON.Add(C2);
            VISON.Add(C3);
            foreach (var r in VISON)
            {
                if(r is Line L)
                {
                    L.Run();
                }
                if(r is Circle C)
                {
                    C.Run();
                }
            }
            foreach (var item in Poi)
            {
                Console.WriteLine($"检测点名称：{item.Name}      检测值:{item.Value}");
            }
            Console.Read();

        }
        public abstract class Vison
        {
            public abstract String StrName
            {
                get;
                set;
            }

            public abstract String StrType
            {
                get;
                set;
            }

            public abstract void Run();

        }
        public class Line : Vison
        {
            String strName;

            public override String StrName
            {
                get { return strName; }
                set { strName = value; }
            }
            String strType;

            public override String StrType
            {
                get { return strType; }
                set { strType = value; }
            }


            public override void Run()
            {
                Console.WriteLine($"步骤类型{strType}步骤名{strName}");
                Point a = new Point();
                a.Name = $"{strName}起点";
                Random rd = new Random();
                a.Value = rd.Next(1, 10).ToString();
                Point b = new Point();
                b.Name = $"{strName}终点";
                b.Value = rd.Next(1, 10).ToString();
                Poi.Add(a);
                Poi.Add(b);
            }
        }
        public class Circle : Vison
        {
            String strName;

            public override String StrName
            {
                get { return strName; }
                set { strName = value; }
            }
            String strType;

            public override String StrType
            {
                get { return strType; }
                set { strType = value; }
            }


            public override void Run()
            {
                Console.WriteLine($"步骤类型{strType}步骤名{strName}");
                Point a = new Point();
                a.Name = strName;
                Random rd = new Random();
                a.Value = rd.Next(1, 10).ToString();
                Poi.Add(a);

            }
        }
        public struct Point
        {
            public string Name;
            public string Value;
        }

    }
}