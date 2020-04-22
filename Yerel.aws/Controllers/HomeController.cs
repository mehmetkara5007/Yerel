using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yerel.aws.Infrastructure;
using Yerel.aws.Models;
using Yerel.Business;

namespace Yerel.aws.Controllers
{
    public class HomeController :BaseController
    {
        private readonly IUserService _userService;
        private readonly IDataTempService _DataTempService;

        public HomeController(IUserService userService, IDataTempService dataTempService)
        {
            _userService = userService;
            _DataTempService = dataTempService;
        }
        public ActionResult Index()
        {
            var operation = new S3BucketOprations();
            var model = new BucketViewModel
            {
                Buckets = operation.ListBucket()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            var operation = new S3BucketOprations();
            operation.CreateBucket();
            return RedirectToAction("Index");
        }

        public ActionResult Accelarate()
        {
            var operation = new S3BucketOprations();
            operation.BucketAccelarate();
            return RedirectToAction("Index");
        }

        public ActionResult Versiyon()
        {
            var operation = new S3BucketOprations();
            operation.BucketVersiyon();
            return RedirectToAction("Index");
        }
    }
}