#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       ApolloSettingManager
     * 创建时间：       2018/9/14 16:24:03
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Configuration;
using Abp.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Abp.Apollo.Apollo
{
    public class ApolloSettingManager : IApolloSettingManager
    {
        private readonly IAbpApolloConfiguration _configuration;
        private readonly ISettingDefinitionManager _settingDefinitionManager;
        public ApolloSettingManager(IAbpApolloConfiguration configuration, 
            ISettingDefinitionManager settingDefinitionManager)
        {
            _configuration = configuration;
            _settingDefinitionManager = settingDefinitionManager;
        }
        public IReadOnlyList<ISettingValue> GetAllSettingValues(string @namespance)
        {
            return GetAllList(@namespance);
        }

        public string GetSettingValue(string @namespance, string name)
        {
            return GetSettingValueOrNull(@namespance, name).Value;
        }

        public ISettingValue GetSetting(string @namespance, string name)
        {
            return GetSettingValueOrNull(@namespance, name);
        }

        public Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(string @namespance)
        {
            return Task.FromResult(GetAllSettingValues(@namespance));
        }
        public Task<ISettingValue> GetSettingAsync(string @namespance, string name)
        {
            return Task.FromResult(GetSetting(@namespance, name));
        }
        public Task<string> GetSettingValueAsync(string @namespance, string name)
        {
            return Task.FromResult(GetSettingValue(@namespance, name));
        }
        private ISettingValue GetSettingValueOrNull(string @namespance, string name)
        {
            var configuration = _configuration.Configuration.GetSection(@namespance);
            var value = configuration?.GetValue(name, "");
            if (!string.IsNullOrWhiteSpace(value))
            {
                return new SettingValueObject(name, value);
            }
            var defaultValue = _settingDefinitionManager.GetSettingDefinition(name);
            return new SettingValueObject(defaultValue.Name, defaultValue.DefaultValue);
        }

        private IReadOnlyList<ISettingValue> GetAllList(string @namespance)
        {
            var settingDefinitions = new Dictionary<string, SettingDefinition>();
            var settingValues = new Dictionary<string, ISettingValue>();
            foreach (var setting in _settingDefinitionManager.GetAllSettingDefinitions())
            {
                settingDefinitions[setting.Name] = setting;
                settingValues[setting.Name] = new SettingValueObject(setting.Name, setting.DefaultValue);
            }

            foreach (var config in _configuration.Configuration.GetSection(@namespance)?.AsEnumerable())
            {
                if (settingValues.ContainsKey(config.Key))
                {
                    settingValues[config.Key] = new SettingValueObject(config.Key, config.Value);
                }
            }
            return settingValues.Values.ToImmutableList();
        }

        private class SettingValueObject : ISettingValue
        {
            public string Name { get; private set; }

            public string Value { get; private set; }

            public SettingValueObject(string name, string value)
            {
                Value = value;
                Name = name;
            }
        }
    }
}
