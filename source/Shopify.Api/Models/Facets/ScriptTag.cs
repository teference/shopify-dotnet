#region Copyright Teference
// ************************************************************************************
// <copyright file="ScriptTag.cs" company="Teference">
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

    public sealed class ScriptTag
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("src")]
        public string Source { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}