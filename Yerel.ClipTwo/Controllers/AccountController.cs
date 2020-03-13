using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yerel.ClipTwo.Infrastructure;
using Yerel.ClipTwo.Models;
using Yerel.Entities;

namespace Yerel.ClipTwo.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            var model = new AccountLoginViewModel
            {
                Token = "",
                User = new User()

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            if (user.Name == "Visma" & user.Password == "123123")
            {
                var client = new RestClient("http://vismaauthentication-test.eu-north-1.elasticbeanstalk.com/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("accept", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=Visma&password=123123", ParameterType.RequestBody);
                var response = client.Execute<DeserializeEntity>(request);
                var token = JsonConvert.DeserializeObject<DeserializeEntity>(response.Data.ToString());

                client = new RestClient("http://vismaauthentication-test.eu-north-1.elasticbeanstalk.com/api/Client/List");
                request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

           
              request.AddHeader("Authorization", "Bearer {0}" + token);
               

                var dataList = client.Execute(request);



                return string.IsNullOrEmpty(returnUrl)
                    ? RedirectToAction("Index", "Dashboard")
                    : (ActionResult)Redirect(returnUrl);
            }
            else
            {
                DangerNotification("Sistemde böyle bir kullanıcı adı veya şifre bulunamamıştır");
            }

            var model = new AccountLoginViewModel
            {
                Token = ""
            };

            return View(model);
        }
    }
}