using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 钩子委托
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        internal delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// 鼠标钩子委托
        /// </summary>
        internal HookProc MouseProc;
        /// <summary>
        /// 键盘钩子委托
        /// </summary>
        internal HookProc KeyBoardProc;
        /// <summary>
        /// 鼠标钩子
        /// </summary>
        private IntPtr m_hMouse;
      /// <summary>
      /// 键盘钩子
      /// </summary>
        private IntPtr m_hKeyBoard;

        //安装钩子
        [DllImport("User32.dll")]
        internal static extern IntPtr SetWindowsHookEx(int idHook, [MarshalAs(UnmanagedType.FunctionPtr)]HookProc Ipfn, IntPtr hanstance, int threadID);
        [DllImport("User32.dll")]
        //鼠标钩子
        internal static extern IntPtr CallNextHookEx(IntPtr handle, int code, IntPtr wparam, IntPtr Iparam);
       
       
     
        //获取当前线程编号
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();
        //卸载钩子
        [DllImport("User32.dll")]
        internal static extern void UnhookWindowsHookEx(IntPtr handle);
        public Form1()
        {
            InitializeComponent();
        }
        int a = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyBoardProc = (ncode, wparm, lparm) =>
            {
                a++;
                label1.Text = a.ToString();
                return CallNextHookEx(m_hKeyBoard, ncode, wparm, lparm);
            };
            MouseProc = (ncode, wparm, lparm) =>
            {
                a++;
                label1.Text = a.ToString();
                return CallNextHookEx(m_hMouse, ncode, wparm, lparm);
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(m_hKeyBoard);
               m_hMouse = SetWindowsHookEx(7, MouseProc, IntPtr.Zero, GetCurrentThreadId());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(m_hMouse);
            m_hKeyBoard = SetWindowsHookEx(2, KeyBoardProc, IntPtr.Zero, GetCurrentThreadId());
        }
    }
}
