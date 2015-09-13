namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagUpdateJson
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("src")]
        public string Source { get; set; }
    }
}