﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Esd.EnergyPec.Service
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new VerCheckService() 
            };
            ServiceBase.Run(ServicesToRun);

            //            VerCheckService service = new VerCheckService();
            //#if DEBUG
            //            service.DebugRun();
            //#else
            //                                                ServiceBase.Run(service);
            //#endif
        }
    }
}
