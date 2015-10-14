#region Copyright Teference
// ************************************************************************************
// <copyright file="IShopifyWebhook.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

#pragma warning disable 1591
namespace Teference.Shopify.Api
{
    #region Namespace

    using System;
    using System.Threading.Tasks;
    using Teference.Shopify.Api.Models;
    using System.Collections.Generic;

    #endregion

    public interface IShopifyWebhook
    {
        Task<IList<Webhook>> GetAllAsync(string address = "", DateTime createdBefore = default(DateTime),
            DateTime createdAfter = default(DateTime), WebhookField fields = WebhookField.None, int limit = 50,
            int page = 1, int idGreaterThan = 0, WebhookTopic topic = WebhookTopic.None,
            DateTime updatedBefore = default(DateTime), DateTime updatedAfter = default(DateTime));
        Task<IList<Webhook>> GetAllAsync(string shopUrl, string accessToken, string address = "",
            DateTime createdBefore = default(DateTime), DateTime createdAfter = default(DateTime),
            WebhookField fields = WebhookField.None, int limit = 50, int page = 1, int idGreaterThan = 0,
            WebhookTopic topic = WebhookTopic.None, DateTime updatedBefore = default(DateTime),
            DateTime updatedAfter = default(DateTime));

        Task<Webhook> GetSingleAsync(string id, WebhookField fields = WebhookField.None);
        Task<Webhook> GetSingleAsync(string shopUrl, string accessToken, string id, WebhookField fields = WebhookField.None);

        Task<int> CountAsync(string address = "", WebhookTopic topic = WebhookTopic.None);
        Task<int> CountAsync(string shopUrl, string accessToken, string address = "", WebhookTopic topic = WebhookTopic.None);

        Task<Webhook> CreateAsync(string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json);
        Task<Webhook> CreateAsync(string shopUrl, string accessToken, string address, WebhookTopic topic, WebhookFormat format = WebhookFormat.Json);

        Task<Webhook> UpdateAsync(string id, string address);
        Task<Webhook> UpdateAsync(string shopUrl, string accessToken, string id, string address);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string shopUrl, string accessToken, string id);
    }
}