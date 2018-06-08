using HeBianGu.Product.WCFRemoteControl.Domain.DataManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HeBianGu.Product.WCFRemoteControl.Server.LibraryService
{
    public class StreamServer: IStreamServer
    {
        /// <summary> 当前读到的缓存 </summary>
        public byte[] GetCurrectBuffer()
        {
            return DataManager.Instance.GetCurrectBuffer();
        }

        public void SetStream(Stream stream)
        {
            DataManager.Instance.SetStream(stream);
        }

        /// <summary> 读取压缩后字节流一块，并提升字节流的位置 </summary>
        public bool ReadNextBuffer()
        {
            return DataManager.Instance.ReadNextBuffer();

        }


        public void PrintStreenToStream()
        {
            DataManager.Instance.PrintStreenToStream();

        }



    }
}
