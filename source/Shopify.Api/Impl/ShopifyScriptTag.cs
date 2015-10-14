#region Copyright Teference
// ************************************************************************************
// <copyright file="ShopifyScriptTag.cs" company="Teference">
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

    using System.Text;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Teference.Shopify.Api.Models;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Teference.Shopify.Api.Models.Internals;
    using System;

    #endregion

    internal sealed class ShopifyScriptTag : IShopifyScriptTag
    {
        private readonly IShopifyClient client;

        public ShopifyScriptTag(IShopifyClient client)
        {
            this.client = client;
        }

        public async Task<IList<ScriptTag>> GetAllAsync(
            string source = "", DateTime createdBefore = default(DateTime), DateTime createdAfter = default(DateTime),
            ScriptTagField fields = ScriptTagField.None, int limit = 50, int page = 1,
            int idGreaterThan = 0, DateTime updatedBefore = default(DateTime), DateTime updatedAfter = default(DateTime))
        {
            this.client.Configuration.SingleShopContract();
            return await this.GetAllAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, source, createdBefore, createdAfter, fields, limit, page, idGreaterThan, updatedBefore, updatedAfter);
        }

        public async Task<IList<ScriptTag>> GetAllAsync(
            string shopUrl, string accessToken, string source = "", DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime), ScriptTagField fields = ScriptTagField.None, int limit = 50, int page = 1,
            int idGreaterThan = 0, DateTime updatedBefore = default(DateTime), DateTime updatedAfter = default(DateTime))
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            //// Optional parameter validation
            if (!string.IsNullOrWhiteSpace(source) && !source.IsValidUrlAddress())
            {
                throw new ArgumentException("Source parameter is not a well formed URL");
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
            if (!string.IsNullOrWhiteSpace(source))
            {
                queryStringBuilder.Add("src", source);
            }

            if (default(DateTime) != createdBefore)
            {
                queryStringBuilder.Add("created_at_max", createdBefore.ToString("yyyy-MM-dd HH:mm"));
            }

            if (default(DateTime) != createdAfter)
            {
                queryStringBuilder.Add("created_at_min", createdAfter.ToString("yyyy-MM-dd HH:mm"));
            }

            if (ScriptTagField.None != fields)
            {
                queryStringBuilder.Add("fields", fields.BuildScriptTagFieldFilter());
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

            if (default(DateTime) != updatedBefore)
            {
                queryStringBuilder.Add("updated_at_min", updatedBefore.ToString("yyyy-MM-dd HH:mm"));
            }

            if (default(DateTime) != updatedAfter)
            {
                queryStringBuilder.Add("updated_at_max", updatedAfter.ToString("yyyy-MM-dd HH:mm"));
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", ApiRequestResources.GetScriptTagsAll, string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTags = JsonConvert.DeserializeObject<ScriptTagsJson>(rawResponseContent);
                return scriptTags.ScriptTags;
            }
        }

        public async Task<ScriptTag> GetSingleAsync(string id, ScriptTagField fields = ScriptTagField.None)
        {
            this.client.Configuration.SingleShopContract();
            return await this.GetSingleAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, id, fields);
        }

        public async Task<ScriptTag> GetSingleAsync(string shopUrl, string accessToken, string id, ScriptTagField fields = ScriptTagField.None)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            var queryStringBuilder = new QueryStringBuilder();
            if (ScriptTagField.None != fields)
            {
                queryStringBuilder.Add("fields", fields.BuildScriptTagFieldFilter());
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", string.Format(CultureInfo.InvariantCulture, ApiRequestResources.GetScriptTagSingle, id), string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagJson = JsonConvert.DeserializeObject<ScriptTagJson>(rawResponseContent);
                return scriptTagJson.ScriptTag;
            }
        }

        public async Task<int> CountAsync(string source = "")
        {
            this.client.Configuration.SingleShopContract();
            return await this.CountAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, source);
        }

        public async Task<int> CountAsync(string shopUrl, string accessToken, string source = "")
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            if (!string.IsNullOrWhiteSpace(source) && !source.IsValidUrlAddress())
            {
                throw new ArgumentException("Source parameter is not a well formed URL");
            }

            var queryStringBuilder = new QueryStringBuilder();
            if (!string.IsNullOrWhiteSpace(source))
            {
                queryStringBuilder.Add("src", source);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var queryStringParameters = queryStringBuilder.ToString();
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, "{0}{1}", ApiRequestResources.GetScriptTagsAllCount, string.IsNullOrWhiteSpace(queryStringParameters) ? string.Empty : queryStringParameters));
                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagsCount = JsonConvert.DeserializeObject<ScriptTagsCountJson>(rawResponseContent);
                return scriptTagsCount.Count;
            }
        }

        public async Task<ScriptTag> CreateAsync(string source)
        {
            this.client.Configuration.SingleShopContract();
            return await this.CreateAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, source);
        }

        public async Task<ScriptTag> CreateAsync(string shopUrl, string accessToken, string source)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var scriptTagCreate = new ScriptTagCreateWrapJson
                {
                    ScriptTag = new ScriptTagCreateJson
                    {
                        Event = "onload",
                        Source = source
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(scriptTagCreate), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(ApiRequestResources.PostScriptTagCreate, content);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagJson = JsonConvert.DeserializeObject<ScriptTagJson>(rawResponseContent);
                return scriptTagJson.ScriptTag;
            }
        }

        public async Task<ScriptTag> UpdateAsync(string id, string source)
        {
            this.client.Configuration.SingleShopContract();
            return await this.UpdateAsync(this.client.Configuration.ShopDomain, this.client.Configuration.AccessToken, id, source);
        }

        public async Task<ScriptTag> UpdateAsync(string shopUrl, string accessToken, string id, string source)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var webhookCreate = new ScriptTagUpdateWrapJson
                {
                    ScriptTag = new ScriptTagUpdateJson
                    {
                        Id = id,
                        Source = source
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(webhookCreate), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.PutScriptTagUpdate, id), content);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagJson = JsonConvert.DeserializeObject<ScriptTagJson>(rawResponseContent);
                return scriptTagJson.ScriptTag;
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
            shopUrl.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.DeleteScriptTag, id));
                return response.IsSuccessStatusCode;
            }
        }
    }
}