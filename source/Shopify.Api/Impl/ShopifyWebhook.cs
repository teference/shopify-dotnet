namespace Shopify.Api
{
    #region Namespace

    using System.Text;
    using System.Globalization;
    using Newtonsoft.Json;
    using Shopify.Api.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Shopify.Api.Models.Internals;

    #endregion

    internal sealed class ShopifyWebhook : IShopifyWebhook
    {
        public async Task<IList<Webhook>> GetAsync(string shopUrl, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(ApiRequestResources.GetWebhooksAll);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhooks = JsonConvert.DeserializeObject<WebhooksJson>(rawResponseContent);
                return webhooks.Hooks;
            }
        }

        public async Task<Webhook> GetAsync(string shopUrl, string accessToken, string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.GetWebhookSingle, id));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhookJson = JsonConvert.DeserializeObject<WebhookJson>(rawResponseContent);
                return webhookJson.Webhook;
            }
        }

        public async Task<int> CountAsync(string shopUrl, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(ApiRequestResources.GetWebhooksAllCount);
                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhooksCount = JsonConvert.DeserializeObject<WebhooksCountJson>(rawResponseContent);
                return webhooksCount.Count;
            }
        }

        public async Task<Webhook> CreateAsync(string shopUrl, string accessToken, string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var webhookCreate = new WebhookCreateWrapJson
                {
                    Webhook = new WebhookCreateJson
                    {
                        Topic = topic.Convert(),
                        Address = address,
                        Format = format.ToString().ToLowerInvariant()
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(webhookCreate), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(ApiRequestResources.PostWebhookCreate, content);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhookJson = JsonConvert.DeserializeObject<WebhookJson>(rawResponseContent);
                return webhookJson.Webhook;
            }
        }

        public async Task<Webhook> UpdateAsync(string shopUrl, string accessToken, string id, string address)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var webhookCreate = new WebhookUpdateWrapJson
                {
                    Webhook = new WebhookUpdateJson
                    {
                        Id = id,
                        Address = address,
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(webhookCreate), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.PutWebhookUpdate, id), content);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhookJson = JsonConvert.DeserializeObject<WebhookJson>(rawResponseContent);
                return webhookJson.Webhook;
            }
        }

        public async Task<bool> DeleteAsync(string shopUrl, string accessToken, string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.DeleteWebhook, id));
                return response.IsSuccessStatusCode;
            }
        }
    }
}