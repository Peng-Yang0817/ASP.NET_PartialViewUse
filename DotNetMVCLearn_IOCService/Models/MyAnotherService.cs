using DotNetMVCLearn_IOCService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_IOCService.Models
{
    public class MyAnotherService : IMyAnotherService
    {
        public void DoAnotherSomething() 
        {
            Console.WriteLine("MyAnotherSomething is working...");
        }
    }
}
