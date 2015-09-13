namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagsJson
    {
        [JsonProperty("script_tags")]
        public IList<ScriptTag> ScriptTags { get; set; }
    }
}