#region Copyright Teference
// ************************************************************************************
// <copyright file="WebhookCreateWrapJson.cs" company="Teference">
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

    internal sealed class WebhookCreateWrapJson
    {
        [JsonProperty("webhook")]
        public WebhookCreateJson Webhook { get; set; }
    }
}