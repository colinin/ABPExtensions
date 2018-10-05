#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       IAbpApolloSettingManager
     * 创建时间：       2018/9/14 16:21:25
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Apollo.Apollo
{
    /// <summary>
    /// Apollo配置接口
    /// </summary>
    public interface IApolloSettingManager
    {
        /// <summary>
        /// 获取所有配置项
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <returns></returns>
        IReadOnlyList<ISettingValue> GetAllSettingValues(string @namespance);
        /// <summary>
        /// 获取所有配置项 异步方法
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <returns></returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(string @namespance);
        /// <summary>
        /// 获取一个配置值
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        string GetSettingValue(string @namespance, string name);
        /// <summary>
        /// 获取一个配置值 异步方法
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        Task<string> GetSettingValueAsync(string @namespance, string name);
        /// <summary>
        /// 获取一个配置项
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        ISettingValue GetSetting(string @namespance, string name);
        /// <summary>
        /// 获取一个配置项 异步方法
        /// </summary>
        /// <param name="namespance">命名空间</param>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        Task<ISettingValue> GetSettingAsync(string @namespance, string name);


    }
}
