namespace Teference.Shopify.Api
{
    #region Namespace

    using System;
    using Models;
    using Teference.Shopify.Api.Models.Internals;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;

    #endregion

    public sealed class ShopifyClient : IShopifyClient
    {
        #region Constructor

        public ShopifyClient()
        {
            this.Webhooks = new ShopifyWebhook(this);
            this.ScriptTag = new ShopifyScriptTag(this);
        }

        public ShopifyClient(ShopifyClientConfiguration configuration)
            : this()
        {
            if (null == configuration)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(configuration.ShopDomain))
            {
                throw new ArgumentNullException("configuration.ShopDomain");
            }

            if (!configuration.ShopDomain.IsValidShopifyDomain())
            {
                throw new ArgumentException("ShopDomain property does not contain a valid shopify domain name ending with *.myshopify.com");
            }

            if (string.IsNullOrWhiteSpace(configuration.AccessToken))
            {
                throw new ArgumentNullException("configuration.AccessToken");
            }

            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public IShopifyWebhook Webhooks { get; private set; }
        public IShopifyScriptTag ScriptTag { get; private set; }

        public ShopifyClientConfiguration Configuration { get; set; }

        #endregion

        #region Methods

        public async Task<ShopInfo> ShopInfo()
        {
            this.Configuration.SingleShopContract();
            return await this.ShopInfo(this.Configuration.ShopDomain, this.Configuration.AccessToken);
        }
        public async Task<ShopInfo> ShopInfo(string shopUrl, string accessToken)
        {
            shopUrl.PerCallShopUrlContract();
            accessToken.PerCallAccessTokenContract();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(shopUrl, accessToken);
                var response = await httpClient.GetAsync(ApiRequestResources.GetShopAccountConfiguration);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var shopInfo = JsonConvert.DeserializeObject<ShopInfo>(rawResponseContent);
                return shopInfo;
            }
        }

        #endregion
    }
}