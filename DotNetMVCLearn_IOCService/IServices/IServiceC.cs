using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_IOCService.IServices
{
    public interface IServiceC
    {
        IServiceA serviceA { get; set; }

        IServiceB serviceBNew { get; set; }

        void ShowC();

        string GetServiceName();

        void InitServiceB_New(IServiceB serviceB);
    }
}
