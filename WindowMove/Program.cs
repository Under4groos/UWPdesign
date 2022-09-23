using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowMove
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public override string ToString()
            {
                return $"{Left} {Top} {Right - Left} {Bottom - Top}";
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();


        [STAThread]
        static void Main(string[] args)
        {
            int margin_ = 20;
            double p = 0;
            double speed = 3;
            RECT rect_from;

            IntPtr window_h = new IntPtr(13896);

            double size_w,size_h = 0;

            while (true)
            {
                GetWindowRect(window_h, out rect_from);
                if (Keyboard.IsKeyDown(System.Windows.Input.Key.E))
                {
                    window_h = GetForegroundWindow();
                    Console.WriteLine(window_h);
                }
                if (Keyboard.IsKeyDown(System.Windows.Input.Key.Space))
                {
                    p += speed;
                    size_w = (rect_from.Right - rect_from.Left);
                    Console.WriteLine(rect_from);

                    if(rect_from.Left + size_w > 1920- margin_)
                    {
                        p = 0;
                    }
                   
                  


                }
                else
                {
                    p = 0;
                }

                if(window_h != IntPtr.Zero)
                {
                    MoveWindow(window_h, margin_ + (int)p, margin_,
                      rect_from.Right - rect_from.Left,
                      rect_from.Bottom - rect_from.Top, true);
                }
                

                Thread.Sleep(1);
               
            }
        }
    }
}
