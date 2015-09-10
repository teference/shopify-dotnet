namespace Shopify.Api
{
    public sealed class ShopifyClient : IShopifyClient
    {
        public ShopifyClient()
        {
            this.Webhooks = new ShopifyWebhook();
        }

        public IShopifyWebhook Webhooks { get; }
    }
}