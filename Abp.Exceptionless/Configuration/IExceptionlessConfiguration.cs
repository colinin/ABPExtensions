#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure.Configuration
     * 文 件 名：       IInfrastructureConfiguration
     * 创建时间：       2018/9/11 17:23:26
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion


namespace Abp.Exceptionless.Configuration
{
    public interface IExceptionlessConfiguration
    {
        string ExceptionlessKey { get; set; }
        string ExceptionlessUrl { get; set; }
        bool EnabledExceptionless { get; set; }
    }
}
