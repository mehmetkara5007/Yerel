using System;

namespace Yerel.Core.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class ValidationCoreException : NotificationException
    {
        public ValidationCoreException(string mesaj)
            : base(mesaj)
        {

        }

        public ValidationCoreException(string mesaj, Exception hata)
            : base(mesaj, hata)
        {

        }
    }
}