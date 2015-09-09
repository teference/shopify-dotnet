namespace Shopify.Api
{
    #region Namespace

    using Shopify.Api.Contracts;
    using Shopify.Api.Impl;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    public sealed class ShopifyClient : IShopifyClient
    {
        public ShopifyClient()
        {
            this.Webhooks = new ShopifyWebhook();
        }

        public IShopifyWebhook Webhooks { get; private set; }
    }
}