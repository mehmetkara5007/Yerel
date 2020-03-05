using log4net;

namespace Yerel.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class FileLoggerService : LoggerService
    {
        public FileLoggerService() : base(LogManager.GetLogger("FileLogger"))
        {
        }
    }
}
