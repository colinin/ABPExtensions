#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure
     * 文 件 名：       Class1
     * 创建时间：       2018/9/11 17:11:36
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Modules;
using Abp.Exceptionless.Configuration;
using Abp.Exceptionless.Startup;
using Exceptionless;
using Exceptionless.Plugins.Default;
using System;
using System.Reflection;

namespace Abp.Exceptionless
{
    public class ExceptionlessModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IInfrastructureConfiguration, InfrastructureConfiguration>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void PostInitialize()
        {
            ExceptionlessConfig.EnabledException = Configuration.Modules.Exceptionless().EnabledExceptionless;
            ExceptionlessClient.Default.Configuration.ApiKey = Configuration.Modules.Exceptionless().ExceptionlessKey;
            ExceptionlessClient.Default.Configuration.ServerUrl = Configuration.Modules.Exceptionless().ExceptionlessUrl;
            ExceptionlessClient.Default.Configuration.IncludeIpAddress = true;
            ExceptionlessClient.Default.Configuration.IncludeMachineName = true;
            ExceptionlessClient.Default.Configuration.AddPlugin<SetEnvironmentUserPlugin>();
            ExceptionlessClient.Default.SubmittingEvent += OnSubmittingEvent;
            ExceptionlessClient.Default.Startup();
        }
        public override void Shutdown()
        {
            ExceptionlessClient.Default.SubmittingEvent -= OnSubmittingEvent;
            ExceptionlessClient.Default.Shutdown();
        }

        private void OnSubmittingEvent(object sender, EventSubmittingEventArgs e)
        {
            if (!e.IsUnhandledError)
            {
                return;
            }
            e.Event.SetReferenceId(Guid.NewGuid().ToString("N"));
            e.Event.MarkAsCritical();
        }
    }
}
