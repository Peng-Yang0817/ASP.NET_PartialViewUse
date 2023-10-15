using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_IOCService.IServices
{
    public interface IMyService
    {
        IMyAnotherService _myAnotherService { get; set; }
        void DoSomething();
    }
}
