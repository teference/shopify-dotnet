#region Copyright Jsinh.in
// ************************************************************************************
// <copyright file="OAuthScope.cs" company="Jsinh.in">
// Copyright © Jaspalsinh Chauhan (Jsinh) 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Jsinh - Shopify OAuth Helper</project>
// ************************************************************************************
#endregion

namespace Jsinh.Shopify.Api
{
    #region Namespace

    using System;
    
    #endregion

    /// <summary>
    /// Defines list of OAUTH - authorization scope.
    /// </summary>
    [Flags]
    public enum OAuthScope
    {
        /// <summary>
        /// Default and no authorization scope applied in this case.
        /// </summary>
        none = 0,

        /// <summary>
        /// Read only access to article, blog, comment, page and redirect.
        /// </summary>
        read_content = 1,

        /// <summary>
        /// Write access to article, blog, comment, page and redirect.
        /// </summary>
        write_content = 1 << 1,

        /// <summary>
        /// Read only access to asset and theme.
        /// </summary>
        read_themes = 1 << 2,

        /// <summary>
        /// Write access to asset and theme.
        /// </summary>
        write_themes = 1 << 3,

        /// <summary>
        /// Read only access to product, product variant, product image, collect, custom collection and smart collection.
        /// </summary>
        read_products = 1 << 4,

        /// <summary>
        /// Write access to product, product variant, product image, collect, custom collection and smart collection.
        /// </summary>
        write_products = 1 << 5,

        /// <summary>
        /// Read only access to customer and customer group.
        /// </summary>
        read_customers = 1 << 6,

        /// <summary>
        /// Write access to customer and customer group.
        /// </summary>
        write_customers = 1 << 7,

        /// <summary>
        /// Read only access to order, transaction and fulfillment service.
        /// </summary>
        read_orders = 1 << 8,

        /// <summary>
        /// Write access to order, transaction and fulfillment service.
        /// </summary>
        write_orders = 1 << 9,

        /// <summary>
        /// Read only access to script tags.
        /// </summary>
        read_script_tags = 1 << 10,

        /// <summary>
        /// Write access to script tags.
        /// </summary>
        write_script_tags = 1 << 11,

        /// <summary>
        /// Read only access to fulfillment service.
        /// </summary>
        read_fulfillments = 1 << 12,

        /// <summary>
        /// Write access to fulfillment service.
        /// </summary>
        write_fulfillments = 1 << 13,

        /// <summary>
        /// Read only access to carrier service.
        /// </summary>
        read_shipping = 1 << 14,

        /// <summary>
        /// Write access to carrier service.
        /// </summary>
        write_shipping = 1 << 15,
    }
}