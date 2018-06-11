#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/6/11 14:29:03 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Product.WCFRemote.Base.Interface;
using HeBianGu.Product.WCFRemoteControl.Domain.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Server.LibraryService
{
   public  class SystemServer : ISystemServer
    {
        public void DoCommand(string cmd)
        {
            DataManager.Instance.DoCommand(cmd);
        }

        public void DoExplore(string cmd)
        {
            DataManager.Instance.DoExplore(cmd);
        }

        public void DoProcess(string cmd)
        {
            DataManager.Instance.DoProcess(cmd);
        }
    }
}
