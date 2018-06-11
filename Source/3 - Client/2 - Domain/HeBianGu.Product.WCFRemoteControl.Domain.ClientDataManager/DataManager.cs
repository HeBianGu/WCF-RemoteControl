using HeBianGu.Product.WCFRemote.General.WindowService;
using HeBianGu.Product.WCFRemoteControl.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HeBianGu.Product.WCFRemoteControl.Domain.ClientDataManager
{
    public class DataManager
    {
        public static DataManager Instance = new DataManager();

        ImageClient _imageClient;

        ImageConvertService _imageConvertService = new ImageConvertService();

        SystemClient _systemClient;

        public void LoginService(string ip, string port)
        {
            _imageClient = new ImageClient(ip, port);

            _systemClient = new SystemClient(ip, port);
        }

        public async Task<Bitmap> GetScreenToBitmap()
        {
            var result = await Task.Run(() => _imageClient.GetPrintScreen());

            return result;
        }

        public ImageSource GetScreenToImageSource()
        {
            if (_imageClient == null)
            {
                throw new Exception("未连接到服务！请先连接服务再重试");
            }
            var bitmap = _imageClient.GetPrintScreen();

            if (bitmap == null) return null;

            return _imageConvertService.ChangeBitmapToImageSource(bitmap);
        }


        public byte[] GetScreenToDatas()
        {
            if (_imageClient == null)
            {
                throw new Exception("未连接到服务！请先连接服务再重试");
            }
            return _imageClient.GetPrintScreenDatas();
        }

        public void DoCommand(string cmd)
        {
            _systemClient.DoCommand(cmd);
        }

        public void DoExplore(string cmd)
        {
            _systemClient.DoExplore(cmd);
        }

        public void DoProcess(string cmd)
        {
            _systemClient.DoProcess(cmd);
        }
    }
}
