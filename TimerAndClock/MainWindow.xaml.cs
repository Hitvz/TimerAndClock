using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TimerAndClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void App_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            timeCanvas.Width = app.ActualWidth;

            timeCanvas.Height = app.ActualHeight;
           
            Canvas.SetTop(timer, timeCanvas.Height/2.0-timer.ActualHeight/2.0 - SystemParameters.CaptionHeight+2);

            Canvas.SetLeft(timer, timeCanvas.Width/2 - timer.ActualWidth / 2.0 - 7.5);

        }
    }
}
