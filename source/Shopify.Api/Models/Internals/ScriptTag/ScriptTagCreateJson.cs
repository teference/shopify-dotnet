#region Copyright Teference
// ************************************************************************************
// <copyright file="ScriptTagCreateJson.cs" company="Teference">
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

    using Newtonsoft.Json;

    #endregion

    internal sealed class ScriptTagCreateJson
    {
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("src")]
        public string Source { get; set; }
    }
}