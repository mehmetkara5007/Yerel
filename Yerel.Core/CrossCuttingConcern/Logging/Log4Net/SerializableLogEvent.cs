using System;
using log4net.Core;

namespace Yerel.Core.CrossCuttingConcern.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private readonly LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        //public string Level
        //{
        //    get { return _loggingEvent.Level.DisplayName; }
        //}

        //public DateTime TimeStamp
        //{
        //    get { return _loggingEvent.TimeStamp; }
        //}

        //public string LoggerName
        //{
        //    get { return _loggingEvent.LoggerName; }
        //}

        //public string ExceptionObject
        //{
        //    get
        //    {
        //        return _loggingEvent.ExceptionObject==null ? null : _loggingEvent.ExceptionObject.ToString();
        //    }
        //}

        public string UserName
        {
            get { return _loggingEvent.UserName; }
        }

        //public string RenderedMessage
        //{
        //    get { return _loggingEvent.RenderedMessage; }
        //}

        public object MessageObject
        {
            get { return _loggingEvent.MessageObject; }
        }
    }
}