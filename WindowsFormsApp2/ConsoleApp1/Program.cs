using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //a vc = new a();
            //vc.CurrentPage = 0;
            //Console.WriteLine(vc._currentPage);
            //Console.Read();
            b k = new b();
            AttributeCollection attributes =
           TypeDescriptor.GetProperties(k)["PhoneNumber"].Attributes;
            DisplayNameAttribute myAttribute =
    (DisplayNameAttribute)attributes[typeof(DisplayNameAttribute)];
            Console.WriteLine(myAttribute.DisplayName);
            Console.Read();


        }

    }
    class a
    {
        public int _currentPage = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (value > 0)
                {
                    _currentPage = value;
                }
                else
                {
                    _currentPage = -4;
                }
            }
        }
    }
    class b
        {
        private bool bConnect = false;
        [Category("行为特性")]
        [DefaultValue(typeof(bool), "false")]
        [Description("是否连接")]
        public bool IsConnect { get { return bConnect; } set { bConnect = value; } }
        [DisplayName("电话号码")]
        
        public string PhoneNumber { get; set; }

    }

}

