namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagCreateWrapJson
    {
        [JsonProperty("script_tag")]
        public ScriptTagCreateJson ScriptTag { get; set; }
    }
}