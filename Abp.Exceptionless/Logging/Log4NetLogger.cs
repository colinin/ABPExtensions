#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Colin.U8API.Infrastructure.Logging
     * 文 件 名：       Log4NetLogger
     * 创建时间：       2018/9/11 17:31:24
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Exceptionless.Configuration;
using Exceptionless.Logging;
using log4net;
using log4net.Core;
using log4net.Util;
using System;
using System.Globalization;
using ILogger = Castle.Core.Logging.ILogger;

namespace Abp.Exceptionless.Logging
{
    [Serializable]
    public class Log4NetLogger :
        MarshalByRefObject,
        ILogger
    {
        private static readonly Type DeclaringType = typeof(Log4NetLogger);

        public Log4NetLogger(log4net.Core.ILogger logger, Log4NetLoggerFactory factory)
        {
            Logger = logger;
            Factory = factory;
        }

        internal Log4NetLogger()
        {
        }

        internal Log4NetLogger(ILog log, Log4NetLoggerFactory factory)
            : this(log.Logger, factory)
        {
        }
        public bool IsSubmitEnabled
        {
            get { return ExceptionlessConfig.EnabledException; }
        }
        public bool IsDebugEnabled
        {
            get { return Logger.IsEnabledFor(Level.Debug); }
        }

        public bool IsErrorEnabled
        {
            get { return Logger.IsEnabledFor(Level.Error); }
        }

        public bool IsFatalEnabled
        {
            get { return Logger.IsEnabledFor(Level.Fatal); }
        }

        public bool IsInfoEnabled
        {
            get { return Logger.IsEnabledFor(Level.Info); }
        }

        public bool IsWarnEnabled
        {
            get { return Logger.IsEnabledFor(Level.Warn); }
        }

        protected internal Log4NetLoggerFactory Factory { get; set; }

        protected internal log4net.Core.ILogger Logger { get; set; }

        public override string ToString()
        {
            return Logger.ToString();
        }

        public virtual global::Castle.Core.Logging.ILogger CreateChildLogger(string name)
        {
            return Factory.Create(Logger.Name + "." + name);
        }

        public void Debug(string message)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, message, null, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void Debug(Func<string> messageFactory)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, messageFactory.Invoke(), null, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void Debug(string message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, message, exception, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void DebugFormat(string format, params Object[] args)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void DebugFormat(Exception exception, string format, params Object[] args)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), exception, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, new SystemStringFormat(formatProvider, format, args), null, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsDebugEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Debug, new SystemStringFormat(formatProvider, format, args), exception, LogLevel.Debug, IsSubmitEnabled);
            }
        }

        public void Error(string message)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, message, null, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void Error(Func<string> messageFactory)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, messageFactory.Invoke(), null, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void Error(string message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, message, exception, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void ErrorFormat(string format, params Object[] args)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void ErrorFormat(Exception exception, string format, params Object[] args)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), exception, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, new SystemStringFormat(formatProvider, format, args), null, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsErrorEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Error, new SystemStringFormat(formatProvider, format, args), exception, LogLevel.Error, IsSubmitEnabled);
            }
        }

        public void Fatal(string message)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, message, null, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void Fatal(Func<string> messageFactory)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, messageFactory.Invoke(), null, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void Fatal(string message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, message, exception, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void FatalFormat(string format, params Object[] args)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void FatalFormat(Exception exception, string format, params Object[] args)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), exception, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, new SystemStringFormat(formatProvider, format, args), null, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsFatalEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Fatal, new SystemStringFormat(formatProvider, format, args), exception, LogLevel.Fatal, IsSubmitEnabled);
            }
        }

        public void Info(string message)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, message, null, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void Info(Func<string> messageFactory)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, messageFactory.Invoke(), null, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void Info(string message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, message, exception, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void InfoFormat(string format, params Object[] args)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void InfoFormat(Exception exception, string format, params Object[] args)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), exception, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, new SystemStringFormat(formatProvider, format, args), null, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsInfoEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Info, new SystemStringFormat(formatProvider, format, args), exception, LogLevel.Info, IsSubmitEnabled);
            }
        }

        public void Warn(string message)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, message, null, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void Warn(Func<string> messageFactory)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, messageFactory.Invoke(), null, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void Warn(string message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, message, exception, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void WarnFormat(string format, params Object[] args)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void WarnFormat(Exception exception, string format, params Object[] args)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), exception, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, new SystemStringFormat(formatProvider, format, args), null, LogLevel.Warn, IsSubmitEnabled);
            }
        }

        public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params Object[] args)
        {
            if (IsWarnEnabled)
            {
                Logger.SubmitLog(DeclaringType, Level.Warn, new SystemStringFormat(formatProvider, format, args), exception, LogLevel.Warn, IsSubmitEnabled);
            }
        }
    }
}
