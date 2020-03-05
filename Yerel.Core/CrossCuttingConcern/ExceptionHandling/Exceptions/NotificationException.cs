using System;

namespace Yerel.Core.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string mesaj):base(mesaj)
        {
            
        }

        public NotificationException(string mesaj, Exception hata) 
            : base(mesaj,hata)
        {

        }
    }
}
