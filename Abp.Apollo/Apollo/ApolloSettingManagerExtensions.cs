#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       SettingConfigurationExtensions
     * 创建时间：       2018/9/14 14:19:20
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion


using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Abp.Apollo.Apollo
{
    public static class ApolloSettingManagerExtensions
    {
        public static string GetSettingValue(this IApolloSettingManager settingManager, string key)
        {
            return settingManager.GetSettingValue(ApolloConsts.DEFAULT_NAMESPACE, key);
        }
        public static T GetSettingValueOfType<T>(this IApolloSettingManager settingManager, string @namespace, string key)
        {
            try
            {
                var value = settingManager.GetSettingValue(@namespace, key);
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }
            }
            catch { }
            return default(T);
        }
        public static Task<T> GetSettingValueOfTypeAsync<T>(this IApolloSettingManager settingManager, string @namespace, string key)
        {
            return Task.FromResult(settingManager.GetSettingValueOfType<T>(@namespace, key));
        }
    }
}
