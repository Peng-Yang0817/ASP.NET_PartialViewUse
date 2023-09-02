using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMVCLearn_IOCService.IServices;

namespace DotNetMVCLearn_IOCService.Models
{
    public class ServiceB : IServiceB
    {
        // 私有變量
        private string _serviceName { get; set; }
        public string serviceName
        {
            get => _serviceName;
            set => _serviceName = value;
        }

        public IServiceA? _serviceA = null;

        public ServiceB(IServiceA serviceA)
        {
            _serviceA = serviceA;
            // 預設服務名稱
            serviceName = "服務B";
            Console.WriteLine("服務B中已擁有{0}", _serviceA.GetServiceName());
        }

        public string GetServiceName()
        {
            return _serviceName;
        }

        public void ShowB()
        {
            System.Console.WriteLine("已啟動服務 : {0} 。", _serviceName);
        }
    }
}
