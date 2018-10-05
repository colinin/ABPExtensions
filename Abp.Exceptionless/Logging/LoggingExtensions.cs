#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure.Logging
     * 文 件 名：       LoggingExtensions
     * 创建时间：       2018/9/11 17:34:16
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Exceptionless;
using Exceptionless.Logging;
using log4net.Core;
using System;

namespace Abp.Exceptionless.Logging
{
    public static class LoggingExtensions
    {
        public static void SubmitLog(this ILogger logger, Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception, LogLevel logLevel, bool submit = false)
        {
            logger.Log(callerStackBoundaryDeclaringType, level, message, exception);
            if (submit)
            {
                if (exception != null)
                {
                    exception.ToExceptionless()?.Submit();
                }
                else
                {
                    ExceptionlessClient.Default.CreateLog(message.ToString(), logLevel).Submit();
                }
            }
        }
    }
}
