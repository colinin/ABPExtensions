#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       RepositoryChangeListener
     * 创建时间：       2018/9/13 18:32:25
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Configuration;
using Com.Ctrip.Framework.Apollo.Core.Utils;
using Com.Ctrip.Framework.Apollo.Internals;

namespace Abp.Apollo.Apollo
{
    public class RepositoryChangeListener : IRepositoryChangeListener
    {
        private readonly IAbpApolloConfiguration _apolloConfiguration;
        public RepositoryChangeListener(IAbpApolloConfiguration apolloConfiguration)
        {
            _apolloConfiguration = apolloConfiguration;
        }
        public void OnRepositoryChange(string namespaceName, Properties newProperties)
        {
            if (_apolloConfiguration.Configuration.GetSection(namespaceName) != null)
            {
                foreach (var property in newProperties.Source)
                {
                    _apolloConfiguration.Configuration.GetSection(namespaceName)[property.Key] = property.Value;
                }
            }
        }
    }
}
