#region Copyright Teference
// ************************************************************************************
// <copyright file="WebhooksJson.cs" company="Teference">
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
    #region Namespace

    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    internal sealed class WebhooksJson
    {
        [JsonProperty("webhooks")]
        public IList<Webhook> Hooks { get; set; } 
    }
}