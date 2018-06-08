using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemoteControl.Domain.ClientDataManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                DataManager.Instance.LoginService(WcfRegisterConfiger.Instance.IP, WcfRegisterConfiger.Instance.Port);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageSource bitmap = DataManager.Instance.GetScreenToImageSource();

                this.image.Source = bitmap;

                Debug.Write("刷新成功！" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
