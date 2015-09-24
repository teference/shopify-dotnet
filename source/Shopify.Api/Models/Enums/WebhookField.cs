#region Copyright Teference
// ************************************************************************************
// <copyright file="WebhookField.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api.Models
{
    using System;

    [Flags]
    public enum WebhookField
    {
        None = 0,
        Id = 1,
        Address = 1 << 1,
        Topic = 1 << 2,
        CreatedAt = 1 << 3,
        UpdatedAt = 1 << 4,
        Format = 1 << 5,
        Fields = 1 << 6,
        MetafieldNamespace = 1 << 7
    }
}