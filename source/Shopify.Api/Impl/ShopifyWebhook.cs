namespace Shopify.Api.Impl
{
    #region Namespace

    using Shopify.Api.Contracts;
    using Shopify.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    public sealed class ShopifyWebhook : IShopifyWebhook
    {
        public IList<Webhook> All()
        {
            return null;
        }
    }
}