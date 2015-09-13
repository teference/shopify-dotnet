namespace Shopify.Api
{
    public interface IShopifyClient
    {
        IShopifyWebhook Webhooks { get; }
        IShopifyScriptTag ScriptTag { get; }
    }
}