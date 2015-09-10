namespace Shopify.Api.Models.Internals
{
    #region Namespace

    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    internal sealed class WebhooksJson
    {
        [JsonProperty("webhooks")]
        public IList<Webhook> Hooks { get; set; } 
    }
}