using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopify.MvcTest.Controllers
{
    using Jsinh.Shopify.Api;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect(MvcApplication.ShopifyAuthentication.GetOAuthUrl("someshop.myshopify.com", OAuthScope.read_themes | OAuthScope.write_themes | OAuthScope.write_products));
        }

        public ActionResult About()
        {
            var result = MvcApplication.ShopifyAuthentication.AuthorizeClient(Request.QueryString);
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