namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using System;
    using System.Globalization;
    using System.Net.Http;
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
                    throw new ArgumentOutOfRangeException(nameof(topic));
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
    }
}
