#region Copyright Teference
// ************************************************************************************
// <copyright file="ScriptTagUpdateJson.cs" company="Teference">
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

    internal sealed class ScriptTagUpdateJson
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("src")]
        public string Source { get; set; }
    }
}