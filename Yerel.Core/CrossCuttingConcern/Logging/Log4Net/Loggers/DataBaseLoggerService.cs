using log4net;

namespace Yerel.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class DataBaseLoggerService : LoggerService
    {
        public DataBaseLoggerService()
            : base(LogManager.GetLogger("DataBaseLogger"))
        {
        }
    }
}
