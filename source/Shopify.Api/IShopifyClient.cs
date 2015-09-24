namespace Teference.Shopify.Api
{
    public interface IShopifyClient
    {
        #region Properties

        IShopifyWebhook Webhooks { get; }
        IShopifyScriptTag ScriptTag { get; }

        ShopifyClientConfiguration Configuration { get; set; }

        #endregion
    }
}