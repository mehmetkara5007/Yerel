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
            //var client = new RestClient("http://localhost:44387/api/Client/List");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Authorization", "Bearer Chol0uVPO3qdJbOJM3A5yMdY6iLsNPuD49zG441s6NksYKLWX1u9ER_OFRMjoXr6dxq60-WQlevquB8G5PdmGkemLpPDb1gAiEe2YHro0ZSlWopZLNuYw4sxIPPe_1WDhhJi0UMfWrpIuOLL0jvdcQaSIRt0K6Nbfh1g4-c2byg8nVmetxVNqN5eGMQilkq5HFJskwBBTFRI0AxP2v4Or6ktuay-ySYdPHNclhrCmJY");
            //IRestResponse response = client.Execute(request);
            //var result = response.Content;
            //Console.WriteLine(result);
            //Console.ReadLine();

            var client = new RestClient("http://vismaauthentication-test.eu-north-1.elasticbeanstalk.com//token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=Visma&password=123123", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = response.Content;


            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
