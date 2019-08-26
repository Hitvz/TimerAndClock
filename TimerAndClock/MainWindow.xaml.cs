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
using System.Windows.Threading;

namespace TimerAndClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer dTimer;

        private double preWidth;

        private double preHeight;

        private double preTop;

        private double preLeft;

        private Key preKey;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void App_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            resizeText();
        }

        private void App_Loaded(object sender, RoutedEventArgs e)
        {

            //设置定时器
            dTimer = new DispatcherTimer();
            dTimer.Interval = new TimeSpan(10000000);   //时间间隔为一秒
            dTimer.Tick += new EventHandler(timer_Tick);//Tick是超过计时间隔发生的事件——即超过1秒触发事件Timer_Tick
            dTimer.Start();//计时器开始

        }

        private void timer_Tick(object sender, EventArgs e)
        {

            timer.Text = DateTime.Now.ToShortTimeString() ;
            //Console.WriteLine(DateTime.Now.ToLongTimeString());
            
        }

        private void App_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            

            if(e.Key == Key.F11)
            {
                if (preKey!=Key.F11)
                {
                    preHeight = app.Height;
                    preWidth = app.Width;
                    preTop = this.Top;
                    preLeft = this.Left;
                }

                preKey = e.Key;

                // 设置全屏  
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.None;
                this.ResizeMode = ResizeMode.NoResize;
                this.Topmost = true;

                this.Left = 0.0;
                this.Top = 0.0;
                this.Width = SystemParameters.PrimaryScreenWidth;
                this.Height = SystemParameters.PrimaryScreenHeight;

            }else if(e.Key == Key.Escape)
            {
                preKey = e.Key;
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.ResizeMode = ResizeMode.CanResize;
                this.Width = preWidth;
                this.Height = preHeight;
                this.Top = preTop;
                this.Left = preLeft;
            }
            resizeText();
        }

        private void resizeText()
        {
            timeCanvas.Width = app.ActualWidth;

            timeCanvas.Height = app.ActualHeight;

            Canvas.SetTop(timer, timeCanvas.Height / 2.0 - timer.ActualHeight / 2.0 - SystemParameters.CaptionHeight + 2);

            Canvas.SetLeft(timer, timeCanvas.Width / 2 - timer.ActualWidth / 2.0 - 7.5);

            Console.WriteLine(timer.ActualHeight);

            Console.WriteLine(timer.FontSize);

            Console.WriteLine("timer.FontSize:" + timer.FontSize + "timer.ActualHeight:" + timer.ActualHeight + "timer.ActualWidth:" + timer.ActualWidth);

            Console.WriteLine("timer.FontSize:" + timer.FontSize + "timeCanvas.Height:" + timeCanvas.Height + "timeCanvas.Width:" + timeCanvas.Width);


            double baseWidth = timeCanvas.Width / 0.97 / 8 * 4;

            Console.WriteLine("timer.FontSize:" + timer.FontSize + "Height--:" + timeCanvas.Height + "Width--:" + baseWidth);

            double baseSize = baseWidth;

            if (timeCanvas.Height > baseWidth)
            {
                Console.WriteLine("width");
            }
            else
            {
                Console.WriteLine("height");
                baseSize = timeCanvas.Height;
            }
            timer.FontSize = baseSize * 3 / 4 - 6;
        }

        private void Timer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.SetTop(timer, timeCanvas.Height / 2.0 - timer.ActualHeight / 2.0 - SystemParameters.CaptionHeight + 2);
            Canvas.SetLeft(timer, timeCanvas.Width / 2 - timer.ActualWidth / 2.0 - 7.5);
        }

     
    }
}
