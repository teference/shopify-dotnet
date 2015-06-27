namespace Jsinh.Shopify.OAuth
{
    using Newtonsoft.Json;

    public sealed class OAuthState
    {
        public string ShopName { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}