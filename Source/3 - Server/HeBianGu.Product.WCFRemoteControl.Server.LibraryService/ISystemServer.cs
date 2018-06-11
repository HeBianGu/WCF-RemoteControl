#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/6/11 14:27:36 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Server.LibraryService
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
