using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象类虚方法
{
    class Program
    {
        //抽象方法必须在抽象类写入
        //抽象方法不含方法体
        //抽象类的子类必须实现所有抽象方法
        //子类不重写虚方法直接则调用父类虚方法
        //抽象类可以有实例方法

        static void Main(string[] args)
        {
           // b io = new b();
           
           // Console.WriteLine(io.Add1() );
            Console.Read();
        }
        public abstract class a
        {
            int o;
            public virtual int Add1()
            {
                return 3;
            }
            public abstract int high();
            public abstract int high1();

        }
        //子类可以不实现父类的抽象方法。这样的类也要标记为抽象类
        public abstract class b:a
        {
            //非抽象类需标记方法体
            //  public virtual int Add();

            //public override int high1()
            //{
            //    return 1;
            //}

            public override int high()
            {
                return 1;
            }
            //public override int Add1()
            //{
            //   return base.Add1();
            //}
        }
    }
}
