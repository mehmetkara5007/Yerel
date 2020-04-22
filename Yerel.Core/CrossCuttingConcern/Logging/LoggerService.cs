using log4net;

namespace Yerel.Core.CrossCuttingConcern.Logging
{
    public abstract class LoggerService
    {
        private readonly ILog _log;

        protected LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }

        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _log.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _log.IsFatalEnabled; }
        }

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }
    }
}
