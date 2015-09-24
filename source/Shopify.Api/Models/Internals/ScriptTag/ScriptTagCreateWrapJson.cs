#region Copyright Teference
// ************************************************************************************
// <copyright file="ScriptTagCreateWrapJson.cs" company="Teference">
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

    internal sealed class ScriptTagCreateWrapJson
    {
        [JsonProperty("script_tag")]
        public ScriptTagCreateJson ScriptTag { get; set; }
    }
}