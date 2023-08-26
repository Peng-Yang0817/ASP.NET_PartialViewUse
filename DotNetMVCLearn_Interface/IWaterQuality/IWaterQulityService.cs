using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMVCLearn_Interface.IWaterQuality
{
    /// <summary>
    /// 定義所有 WaterQuality資料庫中資料表的CRUD介面
    /// </summary>
    public class IWaterQulityService
    {
        protected DbContext Context { get; private set; }



    }
}
