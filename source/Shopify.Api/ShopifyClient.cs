namespace Shopify.Api
{
    public sealed class ShopifyClient : IShopifyClient
    {
        public ShopifyClient()
        {
            this.Webhooks = new ShopifyWebhook();
            this.ScriptTag = new ShopifyScriptTag();
        }

        public IShopifyWebhook Webhooks { get; }
        public IShopifyScriptTag ScriptTag { get; }
    }
}