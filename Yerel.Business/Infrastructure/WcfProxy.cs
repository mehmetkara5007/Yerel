using System.ServiceModel;

namespace Yerel.Business.Infrastructure
{
    public class WcfProxy<T>
    {
        public static T Create()
        {
            var adress = new EndpointAddress("http://localhost:56688/" + typeof(T).Name.Substring(1)+".svc");
            var binding = new BasicHttpBinding();

            return ChannelFactory<T>.CreateChannel(binding, adress);
        }

    }
}
