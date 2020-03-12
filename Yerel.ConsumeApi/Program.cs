using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yerel.ConsumeApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new RestClient("http://localhost:44380/api/Orders/List");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Authorization", "Bearer Px1UWgNvMtivdhvEjGHl9sVsdNqljNR0Y1untRFL-xiGrRKjFP8zPLnhcYibLkLMfODBc1RCFegv4ginq3dEsFOZ6Ac0LQ20DKXTae_O2wi-9g9yaoAbzZv9ZqOQpCOLhVLFu3oApe8Vv2eyG7WA247460EMUkf2ny0VIHBpsFTq8ohBE_dsFCdjKR4UtrzH1Ua_hql25TI4y0Uu3q3DPkoLrcBw0ai4uXbMvdytRBA");
            //IRestResponse response = client.Execute(request);
            //var result = response.Content;


            //Console.WriteLine(result);
            //Console.ReadLine();

            var client = new RestClient("http://localhost:44380/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=Gokhan&password=123456", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = response.Content;


            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
