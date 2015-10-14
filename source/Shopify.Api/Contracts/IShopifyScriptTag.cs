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

using System;

#pragma warning disable 1591
namespace Teference.Shopify.Api
{
    #region Namespace

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Teference.Shopify.Api.Models;

    #endregion

    public interface IShopifyScriptTag
    {
        Task<IList<ScriptTag>> GetAllAsync(string source = "", DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime), ScriptTagField fields = ScriptTagField.None, int limit = 50,
            int page = 1, int idGreaterThan = 0, DateTime updatedBefore = default(DateTime), DateTime updatedAfter = default(DateTime));
        Task<IList<ScriptTag>> GetAllAsync(string shopUrl, string accessToken, string source = "", DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime), ScriptTagField fields = ScriptTagField.None, int limit = 50,
            int page = 1, int idGreaterThan = 0, DateTime updatedBefore = default(DateTime), DateTime updatedAfter = default(DateTime));

        Task<ScriptTag> GetSingleAsync(string id, ScriptTagField fields = ScriptTagField.None);
        Task<ScriptTag> GetSingleAsync(string shopUrl, string accessToken, string id, ScriptTagField fields = ScriptTagField.None);

        Task<int> CountAsync(string source = "");
        Task<int> CountAsync(string shopUrl, string accessToken, string source = "");

        Task<ScriptTag> CreateAsync(string source);
        Task<ScriptTag> CreateAsync(string shopUrl, string accessToken, string source);

        Task<ScriptTag> UpdateAsync(string id, string source);
        Task<ScriptTag> UpdateAsync(string shopUrl, string accessToken, string id, string source);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string shopUrl, string accessToken, string id);
    }
}