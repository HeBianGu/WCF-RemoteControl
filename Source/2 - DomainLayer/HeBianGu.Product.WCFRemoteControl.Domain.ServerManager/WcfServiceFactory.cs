using HeBianGu.Product.WCFRemoteControl.Server.LibraryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Domain.ServerManager
{
    public class WcfServiceFactory
    {
        private WcfServiceFactory()
        {

        }

        public static WcfServiceFactory Instance = new WcfServiceFactory();

        ///// <summary> 构建自动流服务 </summary>
        //public Dictionary<Type, Type> BuildWorkScreamService()
        //{
        //    Dictionary<Type, Type> serviceTypes = new Dictionary<Type, Type>();

        //    serviceTypes.Add(typeof(IFileTransferService), typeof(FileTransferService));

        //    serviceTypes.Add(typeof(IWorkScreamService), typeof(WorkScreamService));

        //    return serviceTypes;
        //}

        /// <summary> 构建远程控制器服务 </summary>
        public Dictionary<Type, Type> BuildRemoveMonitorService()
        {
            Dictionary<Type, Type> serviceTypes = new Dictionary<Type, Type>();

            //serviceTypes.Add(typeof(IExcuteService), typeof(ExcuteService));

            serviceTypes.Add(typeof(IImageServer), typeof(ImageServer));

            serviceTypes.Add(typeof(IStreamServer), typeof(StreamServer));

            serviceTypes.Add(typeof(ISystemServer), typeof(SystemServer));

            return serviceTypes;
        }


    }
}
