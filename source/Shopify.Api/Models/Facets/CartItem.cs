#region Copyright Teference
// ************************************************************************************
// <copyright file="CartItem.cs" company="Teference">
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

    using Newtonsoft.Json;

    #endregion

    public sealed class CartItem
    {
        [JsonProperty("id")]
        public long ItemId { get; set; }
        [JsonProperty("properties")]
        public string Properties { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("variant_id")]
        public long VariantId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("line_price")]
        public double LinePrice { get; set; }
        [JsonProperty("sku")]
        public string ItemSku { get; set; }
        [JsonProperty("grams")]
        public string Grams { get; set; }
        [JsonProperty("vendor")]
        public string Vendor { get; set; }
        [JsonProperty("product_id")]
        public long ProductId { get; set; }
        [JsonProperty("gift_card")]
        public bool GiftCard { get; set; }
    }
}