#region Copyright Teference
// ************************************************************************************
// <copyright file="WebhooksCountJson.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api.Models.Internals
{
    using Newtonsoft.Json;

    internal sealed class WebhooksCountJson
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}