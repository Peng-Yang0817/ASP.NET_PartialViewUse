﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMVCLearn_IOCService.IServices;

using Unity;

namespace DotNetMVCLearn_IOCService.Models
{
    public class ServiceC : IServiceC
    {
        public string _serviceName { get; set; }

        /// <summary>
        /// 屬性注入
        /// 注意 : 建構式完成後才會啟用的TAG，
        ///         因此不能再建構式內馬上使用。
        /// </summary>
        private IServiceA _serviceA;

        [Dependency]
        public IServiceA serviceA
        {
            get { return _serviceA; }
            set { _serviceA = value; }
        }

        public IServiceB _serviceB { get; set; }


        public ServiceC(ServiceB serviceB)
        {
            _serviceB = serviceB;
            _serviceName = "服務C";
            Console.WriteLine("服務C中已擁有{0}",
                              _serviceB.GetServiceName());
        }


        private IServiceB _serviceBNew;
        // 下面透過方法體附值
        public IServiceB serviceBNew
        {
            get { return _serviceBNew; }
            set { _serviceBNew = value; }
        }
        // 支持方法注入
        [InjectionMethod]
        public void InitServiceB_New(IServiceB serviceB)
        {
            Console.WriteLine("開始進行方法注入");
            serviceBNew = serviceB;
            serviceBNew.serviceName = "方法體注入完成的B服務";
            Console.WriteLine("方法注入完成");
        }

        public string GetServiceName()
        {
            return _serviceName;
        }

        public void ShowC()
        {
            System.Console.WriteLine("已啟動服務 : {0} 。", _serviceName);
        }
    }
}
