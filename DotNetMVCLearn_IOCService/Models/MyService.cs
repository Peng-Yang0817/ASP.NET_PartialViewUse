using DotNetMVCLearn_IOCService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_IOCService.Models
{
    public class MyService : IMyService
    {
        public IMyAnotherService _myAnotherService { get; set; }

        public MyService(IMyAnotherService myAnotherService)
        {
            _myAnotherService = myAnotherService;
            myAnotherService.DoAnotherSomething();
        }

        public void DoSomething()
        {
            Console.WriteLine("MyService is working...");
        }
    }
}
