namespace Shopify.Api.Contracts
{
    #region Namespace

    using Shopify.Api.Models;
    using System.Collections.Generic;

    #endregion

    public interface IShopifyWebhook
    {
        IList<Webhook> All();
    }
}