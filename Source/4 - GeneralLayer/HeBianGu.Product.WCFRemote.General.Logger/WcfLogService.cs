#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/7 16:14:01 
 * 文件名：WcfLogService 
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

namespace HeBianGu.Product.WCFRemote.General.Logger
{
   public  class WcfLogService
    {

        public static WcfLogService Instance = new WcfLogService();

        string formatS = "访问时间:{0} - 接口:{1}";

        string formatR = "返回时间:{0} - 结果:{1}";

        public void LogStartMethod(string methodName)
        {
            Log4Servcie.Instance.Info(string.Format(formatS, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),methodName));
        }

        public void LogResultMethod(string result)
        {
            Log4Servcie.Instance.Info(string.Format(formatR, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), result));
        }
    }
}
