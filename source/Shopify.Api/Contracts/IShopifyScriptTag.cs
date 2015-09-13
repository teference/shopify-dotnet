namespace Shopify.Api
{
    #region Namespace

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Shopify.Api.Models;

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