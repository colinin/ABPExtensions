#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Configuration
     * 文 件 名：       AbpApolloConfiguration
     * 创建时间：       2018/9/13 17:28:43
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Apollo;
using Abp.Apollo.Configuration.Startup;
using Abp.Dependency;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Abp.Apollo.Configuration
{
    public class AbpApolloConfiguration : IAbpApolloConfiguration
    {
        public IIocManager IocManager { get; set; }
        public IConfiguration Configuration { get; private set; }
        public AbpApolloConfiguration(IIocManager iocManager,
            AbpApolloOptions apolloOptions)
        {
            IocManager = iocManager;
            InitilizeAbpApollo(apolloOptions);
        }
        private void InitilizeAbpApollo(AbpApolloOptions apolloOptions)
        {
            var builder = new ConfigurationBuilder();
            var configurations = new List<IConfiguration>();
            var apolloBuilder = builder
                .AddJsonFile(apolloOptions.AbpApolloJsonFile)
                .AddApollo(builder.Build().GetSection(apolloOptions.AbpApolloJsonRoot))
                .AddNamespace(ApolloConsts.DEFAULT_NAMESPACE, this)
                ;
            if (apolloOptions.AddInMemory)
            {
                if (apolloOptions.InitialData.Count() > 0)
                {
                    apolloBuilder.AddInMemoryCollection(apolloOptions.InitialData);
                }
                else
                {
                    apolloBuilder.AddInMemoryCollection();
                }
            }

            if (apolloOptions.Configuration != null)
            {
                apolloBuilder.AddConfiguration(apolloOptions.Configuration);
            }

            foreach (var namespance in apolloOptions.Namespances)
            {
                apolloBuilder.AddNamespace(namespance, this);
            }

            Configuration = apolloBuilder.Build();
        }
    }
}
