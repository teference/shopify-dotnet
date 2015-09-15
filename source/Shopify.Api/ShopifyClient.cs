namespace Shopify.Api
{
    #region Namespace

    using System;
    using Shopify.Api.Models.Internals;

    #endregion

    public sealed class ShopifyClient : IShopifyClient
    {
        #region Constructor

        public ShopifyClient()
        {
            this.Webhooks = new ShopifyWebhook(this);
            this.ScriptTag = new ShopifyScriptTag();
        }

        public ShopifyClient(ShopifyClientConfiguration configuration)
            : this()
        {
            if (null == configuration)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(configuration.ShopDomain))
            {
                throw new ArgumentNullException("configuration.ShopDomain");
            }

            if (!configuration.ShopDomain.IsValidShopifyDomain())
            {
                throw new ArgumentException("ShopDomain property does not contain a valid shopify domain name ending with *.myshopify.com");
            }

            if (string.IsNullOrWhiteSpace(configuration.AccessToken))
            {
                throw new ArgumentNullException("configuration.AccessToken");
            }

            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public IShopifyWebhook Webhooks { get; }
        public IShopifyScriptTag ScriptTag { get; }

        public ShopifyClientConfiguration Configuration { get; set; }

        #endregion

    }
}