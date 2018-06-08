#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/6/8 17:27:59 
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HeBianGu.Product.WCFRemoteControl.Module.ScreenClient
{
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    /// <summary>  
    /// ID:为解决WPF BitmapImage图片资源无法删除，文件正在被另一个进程使用问题的方案   
    /// Describe:自定义图片，加载后释放图片资源  
    /// Author:ybx  
    /// Date:2016-12-7 17:51:33  
    /// </summary>  
    public class BxImage : Image
    {
        public new string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BxSource.  This enables animation, styling, binding, etc...  
        public new static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(BxImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(BxImage.OnSourceChanged), null), null);

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image image = (Image)d;
            if (e.NewValue == null || string.IsNullOrEmpty(e.NewValue.ToString()) || !File.Exists(e.NewValue.ToString()))
                return;
            using (BinaryReader reader = new BinaryReader(File.Open(e.NewValue.ToString(), FileMode.Open)))
            {
                try
                {
                    FileInfo fi = new FileInfo(e.NewValue.ToString());
                    byte[] bytes = reader.ReadBytes((int)fi.Length);
                    reader.Close();

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;

                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(bytes);
                    bitmapImage.EndInit();
                    image.Source = bitmapImage;
                }
                catch (Exception) { }
            }
        }
    }
}
