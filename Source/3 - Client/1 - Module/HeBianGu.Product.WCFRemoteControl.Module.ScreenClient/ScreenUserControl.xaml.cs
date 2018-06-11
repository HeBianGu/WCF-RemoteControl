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
                DataManager.Instance.LoginService("192.168.1.4", WcfRegisterConfiger.Instance.Port);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        Timer timer = new Timer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500;
            timer.Start();

        }
        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        object _locker = new object();
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                lock (_locker)
                {
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


              
            }
            catch (Exception ex)
            {
                timer.Stop();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
