namespace Jsinh.Shopify.OAuth
{
    #region Namespace

    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;

    using Jsinh.Shopify.Api;

    using Newtonsoft.Json;

    #endregion
    /// <summary>
    /// Authentication and authorize your application against SHOPIFY API OAUTH 2.0 implementation.
    /// </summary>
    public sealed class ShopifyOAuth : IShopifyOAuth
    {
        public ShopifyOAuth()
        {
            this.Configuration = ConfigurationExtensions.LoadConfiguration(this);
        }

        public ShopifyOAuth(OAuthConfiguration configuration)
        {
            if (null == configuration)
            {
                throw new ArgumentNullException("configuration");
            }

            this.Configuration = configuration;
        }

        public OAuthConfiguration Configuration { get; set; }

        /// <summary>
        /// Get URL to redirect user at authorization server, asking for permission to access store.
        /// </summary>
        /// <param name="scope">SHOPIFY OAUTH permission scopes for which user will be asked permission for.</param>
        /// <returns>Returns instance of URL that can be used to redirect your current request to initiate SHOPIFY authentication / authorization process.</returns>
        public string GetOAuthUrl(OAuthScope scope)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                AppResources.AuthorizationUrl,
                this.Configuration.ShopName,
                this.Configuration.ApiKey,
                ScopeBuilder.Build(scope));
        }

        public OAuthState AuthorizeClient(string authorizationCode)
        {
            if (string.IsNullOrEmpty(authorizationCode))
            {
                throw new ArgumentNullException("authorizationCode");
            }

            var accessTokenUrl = string.Format(CultureInfo.InvariantCulture, AppResources.AccessTokenUrl, this.Configuration.ShopName);
            var queryBuilder = new QueryStringBuilder();
            queryBuilder.Add("client_id", this.Configuration.ApiKey);
            queryBuilder.Add("client_secret", this.Configuration.SecretKey);
            queryBuilder.Add("code", authorizationCode);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(accessTokenUrl);
            httpWebRequest.Method = HttpType.POST.ToString();
            httpWebRequest.ContentType = AppResources.DefaultHttpClientContentType;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(queryBuilder.ToString());
                streamWriter.Close();
            }

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var jsonResponse = string.Empty;
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        jsonResponse = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
            }

            var oauthResponse = JsonConvert.DeserializeObject<OAuthState>(jsonResponse);
            oauthResponse.ShopName = this.Configuration.ShopName;
            return oauthResponse;
        }
    }
}