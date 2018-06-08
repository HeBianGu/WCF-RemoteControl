#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/6/8 15:06:15 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Product.WCFRemoteControl.Domain.DataManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Server.LibraryService
{
    public class ImageServer : IImageServer
    {
        public void PrintStreenToStream()
        {
            DataManager.Instance.ImagePrintStreenToStream();

        }

        public bool ReadNextBuffer()
        {
            return DataManager.Instance.ImageReadNextBuffer();
        }

        public byte[] GetCurrentBuffer()
        {
            return DataManager.Instance.ImageGetCurrentBuffer();
        }
    }
}
