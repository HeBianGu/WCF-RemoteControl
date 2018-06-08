using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemote.General.Logger;
using HeBianGu.Product.WCFRemoteControl.Domain.ServerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Host.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Todo ：初始化 
            string exeFileFullPath = Assembly.GetEntryAssembly().Location;
            string exeName = System.IO.Path.GetFileNameWithoutExtension(exeFileFullPath);
            string binPath = System.IO.Path.GetDirectoryName(exeFileFullPath);

            binPath = System.IO.Path.GetDirectoryName(binPath);

            string logFilePath = System.IO.Path.GetDirectoryName(binPath);

            //  初始化日志
            Log4Servcie.Instance.InitLogger(logFilePath, System.Diagnostics.Process.GetCurrentProcess().ProcessName);


            Log4Servcie.Instance.Info("准备启动服务！");

            Log4Servcie.Instance.Info(WcfRegisterConfiger.Instance.IP);

            Log4Servcie.Instance.Info(WcfRegisterConfiger.Instance.Port);

            try
            {
                Dictionary<Type, Type> dic = WcfServiceFactory.Instance.BuildRemoveMonitorService();



                //dic = WcfServiceFactory.Instance.BuildWorkScreamService();

                foreach (var d in dic)
                {
                    Log4Servcie.Instance.Info(d.Key.Name);
                }

                WcfRegisterService.Instance.AddService(dic);

                Log4Servcie.Instance.Info("启动成功，按任意键退出！");

            }
            catch (Exception ex)
            {
                Log4Servcie.Instance.Error(ex);
            }
            Log4Servcie.Instance.Info("按任意键退出！");
            Console.Read();
        }
    }
}
