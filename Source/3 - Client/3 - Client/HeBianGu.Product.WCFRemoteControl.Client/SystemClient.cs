#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/11 15:13:03 
 * 文件名：SystemClient 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemote.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Client
{
   public class SystemClient : WcfClientBase
    {
        public SystemClient(string ip, string port)
        {
            this.IP = ip;
            this.Port = port;
        }
        /// <summary> 客户端的配置 </summary>
        public WcfRegisterConfiger WcfConfiger = WcfRegisterConfiger.Instance;

        private WSHttpBinding _wsHttpBinding;
        /// <summary> 说明 </summary>
        public WSHttpBinding WSHttpBinding
        {
            get
            {
                if (_wsHttpBinding == null)
                {
                    _wsHttpBinding = new WSHttpBinding();
                    _wsHttpBinding.MaxBufferPoolSize = int.MaxValue;
                    _wsHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                    _wsHttpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
                    _wsHttpBinding.Security = new System.ServiceModel.WSHttpSecurity();
                    _wsHttpBinding.Security.Mode = SecurityMode.None;
                }
                return _wsHttpBinding;
            }
        }

        /// <summary> 地址 </summary>
        public string SenderAddress
        {
            get
            {
                return string.Format(WcfRegisterConfiger.RomoteFormat, this.IP, this.Port, "SystemServer");
            }

        }

        /// <summary> 运行Cmd命令 </summary>
        public void DoCommand(string cmd)
        {
            using (ChannelFactory<ISystemServer> channelFactory = new ChannelFactory<ISystemServer>(WSHttpBinding, SenderAddress))
            {
                ISystemServer proxy = channelFactory.CreateChannel();

                proxy.DoCommand(cmd);
            }
        }

        /// <summary> 运行Cmd命令 </summary>
        public void DoExplore(string cmd)
        {
            using (ChannelFactory<ISystemServer> channelFactory = new ChannelFactory<ISystemServer>(WSHttpBinding, SenderAddress))
            {
                ISystemServer proxy = channelFactory.CreateChannel();

                proxy.DoExplore(cmd);
            }
        }

        /// <summary> 运行Cmd命令 </summary>
        public void DoProcess(string cmd)
        {
            using (ChannelFactory<ISystemServer> channelFactory = new ChannelFactory<ISystemServer>(WSHttpBinding, SenderAddress))
            {
                ISystemServer proxy = channelFactory.CreateChannel();

                proxy.DoProcess(cmd);
            }
        }
    }
}
