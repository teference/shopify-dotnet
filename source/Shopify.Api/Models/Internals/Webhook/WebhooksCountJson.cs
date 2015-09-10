namespace Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhooksCountJson
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}