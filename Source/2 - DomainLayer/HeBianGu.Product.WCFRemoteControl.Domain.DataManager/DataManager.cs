using HeBianGu.Product.WCFRemoteControl.Module.Screen;
using HeBianGu.Product.WCFRemoteControl.Module.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Domain.DataManager
{
    public class DataManager
    {
        public static DataManager Instance = new DataManager();

        StreamService _streamService = new StreamService();

        ImageService _imageService = new ImageService();


        SystemService _systemService = new SystemService();


        #region - StreamService -

        /// <summary> 当前读到的缓存 </summary>
        public byte[] GetCurrectBuffer()
        {
            return _streamService.GetCurrectBuffer();
        }

        public void SetStream(Stream stream)
        {
            _streamService.SetStream(stream);
        }

        /// <summary> 读取压缩后字节流一块，并提升字节流的位置 </summary>
        public bool ReadNextBuffer()
        {
            return _streamService.ReadNextBuffer();
        }

        public void PrintStreenToStream()
        {
            _streamService.PrintStreenToStream();

        }

        #endregion


        #region - ImageService -


        public void ImagePrintStreenToStream()
        {
            _imageService.PrintStreenToStream();

        }

        public bool ImageReadNextBuffer()
        {
            return _imageService.ReadNextBuffer();
        }

        public byte[] ImageGetCurrentBuffer()
        {
            return _imageService.GetCurrentBuffer();
        }

        #endregion



        #region - SystemService -

        /// <summary> 执行Cmd命令 </summary>
        public void DoCommand(string cmd)
        {
            _systemService.DoCommand(cmd);
        }

        /// <summary> 执行Process </summary>
        public void DoProcess(string cmd)
        {
            _systemService.DoProcess(cmd);
        }

        /// <summary> 执行浏览进程 </summary>
        public void DoExplore(string cmd)
        {
            _systemService.DoExplore(cmd);
        }

        #endregion


    }
}
