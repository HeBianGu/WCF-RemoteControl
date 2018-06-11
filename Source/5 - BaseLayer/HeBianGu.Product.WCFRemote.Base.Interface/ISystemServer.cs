using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemote.Base.Interface
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    /// <summary> 执行程序服务 </summary>
    [ServiceContract]
    public interface ISystemServer
    {
        /// <summary> 执行Cmd命令 </summary>
        [OperationContract]
        void DoCommand(string cmd);

        /// <summary> 执行Process </summary>
        [OperationContract]
        void DoProcess(string cmd);

        /// <summary> 执行浏览进程 </summary>
        [OperationContract]
        void DoExplore(string cmd);
    }
}
