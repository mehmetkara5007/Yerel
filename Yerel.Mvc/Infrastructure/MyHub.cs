using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Yerel.Entities;

namespace Yerel.Mvc.Infrastructure
{
    //[HubName("myHub")]
    public class MyHub : Hub
    {

        private Queue<Product> q = new Queue<Product>();
        private static readonly List<Product> OnlineProducts = new List<Product>();


        public MyHub()
        {
        }

        public void Put(Product apiData)
        {
            OnlineProducts.Add(apiData);
        }

        public List<Product> GetOnlineProduct()
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

        public void OnlineProductEkle(Product Product, ActionMethod method)
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