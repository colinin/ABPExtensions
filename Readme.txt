��������Ŀ���½��ļ���CONFIGS�����⣬������Ҳ�У�

����һ��AppSettings.json�ļ�

{��Apollo����{��AppId������ApolloAppId������MetaServer������ http��// localhost��8080 ��// mateServer}}


#���ģ��

namespace Demo.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(ExceptionlessModule))]
    public class WebAppModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabled = true;
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            //Configuration.Modules.UseAbpApollo();
            Configuration.Modules.UseAbpApollo(options =>
            {
                options.AbpApolloJsonFile = "AppSettings.json";
                options.AbpApolloJsonRoot = "Apollo";
                options.Namespances.Add("MainApplication");
                options.AddInMemory = false;
            });
            Configuration.Settings.Providers.Add<DomainAppSettingProvider>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //���÷ֲ�ʽ��־
            Configuration.Modules.Exceptionless().EnabledExceptionless = true;
            //Exceptionles��Կ
            Configuration.Modules.Exceptionless().ExceptionlessKey = "3kTYCVGsx6TDq6i8FNkV9z0MNeLf6q5OARtPjEMn";
            //Exceptionless��������ַ
            Configuration.Modules.Exceptionless().ExceptionlessUrl = "http://localhost:20000";
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}