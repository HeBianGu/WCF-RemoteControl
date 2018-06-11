#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/11 16:56:27 
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

namespace HeBianGu.Product.WCFRemote.Base.Interface
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    /// <summary> 执行程序服务 </summary>
    [ServiceContract]
    public interface IImageServer
    {
        [OperationContract]
        bool ReadNextBuffer();

        [OperationContract]
        byte[] GetCurrentBuffer();

        [OperationContract]
        void PrintStreenToStream();
    }
}
