using HeBianGu.Product.WCFRemote.Base.Configer;
using HeBianGu.Product.WCFRemote.Base.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Client
{
    public partial class ImageClient : WcfClientBase
    {
        public ImageClient(string ip, string port)
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
        public string ImageSenderAddress
        {
            get
            {
                return string.Format(WcfRegisterConfiger.RomoteFormat, this.IP, this.Port, "StreamServer");
            }

        }

        /// <summary> 运行Cmd命令 </summary>
        public Bitmap GetPrintScreen()
        {
            using (ChannelFactory<IStreamServer> channelFactory = new ChannelFactory<IStreamServer>(WSHttpBinding, ImageSenderAddress))
            {
                IStreamServer proxy = channelFactory.CreateChannel();

                MemoryStream writeStream = new MemoryStream();

                proxy.PrintStreenToStream();

                byte[] buffer;

                //获取所用块压缩流，并组装
                while (proxy.ReadNextBuffer())
                {
                    // read bytes from input stream
                    buffer = proxy.GetCurrectBuffer();

                    // write bytes to output stream
                    writeStream.Write(buffer, 0, buffer.Length);
                }

                Bitmap bitmap = new Bitmap(writeStream);

                writeStream.Dispose();

                return bitmap;
            }
        }

        /// <summary> 运行Cmd命令 </summary>
        public byte[] GetPrintScreenDatas()
        {
            //List<byte> result = new List<byte>();

            using (ChannelFactory<IStreamServer> channelFactory = new ChannelFactory<IStreamServer>(WSHttpBinding, ImageSenderAddress))
            {
                IStreamServer proxy = channelFactory.CreateChannel();

                MemoryStream writeStream = new MemoryStream();

                proxy.PrintStreenToStream();

                byte[] buffer;

                //获取所用块压缩流，并组装
                while (proxy.ReadNextBuffer())
                {
                    // read bytes from input stream
                    buffer = proxy.GetCurrectBuffer();

                    // write bytes to output stream
                    writeStream.Write(buffer, 0, buffer.Length);

                    //result.AddRange(buffer);
                }

               return  writeStream.GetBuffer();

                //Bitmap bitmap = new Bitmap(writeStream);

                //writeStream.Dispose();

                //return bitmap;
            }
        }


    }
}
