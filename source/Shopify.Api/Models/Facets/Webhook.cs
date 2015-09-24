#region Copyright Teference
// ************************************************************************************
// <copyright file="Webhook.cs" company="Teference">
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
    using System.Collections.Generic;

    #endregion

    public sealed class Webhook
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("topic")]
        public string Topic { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("fields")]
        public List<object> Fields { get; set; }
        [JsonProperty("metafield_namespaces")]
        public List<object> MetafieldNamespaces { get; set; }
    }
}