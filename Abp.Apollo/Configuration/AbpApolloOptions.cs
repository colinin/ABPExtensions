#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Configuration
     * 文 件 名：       AbpApolloOptions
     * 创建时间：       2018/9/13 17:26:42
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion


using Abp.Apollo.Configuration.Startup;
using Com.Ctrip.Framework.Apollo.Core;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Abp.Apollo.Configuration
{
    public class AbpApolloOptions
    {
        public string AbpApolloJsonFile { get; set; } = @"Configs\AppSettings.json";
        public string AbpApolloJsonRoot { get; set; } = "Apollo";
        public List<string> Namespances { get; set; } = new List<string>();
        public bool AddInMemory { get; set; }
        public IEnumerable<KeyValuePair<string, string>> InitialData { get; set; } = new Dictionary<string, string>();
        public IConfiguration Configuration { get; set; }
        public AbpApolloOptions()
        {

        }
    }
}
