#region Copyright Teference
// ************************************************************************************
// <copyright file="ScriptTagField.cs" company="Teference">
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
    public enum ScriptTagField
    {
        None = 0,
        Id = 1,
        Source = 1 << 1,
        Event = 1 << 2,
        CreatedAt = 1 << 3,
        UpdatedAt = 1 << 4
    }
}