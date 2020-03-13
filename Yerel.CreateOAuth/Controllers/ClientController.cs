using System.Collections.Generic;
using System.Web.Http;

namespace Yerel.CreateOAuth.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        [Authorize]
        public List<string> List()
        {
            List<string> orders = new List<string>();

            orders.Add("Data1");
            orders.Add("Data2");
            orders.Add("Data3");
            orders.Add("Data4");

            return orders;
        }
    }
}