using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        //接口不能包含字段
        //接口函数不能修饰符
        //接口不能实例
        //继承接口的类必须实现所有接口属性
        //修改接口类的对象和修改接口对象一样实现
        //最后指向的是最后一个借口的属性。因为借口对象在内存栈上同一地址


        static void Main(string[] args)
        {
            car aodi = people.chen;
            car benchi = people.chen;
            house tian = people.chen;
            // aodi.carName = "A8";
            // people.chen.carName = "A8";
            aodi.carName = "A8";
            benchi.carName = "G3";
            aodi.bycar();
            tian.Mai();
            Console.Read();
        }
          public interface car
        {
            string carName { get; set; }
            int Monney { get; set; }
             void bycar();
           
        }
        public interface house
        {
            string address { get; set; }
            int Monney { get; set; }
            void Mai();
        }
        class people : car, house
        {
            public static people chen = new people();
            public string carName { get ; set; }
            public int Monney { get ; set; }
            public string address { get ; set ; }

            public void bycar()
            {
                Console.WriteLine($"我坐{carName}车");
            }

            public void Mai()
            {
                Console.WriteLine("我买200万房子");
            }
        }
    }
}
