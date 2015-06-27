namespace Jsinh.Shopify.OAuth
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
            LoadShopifyShopNameSetting(configuration);
            LoadShopifyApiKeySetting(configuration);
            LoadShopifySecretKeySetting(configuration);
            return configuration;
        }

        private static void LoadShopifyShopNameSetting(OAuthConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.ShopName))
            {
                return;
            }

            var shopNameConfigurationValue = ConfigurationManager.AppSettings[AppResources.KeyShopifyShopName];
            if (!string.IsNullOrEmpty(shopNameConfigurationValue))
            {
                configuration.ShopName = shopNameConfigurationValue.ToLowerInvariant();
            }
            else
            {
                throw new ArgumentException(AppResources.ShopNameNotFoundException);
            }
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