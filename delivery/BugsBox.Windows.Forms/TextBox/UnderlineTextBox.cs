using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public partial class UnderlineTextBox : System.Windows.Forms.TextBox
    {
        public UnderlineTextBox()
        {
            this.Width = 180;
            this.Top = 50;
            this.Left = 30;
            this.Height = 50;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White;

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_CTLCOLOREDIT://当开始编辑TextBox控件的绘制信息   
                    goto case WM_PAINT;
                case WM_PAINT:
                    IntPtr hDc = GetWindowDC(this.Handle);
                    if (hDc.ToInt32() != 0)
                    {

                        using (Graphics g = Graphics.FromHdc(hDc))
                        {
                            DrowButtonLines(g);
                            g.Dispose();
                        }
                    }
                    m.Result = IntPtr.Zero;
                    ReleaseDC(m.HWnd, hDc);
                    break;
            }

        }

        public void DrowButtonLines(Graphics g)
        {
            Pen p = new Pen(this.BackColor, 2);
            g.DrawRectangle(p, -1, 0, this.Width+1, this.Height+3);
            p = new Pen(Color.Gray, 1);
            g.DrawLine(p, -1, this.Height - 1, this.Width, this.Height - 1);
            p.Dispose();
        }

        public const int WM_PAINT = 0x000F;//开始编辑TextBox控件的绘制信息   
        public const int WM_CTLCOLOREDIT = 0x0133;

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);//获取整个窗口的设备场景   

        //释放由调用GetDC或者GetWindowDC函数获取的指定设备场景，它对类或私有设备场景无效   
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    }  

}
