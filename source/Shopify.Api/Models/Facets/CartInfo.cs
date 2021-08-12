#region Copyright Teference
// ************************************************************************************
// <copyright file="CartInfo.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <project>Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api.Models
{
    #region Namespace

    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class CartInfo
    {
        public CartInfo()
        {
            this.Items = new List<CartItem>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("line_items")]
        public List<CartItem> Items { get; set; }
    }
}
