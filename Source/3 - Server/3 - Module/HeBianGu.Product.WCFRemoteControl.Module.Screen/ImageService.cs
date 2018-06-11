#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*****有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/8 15:08:57 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Product.WCFRemote.General.WindowService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Module.Screen
{
    public class ImageService
    {
        static StreamService _streamprivider = new StreamService();

        public void PrintStreenToStream()
        {
            Bitmap bitmap = SystemWindowService.Instance.GetScreem();

            //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //新建一个内存流 用于存放图片
            MemoryStream strPic = new MemoryStream();

            bitmap.Save(strPic, ImageFormat.Jpeg);

            _streamprivider.SetStream(strPic);

        }

        public bool ReadNextBuffer()
        {
            return _streamprivider.ReadNextBuffer();
        }

        public byte[] GetCurrentBuffer()
        {
            return _streamprivider.GetCurrectBuffer();
        }
    }
}
