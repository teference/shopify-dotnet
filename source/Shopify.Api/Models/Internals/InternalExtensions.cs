﻿namespace Teference.Shopify.Api.Models.Internals
{
    #region Namespace

    using System;
    using System.Linq;
    using System.Text;
    using System.Net.Http;
    using System.Globalization;
    using System.Net.Http.Headers;

    #endregion

    internal static class InternalExtensions
    {
        internal static string Convert(this WebhookTopic topic)
        {
            switch (topic)
            {
                case WebhookTopic.OrdersCreate:
                    return "orders/create";
                case WebhookTopic.OrdersDelete:
                    return "orders/delete";
                case WebhookTopic.OrdersUpdated:
                    return "orders/updated";
                case WebhookTopic.OrdersPaid:
                    return "orders/paid";
                case WebhookTopic.OrdersCancelled:
                    return "orders/cancelled";
                case WebhookTopic.OrdersFulfilled:
                    return "orders/fulfilled";
                case WebhookTopic.OrdersPartiallyFulfilled:
                    return "orders/partially_fulfilled";
                case WebhookTopic.OrderTransactionsCreate:
                    return "order_transactions/create";
                case WebhookTopic.CartsCreate:
                    return "carts/create";
                case WebhookTopic.CartsUpdate:
                    return "carts/update";
                case WebhookTopic.CheckoutsCreate:
                    return "checkouts/create";
                case WebhookTopic.CheckoutsUpdate:
                    return "checkouts/update";
                case WebhookTopic.CheckoutsDelete:
                    return "checkouts/delete";
                case WebhookTopic.RefundsCreate:
                    return "refunds/create";
                case WebhookTopic.ProductsCreate:
                    return "products/create";
                case WebhookTopic.ProductsUpdate:
                    return "products/update";
                case WebhookTopic.ProductsDelete:
                    return "products/delete";
                case WebhookTopic.CollectionsCreate:
                    return "collections/create";
                case WebhookTopic.CollectionsUpdate:
                    return "collections/update";
                case WebhookTopic.CollectionsDelete:
                    return "collections/delete";
                case WebhookTopic.CustomerGroupsCreate:
                    return "customer_groups/create";
                case WebhookTopic.CustomerGroupsUpdate:
                    return "customer_groups/update";
                case WebhookTopic.CustomerGroupsDelete:
                    return "customer_groups/delete";
                case WebhookTopic.CustomersCreate:
                    return "customers/create";
                case WebhookTopic.CustomersEnable:
                    return "customers/enable";
                case WebhookTopic.CustomersDisable:
                    return "customers/disable";
                case WebhookTopic.CustomersUpdate:
                    return "customers/update";
                case WebhookTopic.CustomersDelete:
                    return "customers/delete";
                case WebhookTopic.FulfillmentsCreate:
                    return "fulfillments/create";
                case WebhookTopic.FulfillmentsUpdate:
                    return "fulfillments/update";
                case WebhookTopic.ShopUpdate:
                    return "shop/update";
                case WebhookTopic.DisputesCreate:
                    return "disputes/create";
                case WebhookTopic.DisputesUpdate:
                    return "disputes/update";
                case WebhookTopic.AppUninstalled:
                    return "app/uninstalled";
                default:
                    throw new ArgumentOutOfRangeException("topic");
            }
        }

        internal static void Configure(this HttpClient httpClient, string shopUrl, string accessToken)
        {
            if (httpClient.DefaultRequestHeaders.CacheControl == null)
            {
                httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
            }

            httpClient.DefaultRequestHeaders.CacheControl.NoCache = true;
            httpClient.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
            httpClient.DefaultRequestHeaders.CacheControl.NoStore = true;
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(string.Format(CultureInfo.InvariantCulture, "https://{0}", shopUrl));
            httpClient.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
        }

        internal static bool IsValidUrlAddress(this string address)
        {
            Uri uriResult;
            return Uri.TryCreate(address, UriKind.Absolute, out uriResult) && Uri.IsWellFormedUriString(address, UriKind.Absolute);
        }

        internal static bool IsValidShopifyDomain(this string shopifyDomain)
        {
            return shopifyDomain.EndsWith(".myshopify.com");
        }

        // ReSharper disable once UnusedParameter.Global
        internal static void SingleShopContract(this ShopifyClientConfiguration configuration)
        {
            if (null == configuration)
            {
                throw new ArgumentException("Shopify shop domain name and access token is required");
            }
        }

        internal static void PerCallShopUrlContract(this string shopUrl)
        {
            if (string.IsNullOrWhiteSpace(shopUrl))
            {
                throw new ArgumentNullException("shopUrl");
            }

            if (!shopUrl.IsValidShopifyDomain())
            {
                throw new ArgumentException("ShopUrl does not contain a valid shopify domain name ending with *.myshopify.com");
            }
        }

        // ReSharper disable once UnusedParameter.Global
        internal static void PerCallAccessTokenContract(this string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }
        }

        internal static string BuildWebhookFieldFilter(this WebhookField webhookField)
        {
            if (webhookField == WebhookField.None)
            {
                return string.Empty;
            }

            var webhookFieldFilterStringBuilder = new StringBuilder();
            foreach (var webhookFieldFilterItem in Enum.GetValues(typeof(WebhookField)).Cast<WebhookField>().Where(webhookFieldFilterItem => webhookFieldFilterItem != WebhookField.None).Where(webhookFieldFilterItem => (webhookField & webhookFieldFilterItem) == webhookFieldFilterItem))
            {
                switch (webhookFieldFilterItem)
                {
                    case WebhookField.Id:
                        webhookFieldFilterStringBuilder.Append("id");
                        break;
                    case WebhookField.Address:
                        webhookFieldFilterStringBuilder.Append("address");
                        break;
                    case WebhookField.Topic:
                        webhookFieldFilterStringBuilder.Append("topic");
                        break;
                    case WebhookField.CreatedAt:
                        webhookFieldFilterStringBuilder.Append("created_at");
                        break;
                    case WebhookField.UpdatedAt:
                        webhookFieldFilterStringBuilder.Append("updated_at");
                        break;
                    case WebhookField.Format:
                        webhookFieldFilterStringBuilder.Append("format");
                        break;
                    case WebhookField.Fields:
                        webhookFieldFilterStringBuilder.Append("fields");
                        break;
                    case WebhookField.MetafieldNamespace:
                        webhookFieldFilterStringBuilder.Append("metafield_namespaces");
                        break;
                }
                webhookFieldFilterStringBuilder.Append(',');
            }

            if (webhookFieldFilterStringBuilder.Length > 0 && webhookFieldFilterStringBuilder[webhookFieldFilterStringBuilder.Length - 1] == ',')
            {
                return webhookFieldFilterStringBuilder.ToString().Substring(0, webhookFieldFilterStringBuilder.Length - 1);
            }

            return webhookFieldFilterStringBuilder.ToString();
        }

        internal static string BuildScriptTagFieldFilter(this ScriptTagField scriptTagField)
        {
            if (scriptTagField == ScriptTagField.None)
            {
                return string.Empty;
            }

            var scriptTagFieldFilterStringBuilder = new StringBuilder();
            foreach (var scriptTagFieldFilterItem in Enum.GetValues(typeof(ScriptTagField)).Cast<ScriptTagField>().Where(scriptTagFieldFilterItem => scriptTagFieldFilterItem != ScriptTagField.None).Where(scriptTagFieldFilterItem => (scriptTagField & scriptTagFieldFilterItem) == scriptTagFieldFilterItem))
            {
                switch (scriptTagFieldFilterItem)
                {
                    case ScriptTagField.Id:
                        scriptTagFieldFilterStringBuilder.Append("id");
                        break;
                    case ScriptTagField.Source:
                        scriptTagFieldFilterStringBuilder.Append("src");
                        break;
                    case ScriptTagField.Event:
                        scriptTagFieldFilterStringBuilder.Append("event");
                        break;
                    case ScriptTagField.CreatedAt:
                        scriptTagFieldFilterStringBuilder.Append("created_at");
                        break;
                    case ScriptTagField.UpdatedAt:
                        scriptTagFieldFilterStringBuilder.Append("updated_at");
                        break;
                }
                scriptTagFieldFilterStringBuilder.Append(',');
            }

            if (scriptTagFieldFilterStringBuilder.Length > 0 && scriptTagFieldFilterStringBuilder[scriptTagFieldFilterStringBuilder.Length - 1] == ',')
            {
                return scriptTagFieldFilterStringBuilder.ToString().Substring(0, scriptTagFieldFilterStringBuilder.Length - 1);
            }

            return scriptTagFieldFilterStringBuilder.ToString();
        }
    }
}