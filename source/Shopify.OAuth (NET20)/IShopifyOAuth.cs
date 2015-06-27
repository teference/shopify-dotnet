#region Copyright Jsinh.in
// ************************************************************************************
// <copyright file="IShopifyOAuth.cs" company="Jsinh.in">
// Copyright © Jaspalsinh Chauhan (Jsinh) 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Jsinh - Shopify OAuth Helper</project>
// ************************************************************************************
#endregion

namespace Jsinh.Shopify.OAuth
{
    #region Namespace

    using System;

    #endregion

    /// <summary>
    /// Authentication and authorize your application against SHOPIFY API OAUTH 2.0 implementation.
    /// </summary>
    public interface IShopifyOAuth
    {
        /// <summary>
        /// Gets or sets SHOPIFY OAUTH configuration settings.
        /// </summary>
        OAuthConfiguration Configuration { get; set; }

        /// <summary>
        /// Get URL to redirect user at authorization server, asking for permission to access store.
        /// </summary>
        /// <param name="scope">SHOPIFY OAUTH permission scopes for which user will be asked permission for.</param>
        /// <returns>Returns instance of URL that can be used to redirect your current request to initiate SHOPIFY authentication / authorization process.</returns>
        string GetOAuthUrl(OAuthScope scope);

        OAuthState AuthorizeClient(string authorizationCode);
    }
}