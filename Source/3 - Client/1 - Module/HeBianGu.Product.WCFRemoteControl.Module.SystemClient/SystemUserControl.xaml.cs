using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemoteControl.Domain.ClientDataManager;
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

namespace HeBianGu.Product.WCFRemoteControl.Module.SystemClient
{
    /// <summary>
    /// SystemUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class SystemUserControl : UserControl
    {
        public SystemUserControl()
        {
            InitializeComponent();

            this.Loaded += SystemUserControl_Loaded;
        }

        private void SystemUserControl_Loaded(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataManager.Instance.DoCommand(this.cmd.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataManager.Instance.DoExplore(this.explore.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataManager.Instance.DoProcess(this.run.Text);
        }
    }
}
