﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_IOCService.IServices
{
    public interface IServiceB
    {
        string serviceName { get; set; }

        void ShowB();

        string GetServiceName();
    }
}