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

    #endregion

    internal sealed class ShopifyScriptTag : IShopifyScriptTag
    {
        public async Task<IList<ScriptTag>> GetAsync(string shopUrl, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(ApiRequestResources.GetScriptTagsAll);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTags = JsonConvert.DeserializeObject<ScriptTagsJson>(rawResponseContent);
                return scriptTags.ScriptTags;
            }
        }

        public async Task<ScriptTag> GetAsync(string shopUrl, string accessToken, string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.GetScriptTagSingle, id));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagJson = JsonConvert.DeserializeObject<ScriptTagJson>(rawResponseContent);
                return scriptTagJson.ScriptTag;
            }
        }

        public async Task<int> CountAsync(string shopUrl, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(ApiRequestResources.GetScriptTagsAllCount);
                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var scriptTagsCount = JsonConvert.DeserializeObject<ScriptTagsCountJson>(rawResponseContent);
                return scriptTagsCount.Count;
            }
        }

        public async Task<ScriptTag> CreateAsync(string shopUrl, string accessToken, string source)
        {
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

        public async Task<ScriptTag> UpdateAsync(string shopUrl, string accessToken, string id, string source)
        {
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

        public async Task<bool> DeleteAsync(string shopUrl, string accessToken, string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiRequestResources.DeleteScriptTag, id));
                return response.IsSuccessStatusCode;
            }
        }
    }
}