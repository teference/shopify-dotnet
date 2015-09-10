namespace Shopify.Api
{
    #region Namespace

    using System.Threading.Tasks;
    using Shopify.Api.Models;
    using System.Collections.Generic;

    #endregion

    public interface IShopifyWebhook
    {
        Task<IList<Webhook>> GetAsync(string shopUrl, string accessToken);
        Task<Webhook> GetAsync(string shopUrl, string accessToken, string id);
        Task<int> CountAsync(string shopUrl, string accessToken);
        Task<Webhook> CreateAsync(string shopUrl, string accessToken, string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json);
        Task<Webhook> UpdateAsync(string shopUrl, string accessToken, string id, string address);
        Task<bool> DeleteAsync(string shopUrl, string accessToken, string id);
    }
}