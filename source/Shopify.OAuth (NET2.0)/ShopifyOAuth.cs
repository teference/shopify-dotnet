#region Copyright Teference
// ************************************************************************************
// <copyright file="ShopifyOAuth.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify OAuth Helper</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// Authentication and authorize your application against SHOPIFY API OAUTH 2.0 implementation.
    /// </summary>
    public sealed class ShopifyOAuth : IShopifyOAuth
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyOAuth"/> class.
        /// <para>If initializes with empty constructor, library expected two application setting to be found in 'web.config' / 'app.config'.</para>
        /// <para>1. 'shopify-dotnet-api-key' - Shopify application API key.</para>
        /// <para>2. 'shopify-dotnet-secret-key' - Shopify application shared secret key.</para>
        /// </summary>
        /// <exception cref="ArgumentException">Throws argument null exception if 'shopify-dotnet-api-key' and 'shopify-dotnet-secret-key' not found or empty.</exception>
        /// <exception cref="ArgumentNullException">Throws argument null exception if 'shopify-dotnet-api-key' and 'shopify-dotnet-secret-key' not found or empty.</exception>
        public ShopifyOAuth()
        {
            this.Configuration = ConfigurationExtensions.LoadConfiguration(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyOAuth"/> class.
        /// <para>Use this constructor in case you do not wish this library to fetch API and Secret Key from configuration file.</para>
        /// </summary>
        /// <param name="configuration">Instance of OAUTH settings.</param>
        /// <exception cref="ArgumentNullException">Throws argument null exception if input parameters are null or empty.</exception>
        public ShopifyOAuth(OAuthConfiguration configuration)
        {
            if (null == configuration)
            {
                throw new ArgumentNullException("configuration");
            }

            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets SHOPIFY OAUTH configuration settings.
        /// </summary>
        public OAuthConfiguration Configuration { get; private set; }

        /// <summary>
        /// Get URL to use for redirection at SHOPIFY OAUTH 2.0 authorization server, asking for permission to access intended store.
        /// </summary>
        /// <param name="shopName">Authorization shop name (w/o '.myshopify.com', only shop name). In case it contains '.myshopify.com' then it would be trimmed out to continue</param>
        /// <param name="scope">SHOPIFY OAUTH 2.0 permission scope(s) for which store admin  will be asked permission for.</param>
        /// <returns>Returns instance of URL that can be used to redirect your current request to initiate SHOPIFY authentication / authorization process.</returns>
        /// <exception cref="ArgumentNullException">Throws argument null exception if input parameters are null or empty.</exception>
        public string GetOAuthUrl(string shopName, OAuthScope scope)
        {
            if (string.IsNullOrEmpty(shopName))
            {
                throw new ArgumentNullException("shopName");
            }

            if (shopName.EndsWith(AppResources.MyShopifyDomain, StringComparison.InvariantCulture))
            {
                var indexOfShopifyDomain = shopName.IndexOf(AppResources.MyShopifyDomain, StringComparison.InvariantCulture);
                shopName = shopName.Substring(0, indexOfShopifyDomain);
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                AppResources.AuthorizationUrl,
                shopName,
                this.Configuration.ApiKey,
                ScopeBuilder.Build(scope));
        }

        /// <summary>
        /// Performs SHOPIFY OAUTH 2.0 authorization process based on shop access permission accepted.
        /// </summary>
        /// <param name="queryStringCollection">Instance of name value collection of query string returned in request of the callback URL by SHOPIFY authorization server.</param>
        /// <returns>
        /// Returns authorization state or error details.
        /// <para>The <see cref="OAuthState"/>'s 'IsSuccess' will result in false in case signature validation fails or any other exceptin occurrs.</para>
        /// <para>Error property will be filled with reason for 'IsSuccess' false. Three possible reason strings are:</para>
        /// <para>1. Required parameters in query string missing.</para>
        /// <para>2. HMAC signature validation failed.</para>
        /// <para>3. {Exception Type}: {Exception message} (for any exception).</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws argument null exception if input parameters are null or empty.</exception>
        public OAuthState AuthorizeClient(NameValueCollection queryStringCollection)
        {
            if (null == queryStringCollection || 0 == queryStringCollection.Count)
            {
                throw new ArgumentNullException("queryStringCollection");
            }

            var shopName = queryStringCollection[AppResources.ShopKeyword];
            var authorizationCode = queryStringCollection[AppResources.CodeKeyword];
            var timestamp = queryStringCollection[AppResources.TimestampKeyword];
            var hmacHash = queryStringCollection[AppResources.HmacKeyword];
            if (string.IsNullOrEmpty(shopName)
                || string.IsNullOrEmpty(authorizationCode)
                || string.IsNullOrEmpty(timestamp)
                || string.IsNullOrEmpty(hmacHash))
            {
                return new OAuthState { IsSuccess = false, Error = "Required parameters in query string missing" };
            }

            return this.AuthorizeClient(shopName, authorizationCode, hmacHash, timestamp);
        }

        /// <summary>
        /// Performs SHOPIFY OAUTH 2.0 authorization process based on shop access permission accepted.
        /// </summary>
        /// <param name="shopName">Authorization shop name.</param>
        /// <param name="authorizationCode">Intermediate authorization code, required to complete SHOPIFY OAUTH 2.0 authorization.</param>
        /// <param name="hmacHash">HMAC hash value.</param>
        /// <param name="timestamp">Timestamp value returned in the callback query string.</param>
        /// <returns>
        /// Returns authorization state or error details.
        /// <para>The <see cref="OAuthState"/>'s 'IsSuccess' will result in false in case signature validation fails or any other exceptin occurrs.</para>
        /// <para>Error property will be filled with reason for 'IsSuccess' false. Three possible reason strings are:</para>
        /// <para>1. Required parameters in query string missing.</para>
        /// <para>2. HMAC signature validation failed.</para>
        /// <para>3. {Exception Type}: {Exception message} (for any exception).</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws argument null exception if input parameters are null or empty.</exception>
        public OAuthState AuthorizeClient(string shopName, string authorizationCode, string hmacHash, string timestamp)
        {
            if (string.IsNullOrEmpty(shopName))
            {
                throw new ArgumentNullException("shopName");
            }

            if (string.IsNullOrEmpty(authorizationCode))
            {
                throw new ArgumentNullException("authorizationCode");
            }

            if (string.IsNullOrEmpty(hmacHash))
            {
                throw new ArgumentNullException("hmacHash");
            }

            if (string.IsNullOrEmpty(timestamp))
            {
                throw new ArgumentNullException("timestamp");
            }

            var hashValidationResult = this.ValidateInstallResponse(new OAuthState { ShopName = shopName, AuthorizationCode = authorizationCode, HmacHash = hmacHash, AuthorizationTimestamp = timestamp });
            if (!hashValidationResult)
            {
                return new OAuthState { IsSuccess = false, Error = "HMAC signature validation failed" };
            }

            try
            {
                var accessTokenUrl = string.Format(CultureInfo.InvariantCulture, AppResources.AccessTokenUrl, shopName);
                var queryBuilder = new QueryStringBuilder { StartsWith = null };
                queryBuilder.Add(AppResources.ClientIdKeyword, this.Configuration.ApiKey);
                queryBuilder.Add(AppResources.ClientSecretKeyword, this.Configuration.SecretKey);
                queryBuilder.Add(AppResources.CodeKeyword, authorizationCode);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(accessTokenUrl);
                httpWebRequest.Method = HttpType.POST.ToString();

                //// Not sure if that would help but I encountered this while fixing another BUG so going to keep it in place.
                ServicePointManager.Expect100Continue = true;
#if NET20
                ServicePointManager.SecurityProtocol = SecurityProtocolTypeExtensions.Tls12;
#else
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

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
                oauthResponse.ShopName = shopName;
                oauthResponse.IsSuccess = true;
                return oauthResponse;
            }
            catch (Exception exception)
            {
                return new OAuthState { IsSuccess = false, Error = string.Format(CultureInfo.InvariantCulture, "{0}: {1}", exception.GetType().Name, exception.Message) };
            }
        }

        private static string ByteArrayToHexString(ICollection<byte> byteData)
        {
            var hexStringBuild = new StringBuilder(byteData.Count * 2);
            foreach (var item in byteData)
            {
                hexStringBuild.AppendFormat("{0:x2}", item);
            }

            return hexStringBuild.ToString();
        }

        private bool ValidateInstallResponse(OAuthState installState)
        {
            var queryStringBuilder = new QueryStringBuilder { StartsWith = null };
            queryStringBuilder.Add(AppResources.CodeKeyword, installState.AuthorizationCode);
            queryStringBuilder.Add(AppResources.ShopKeyword, installState.ShopName);
            queryStringBuilder.Add(AppResources.TimestampKeyword, installState.AuthorizationTimestamp);
            var secretKeyBytes = Encoding.UTF8.GetBytes(this.Configuration.SecretKey);
            var installResponseBytes = Encoding.UTF8.GetBytes(queryStringBuilder.ToString());
            using (var hmacsha256 = new HMACSHA256(secretKeyBytes))
            {
                var generatedInstallResponseHmacHashBytes = hmacsha256.ComputeHash(installResponseBytes);
                var generatedInstallResponseHmacHash = ByteArrayToHexString(generatedInstallResponseHmacHashBytes);
                return generatedInstallResponseHmacHash.Equals(installState.HmacHash);
            }
        }
    }
}