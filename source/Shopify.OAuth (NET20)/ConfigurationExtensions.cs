#region Copyright Teference
// ************************************************************************************
// <copyright file="ConfigurationExtensions.cs" company="Teference">
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
    using System.Configuration;
    
    #endregion

    internal static class ConfigurationExtensions
    {
        internal static OAuthConfiguration LoadConfiguration(IShopifyOAuth shopifyOAuth)
        {
            if (null == shopifyOAuth)
            {
                throw new ArgumentNullException("shopifyOAuth");
            }

            var configuration = shopifyOAuth.Configuration ?? new OAuthConfiguration();
            LoadShopifyApiKeySetting(configuration);
            LoadShopifySecretKeySetting(configuration);
            return configuration;
        }

        private static void LoadShopifyApiKeySetting(OAuthConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.ApiKey))
            {
                return;
            }

            var apiKeyConfigurationValue = ConfigurationManager.AppSettings[AppResources.KeyShopifyApiKey];
            if (!string.IsNullOrEmpty(apiKeyConfigurationValue))
            {
                configuration.ApiKey = apiKeyConfigurationValue;
            }
            else
            {
                throw new ArgumentException(AppResources.ApiKeyNotFoundException);
            }
        }

        private static void LoadShopifySecretKeySetting(OAuthConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.SecretKey))
            {
                return;
            }

            var secretKeyConfigurationValue = ConfigurationManager.AppSettings[AppResources.KeyShopifyAppSecret];
            if (!string.IsNullOrEmpty(secretKeyConfigurationValue))
            {
                configuration.SecretKey = secretKeyConfigurationValue;
            }
            else
            {
                throw new ArgumentException(AppResources.SecretKeyNotFoundException);
            }
        }
    }
}