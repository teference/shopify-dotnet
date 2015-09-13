namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagJson
    {
        [JsonProperty("script_tag")]
        public ScriptTag ScriptTag { get; set; }
    }
}