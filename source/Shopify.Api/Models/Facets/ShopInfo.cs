#region Copyright Teference
// ************************************************************************************
// <copyright file="ShopInfo.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api.Models
{
    #region Namespace

    using System;
    using Newtonsoft.Json;

    #endregion

    public sealed class ShopInfo
    {
        public ShopInfo() { }

        [JsonProperty("id")]
        public long ShopId { get; set; }

        [JsonProperty("name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string ShopEmail { get; set; }

        [JsonProperty("domain")]
        public string PublicDomain { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("primary_locale")]
        public string PrimaryLocale { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string CountryNormalized { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("iana_timezone")]
        public string IanaTimeZone { get; set; }

        [JsonProperty("shop_owner")]
        public string OwnerName { get; set; }

        [JsonProperty("money_format")]
        public string MoneyFormat { get; set; }

        [JsonProperty("money_with_currency_format")]
        public string MoneyWithCurrencyFormat { get; set; }

        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("tax_shipping")]
        public bool? TaxesOnShipping { get; set; }

        [JsonProperty("county_taxes")]
        public bool TaxesPerCounty { get; set; }

        [JsonProperty("plan_display_name")]
        public string PlanDisplayName { get; set; }

        [JsonProperty("plan_name")]
        public string PlanName { get; set; }

        [JsonProperty("myshopify_domain")]
        public string ShopifyDomain { get; set; }

        [JsonProperty("google_apps_domain")]
        public string GoogleAppsDomain { get; set; }

        [JsonProperty("google_apps_login_enabled")]
        public bool? GoogleAppsLoginEnabled { get; set; }

        [JsonProperty("money_in_emails_format")]
        public string MoneyInEmailFormat { get; set; }

        [JsonProperty("money_with_currency_in_emails_format")]
        public string MoneyWithCurrencyInEmailFormat { get; set; }

        [JsonProperty("eligible_for_payments")]
        public bool EligibleForPayments { get; set; }

        [JsonProperty("requires_extra_payments_agreement")]
        public bool RequiresExtraPaymentsAgreement { get; set; }

        [JsonProperty("password_enabled")]
        public bool PasswordEnabled { get; set; }

        [JsonProperty("has_storefront")]
        public bool HasStoreFront { get; set; }

        [JsonProperty("setup_required")]
        public bool SetupRequired { get; set; }
    }
}