using log4net;

namespace Yerel.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class SmsLoggerService : LoggerService
    {
        public SmsLoggerService()
            : base(LogManager.GetLogger("SmsLogger"))
        {
        }
    }
}
