#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure.Startup
     * 文 件 名：       AbpConfigurationExtensions
     * 创建时间：       2018/9/11 17:26:20
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Configuration.Startup;
using Abp.Exceptionless.Configuration;

namespace Abp.Exceptionless.Startup
{
    public static class AbpConfigurationExtensions
    {
        public static IExceptionlessConfiguration Exceptionless(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IExceptionlessConfiguration>();
        }
    }
}
