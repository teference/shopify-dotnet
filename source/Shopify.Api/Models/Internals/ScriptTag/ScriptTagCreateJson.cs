namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagCreateJson
    {
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("src")]
        public string Source { get; set; }
    }
}