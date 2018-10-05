#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure.Configuration
     * 文 件 名：       InfrastructureConfiguration
     * 创建时间：       2018/9/11 17:24:11
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion


namespace Abp.Exceptionless.Configuration
{
    public class InfrastructureConfiguration : IInfrastructureConfiguration
    {
        public string ExceptionlessKey { get; set; }
        public string ExceptionlessUrl { get; set; }
        public bool EnabledExceptionless { get; set; }
        public InfrastructureConfiguration()
        {
            EnabledExceptionless = false;
            ExceptionlessKey = "exceptionless";
            ExceptionlessUrl = "http://exceptionless.io";
        }
    }
}
