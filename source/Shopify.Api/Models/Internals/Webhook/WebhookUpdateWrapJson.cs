namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhookUpdateWrapJson
    {
        [JsonProperty("webhook")]
        public WebhookUpdateJson Webhook { get; set; }
    }
}