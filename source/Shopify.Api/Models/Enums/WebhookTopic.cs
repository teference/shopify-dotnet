#region Copyright Teference
// ************************************************************************************
// <copyright file="WebhookTopic.cs" company="Teference">
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
    public enum WebhookTopic
    {
        None,

        OrdersCreate,
        OrdersDelete,
        OrdersUpdated,
        OrdersPaid,
        OrdersCancelled,
        OrdersFulfilled,
        OrdersPartiallyFulfilled,

        OrderTransactionsCreate,

        CartsCreate,
        CartsUpdate,

        CheckoutsCreate,
        CheckoutsUpdate,
        CheckoutsDelete,

        RefundsCreate,

        ProductsCreate,
        ProductsUpdate,
        ProductsDelete,

        CollectionsCreate,
        CollectionsUpdate,
        CollectionsDelete,

        CustomerGroupsCreate,
        CustomerGroupsUpdate,
        CustomerGroupsDelete,

        CustomersCreate,
        CustomersEnable,
        CustomersDisable,
        CustomersUpdate,
        CustomersDelete,

        FulfillmentsCreate,
        FulfillmentsUpdate,

        ShopUpdate,

        DisputesCreate,
        DisputesUpdate,

        AppUninstalled
    }
}