using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shopify.MvcTest
{
    using Jsinh.Shopify.Api;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IShopifyOAuth ShopifyAuthentication;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ShopifyAuthentication = new ShopifyOAuth();
        }
    }
}
