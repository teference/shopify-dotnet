#region Copyright Teference
// ************************************************************************************
// <copyright file="IShopifyOAuth.cs" company="Teference">
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
    using System.Collections.Specialized;
    
    #endregion

    /// <summary>
    /// Contracts to authenticate and authorize application against SHOPIFY API OAUTH 2.0 implementation.
    /// </summary>
    public interface IShopifyOAuth
    {
        /// <summary>
        /// Gets SHOPIFY OAUTH configuration settings.
        /// </summary>
        OAuthConfiguration Configuration { get; }

        /// <summary>
        /// Get URL to use for redirection at SHOPIFY OAUTH 2.0 authorization server, asking for permission to access intended store.
        /// </summary>
        /// <param name="shopName">Authorization shop name (w/o '.myshopify.com', only shop name). In case it contains '.myshopify.com' then it would be trimmed out to continue</param>
        /// <param name="scope">SHOPIFY OAUTH 2.0 permission scope(s) for which store admin  will be asked permission for.</param>
        /// <returns>Returns instance of URL that can be used to redirect your current request to initiate SHOPIFY authentication / authorization process.</returns>
        /// <exception cref="ArgumentNullException">Throws argument null exception if input parameters are null or empty.</exception>
        string GetOAuthUrl(string shopName, OAuthScope scope);

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
        OAuthState AuthorizeClient(NameValueCollection queryStringCollection);

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
        OAuthState AuthorizeClient(string shopName, string authorizationCode, string hmacHash, string timestamp);
    }
}