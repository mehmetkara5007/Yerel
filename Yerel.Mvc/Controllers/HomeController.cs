using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yerel.Business;
using Yerel.Mvc.Infrastructure;
using Yerel.Mvc.Models;

namespace Yerel.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IStockService _stockService;

        public HomeController( IProductService productService, IStockService stockService)
        {
            _productService = productService;
            _stockService = stockService;
        }
        public ActionResult Index()
        {
            var model = new ProductListVM
            {
                Urunler = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}