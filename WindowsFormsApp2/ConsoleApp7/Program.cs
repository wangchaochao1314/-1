using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        //必须创建抽象类的实现类才能创建PIG类对象RETURN   
        static void Main(string[] args)
        {

        }
    }
    abstract class  pig
    {
        protected abstract bool ReadFunc();
        public bool a()
        {
            return ReadFunc();
        }
    }
    
}
