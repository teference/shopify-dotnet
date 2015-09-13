namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagsCountJson
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}