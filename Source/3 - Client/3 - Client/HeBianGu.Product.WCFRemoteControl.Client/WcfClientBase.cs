#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/8 15:32:54 
 * 文件名：Class2 
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
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Client
{
    public class WcfClientBase
    {
        private string _ip;
        /// <summary> 说明 </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _port;
        /// <summary> 说明 </summary>
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
    }
}
