namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagUpdateWrapJson
    {
        [JsonProperty("script_tag")]
        public ScriptTagUpdateJson ScriptTag { get; set; }
    }
}