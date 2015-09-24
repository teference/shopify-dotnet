#region Copyright Teference
// ************************************************************************************
// <copyright file="ShopifyWebhook.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api
{
    #region Namespace

    using System;
    using System.Text;
    using System.Globalization;
    using Newtonsoft.Json;
    using Teference.Shopify.Api.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Teference.Shopify.Api.Models.Internals;

    #endregion

    internal sealed class ShopifyWebhook : IShopifyWebhook
    {
        private readonly IShopifyClient client;

        public ShopifyWebhook(IShopifyClient client)
        {
            this.client = client;
        }

        public async Task<IList<Webhook>> GetAllAsync(
            string address = "",
            DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime),
            WebhookField fields = WebhookField.None,
            int limit = 50,
            int page = 1,
            int idGreaterThan = 0,
            WebhookTopic topic = WebhookTopic.None,
            DateTime updatedBefore = default(DateTime),
            DateTime updatedAfter = default(DateTime))
        {
            this.client.Configuration.SingleShopContract();
            return await this.GetAllAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, address, createdBefore, createdAfter, fields, limit, page, idGreaterThan, topic, updatedBefore, updatedAfter);
        }

        public async Task<IList<Webhook>> GetAllAsync(
            string shopUrl,
            string accessToken,
            string address = "",
            DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime),
            WebhookField fields = WebhookField.None,
            int limit = 50,
            int page = 1,
            int idGreaterThan = 0,
            WebhookTopic topic = WebhookTopic.None,
            DateTime updatedBefore = default(DateTime),
            DateTime updatedAfter = default(DateTime))
        {
            //// Default contracts
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            //// Optional parameter validation
            if (!string.IsNullOrWhiteSpace(address) && !address.IsValidUrlAddress())
            {
                throw new ArgumentException("Address parameter is not a well formed URL");
            }

            if (250 < limit)
            {
                throw new ArgumentException("Limit value cannot be more than 250, default is 50 if not specified");
            }

            if (0 == page)
            {
                throw new ArgumentException("Page value cannot be zero");
            }

            //// Build query string
            var queryStringBuilder = new QueryStringBuilder();
            if (!string.IsNullOrWhiteSpace(address))
            {
                queryStringBuilder.Add("address", address);
            }

            if (default(DateTime) != createdBefore)
            {
                queryStringBuilder.Add("created_at_max", createdBefore.ToString("yyyy-MM-dd HH:mm"));
            }

            if (default(DateTime) != createdAfter)
            {
                queryStringBuilder.Add("created_at_min", createdAfter.ToString("yyyy-MM-dd HH:mm"));
            }

            if (WebhookField.None != fields)
            {
                queryStringBuilder.Add("fields", fields.BuildWebhookFieldFilter());
            }

            if (0 != limit)
            {
                queryStringBuilder.Add("limit", limit.ToString(CultureInfo.InvariantCulture));
            }

            if (0 != page)
            {
                queryStringBuilder.Add("page", page.ToString(CultureInfo.InvariantCulture));
            }

            if (0 != idGreaterThan)
            {
                queryStringBuilder.Add("since_id", idGreaterThan.ToString(CultureInfo.InvariantCulture));
            }

            if (WebhookTopic.None != topic)
            {
                queryStringBuilder.Add("topic", topic.Convert());
            }

            if (default(DateTime) != updatedBefore)
            {
                queryStringBuilder.Add("updated_at_min", updatedBefore.ToString("yyyy-MM-dd HH:mm"));
            }

            if (default(DateTime) != updatedAfter)
            {
                queryStringBuilder.Add("updated_at_max", updatedAfter.ToString("yyyy-MM-dd HH:mm"));
            }

            //// Perform HTTP GET call to API
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", ApiRequestResources.GetWebhooksAll, string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhooks = JsonConvert.DeserializeObject<WebhooksJson>(rawResponseContent);
                return webhooks.Hooks;
            }
        }

        public async Task<Webhook> GetSingleAsync(string id, WebhookField fields = WebhookField.None)
        {
            this.client.Configuration.SingleShopContract();
            return await this.GetSingleAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, id, fields);
        }

        public async Task<Webhook> GetSingleAsync(string shopUrl, string accessToken, string id, WebhookField fields = WebhookField.None)
        {
            //// Default contracts
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            //// Build query string
            var queryStringBuilder = new QueryStringBuilder();
            if (WebhookField.None != fields)
            {
                queryStringBuilder.Add("fields", fields.BuildWebhookFieldFilter());
            }

            //// Perform HTTP GET call to API
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", string.Format(CultureInfo.InvariantCulture, ApiRequestResources.GetWebhookSingle, id), string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhookJson = JsonConvert.DeserializeObject<WebhookJson>(rawResponseContent);
                return webhookJson.Webhook;
            }
        }

        public async Task<int> CountAsync(string address = "", WebhookTopic topic = WebhookTopic.None)
        {
            this.client.Configuration.SingleShopContract();
            return await this.CountAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, address, topic);
        }

        public async Task<int> CountAsync(string shopUrl, string accessToken, string address = "", WebhookTopic topic = WebhookTopic.None)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            if (!string.IsNullOrWhiteSpace(address) && !address.IsValidUrlAddress())
            {
                throw new ArgumentException("Address parameter is not a well formed URL");
            }

            var queryStringBuilder = new QueryStringBuilder();
            if (!string.IsNullOrWhiteSpace(address))
            {
                queryStringBuilder.Add("address", address);
            }

            if (WebhookTopic.None != topic)
            {
                queryStringBuilder.Add("topic", topic.Convert());
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", ApiRequestResources.GetWebhooksAllCount, string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var webhooksCount = JsonConvert.DeserializeObject<WebhooksCountJson>(rawResponseContent);
                return webhooksCount.Count;
            }
        }

        public async Task<Webhook> CreateAsync(string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json)
        {
            this.client.Configuration.SingleShopContract();
            return await this.CreateAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, address, topic, format);
        }

        public async Task<Webhook> CreateAsync(string shopUrl, string accessToken, string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

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

        public async Task<Webhook> UpdateAsync(string id, string address)
        {
            this.client.Configuration.SingleShopContract();
            return await this.UpdateAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, id, address);
        }

        public async Task<Webhook> UpdateAsync(string shopUrl, string accessToken, string id, string address)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var webhookCreate = new WebhookUpdateWrapJson
                {
                    Webhook = new WebhookUpdateJson
                    {
                        Id = id,
                        Address = address
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

        public async Task<bool> DeleteAsync(string id)
        {
            this.client.Configuration.SingleShopContract();
            return await this.DeleteAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, id);
        }

        public async Task<bool> DeleteAsync(string shopUrl, string accessToken, string id)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.DeleteWebhook, id));
                return response.IsSuccessStatusCode;
            }
        }
    }
}