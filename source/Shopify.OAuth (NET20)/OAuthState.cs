#region Copyright Teference
// ************************************************************************************
// <copyright file="OAuthState.cs" company="Teference">
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

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// Represents SHOPIFY OAUTH 2.0 authorization state.
    /// </summary>
    public sealed class OAuthState
    {
        /// <summary>
        /// Gets a value indicating whether SHOPIFY OAUTH 2.0 authorization process succeeded or not.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// Gets error message if value of <see cref="IsSuccess"/> is false.
        /// </summary>
        public string Error { get; internal set; }

        /// <summary>
        /// Gets SHOPIFY shop name provided in authorization request.
        /// </summary>
        [JsonIgnore]
        public string ShopName { get; internal set; }

        /// <summary>
        /// Gets authorized access token to use for accessing SHOPIFY API for the shop.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; internal set; }

        [JsonIgnore]
        internal string AuthorizationCode { get; set; }

        [JsonIgnore]
        internal string AuthorizationTimestamp { get; set; }

        [JsonIgnore]
        internal string HmacHash { get; set; }
    }
}