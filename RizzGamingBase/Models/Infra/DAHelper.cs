using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Infra
{
    public class DAHelper
    {
            public const string Required = "{0} 必填";
            public const string EmailAddress = "{0} 格式有誤";
            public const string StringLength = "{0} 長度不可大於 {1}";//長度不可大於 100 個字符
        public const string StringLength2 = "{0} 長度必須介於 {1} 到 {2} 個字";//長度必須介於 6 到 20 個字符之間
        public const string Compare = "{0} 與 {1} 不相同";
    }
}