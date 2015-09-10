namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhookUpdateJson
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}