namespace Shopify.Api
{
    #region Namespace

    using Shopify.Api.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    public interface IShopifyClient
    {
        IShopifyWebhook Webhooks { get; }
    }
}