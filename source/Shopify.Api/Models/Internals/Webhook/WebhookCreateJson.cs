namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhookCreateJson
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}