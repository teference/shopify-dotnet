namespace Jsinh.Shopify.OAuth
{
    #region Namespace

    using System;
    using System.Text;
    
    #endregion

    internal static class ScopeBuilder
    {
        internal static string Build(OAuthScope oauthScope)
        {
            if (oauthScope == OAuthScope.none)
            {
                return string.Empty;
            }

            var shopifyScopeStringBuilder = new StringBuilder();
            foreach (var item in Enum.GetValues(typeof(OAuthScope)))
            {
                var shopifyScopeItem = (OAuthScope)item;
                if (shopifyScopeItem == OAuthScope.none || (oauthScope & shopifyScopeItem) != shopifyScopeItem)
                {
                    continue;
                }

                shopifyScopeStringBuilder.Append(shopifyScopeItem.ToString().ToLowerInvariant());
                shopifyScopeStringBuilder.Append(',');
            }

            if (shopifyScopeStringBuilder.Length > 0 && shopifyScopeStringBuilder[shopifyScopeStringBuilder.Length - 1] == ',')
            {
                return shopifyScopeStringBuilder.ToString().Substring(0, shopifyScopeStringBuilder.Length - 1);
            }

            return shopifyScopeStringBuilder.ToString();
        }
    }
}