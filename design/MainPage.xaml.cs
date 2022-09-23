using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace design
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar titleBar = CoreApplication.GetCurrentView().TitleBar;

            ApplicationViewTitleBar appTitleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ExtendViewIntoTitleBar = true;

            appTitleBar.BackgroundColor = Colors.Transparent;
            appTitleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            appTitleBar.BackgroundColor = Windows.UI.Colors.Transparent;

            


            var _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += (o,e) =>
            {

            };
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            _dispatcherTimer.Start();
            
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = this.MinWidth;
            this.Height = this.MinWidth;
        }
    }
}
