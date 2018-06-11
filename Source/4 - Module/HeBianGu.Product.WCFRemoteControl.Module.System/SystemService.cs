using HeBianGu.Product.WCFRemote.General.WindowService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.WCFRemoteControl.Module.System
{
    public class SystemService
    {
        /// <summary> 执行Cmd命令 </summary>
        public void DoCommand(string cmd)
        {
            CommandService.Instance.RunCmd(cmd);
        }

        /// <summary> 执行Process </summary>
        public void DoProcess(string cmd)
        {
            Process.Start(cmd);
        }

        /// <summary> 执行浏览进程 </summary>
        public void DoExplore(string cmd)
        {
            Process.Start("explorer.exe",cmd);
        }
    }
}
