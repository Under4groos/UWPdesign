using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                       DWMWINDOWATTRIBUTE attribute,
                                                       ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                       uint cbAttribute);
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

 
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }
 


        public MainWindow()
        {
            InitializeComponent();
            this.PreviewMouseLeftButtonDown += (o, e) =>
            {
                this.DragMove();
            };

            this.Loaded += (o, e) =>
            {
                //new WindowBlureffect(this, WindowBlureffect.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND);

                new WindowBlureffect(this, WindowBlureffect.AccentState.ACCENT_ENABLE_BLURBEHIND);


                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;

                DwmSetWindowAttribute(new System.Windows.Interop.WindowInteropHelper(this).Handle,
                     DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE,
                      ref preference,
                      sizeof(uint)
                    );
            };
        }
    }
}
