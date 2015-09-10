namespace Shopify.Api.Models
{
    public enum WebhookTopic
    {
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