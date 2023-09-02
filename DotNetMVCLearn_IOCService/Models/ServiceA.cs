using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMVCLearn_IOCService.IServices;

namespace DotNetMVCLearn_IOCService.Models
{
    public class ServiceA : IServiceA
    {

        public string _serviceName = "服務A";


        public string GetServiceName()
        {
            return _serviceName;
        }

        public void ShowA()
        {
            System.Console.WriteLine("已啟動服務 : {0} 。", _serviceName);
        }
    }
}
