namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhookJson
    {
        [JsonProperty("webhook")]
        public Webhook Webhook { get; set; }
    }
}