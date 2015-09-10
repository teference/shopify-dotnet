namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhookCreateWrapJson
    {
        [JsonProperty("webhook")]
        public WebhookCreateJson Webhook { get; set; }
    }
}