using System;
using System.Configuration;
using System.ServiceModel;

namespace Yerel.Core.Infrastructure
{
    public class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            string serviceBaseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = String.Format(serviceBaseAddress, typeof (T).Name.Substring(1));

            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
