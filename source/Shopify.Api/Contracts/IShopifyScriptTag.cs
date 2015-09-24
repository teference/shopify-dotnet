#region Copyright Teference
// ************************************************************************************
// <copyright file="IShopifyScriptTag.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api
{
    #region Namespace

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Teference.Shopify.Api.Models;

    #endregion

    public interface IShopifyScriptTag
    {
        Task<IList<ScriptTag>> GetAsync(string shopUrl, string accessToken);
        Task<ScriptTag> GetAsync(string shopUrl, string accessToken, string id);
        Task<int> CountAsync(string shopUrl, string accessToken);
        Task<ScriptTag> CreateAsync(string shopUrl, string accessToken, string source);
        Task<ScriptTag> UpdateAsync(string shopUrl, string accessToken, string id, string source);
        Task<bool> DeleteAsync(string shopUrl, string accessToken, string id);
    }
}