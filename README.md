# Abp.Apollo

在启动项目下新建文件夹Configs(随意，不创建也行)

新增一个AppSettings.json文件

{ "Apollo": { "AppId": "ApolloAppId", "MetaServer": "http://localhost:8080" //mateServer } }

在依赖模块的PreInitialize添加如下代码

[DependsOn(typeof(AbpApolloModule))]
public class DomainModule : AbpModule
{
    public override void PreInitialize()
    {
        //Configuration.Modules.UseAbpApollo();
        //Apollo配置
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
    }
}

暂时采用携程官方推荐的Microsoft.Extensions.Configuration


# Abp.Exception

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
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.Exceptionless().EnabledExceptionless = true;//启用分布式日志
            Configuration.Modules.Exceptionless().ExceptionlessKey = "3kTYCVGsx6TDq6i8FNkV9z0MNeLf6q5OARtPjEMn";//Exceptionless密钥
            Configuration.Modules.Exceptionless().ExceptionlessUrl = "http://localhost:20000";//Exceptionless服务器地址

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
