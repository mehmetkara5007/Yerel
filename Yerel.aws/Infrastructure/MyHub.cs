using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Yerel.Entities;

namespace Yerel.aws.Infrastructure
{
    //[HubName("myHub")]
    public class MyHub : Hub
    {

        private Queue<DataTemp> q = new Queue<DataTemp>();
        private static readonly List<DataTemp> OnlineProducts = new List<DataTemp>();


        public MyHub()
        {
        }

        public void Put(DataTemp apiData)
        {
            OnlineProducts.Add(apiData);
        }

        public List<DataTemp> GetOnlineProduct()
        {
            return OnlineProducts;
        }

        public void DuyuruPaylas(string baslik, string icerik)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

            context.Clients.All.duyuruHandle(baslik, icerik);
        }

        public void SonIslemler()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

            context.Clients.All.duyuruHandle();
        }

        public void OnlineProductEkle(DataTemp Product, ActionMethod method)
        {
            if (method == ActionMethod.Put)
            {
                OnlineProducts.Add(Product);
            }
            else
            {
                OnlineProducts.Remove(Product);
            }
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.newUser();
        }

        public enum ActionMethod
        {
            Put,
            Delete
        }
    }
}