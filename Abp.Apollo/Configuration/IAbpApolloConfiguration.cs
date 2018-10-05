#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Configuration
     * 文 件 名：       IAbpApolloConfiguration
     * 创建时间：       2018/9/13 17:26:21
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Dependency;
using Microsoft.Extensions.Configuration;
using System;

namespace Abp.Apollo.Configuration
{
    public interface IAbpApolloConfiguration
    {
        IIocManager IocManager { get; set; }
        IConfiguration Configuration { get;}
    }
}
