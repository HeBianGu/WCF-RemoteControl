using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemoteControl.Domain.ClientDataManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeBianGu.Product.WCFRemoteControl.Module.ScreenClient
{
    /// <summary>
    /// ScreenUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenUserControl : UserControl
    {
        public ScreenUserControl()
        {
            InitializeComponent();

            this.Loaded += ScreenUserControl_Loaded;

        }

        private void ScreenUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataManager.Instance.LoginService("192.168.1.3", WcfRegisterConfiger.Instance.Port);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        Timer timer = new Timer();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //timer.Elapsed += Timer_Elapsed;
            //timer.Interval = 500;
            //timer.Start();

            this.StartMonitor();

        }
        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        Stack<byte[]> _stack = new Stack<byte[]>();

        object _locker = new object();

        public void StartMonitor()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    //System.Threading.Thread.Sleep(10);

                    var bitmap = DataManager.Instance.GetScreenToDatas();

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        MemoryStream stream = new MemoryStream(bitmap);

                        BitmapFrame bitmapframe = imageSourceConverter.ConvertFrom(stream) as BitmapFrame;

                        if (bitmapframe != null)
                        {
                            this.image.Source = bitmapframe;

                        }

                    });

                    Debug.WriteLine("刷新成功！" + DateTime.Now.ToString());
                }
            });
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            var bitmap = DataManager.Instance.GetScreenToDatas();

            _stack.Push(bitmap);

            Application.Current.Dispatcher.Invoke(() =>
                      {

                          MemoryStream stream = new MemoryStream(bitmap);

                          BitmapFrame bitmapframe = imageSourceConverter.ConvertFrom(stream) as BitmapFrame;

                          if (bitmapframe != null)
                          {
                              this.image.Source = bitmapframe;

                          }



                      });

            Debug.WriteLine("刷新成功！" + DateTime.Now.ToString());



        }
    }
}
