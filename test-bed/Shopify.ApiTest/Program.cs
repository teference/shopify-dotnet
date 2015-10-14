namespace Shopify.ApiTest
{
    using System;
    using Teference.Shopify.Api;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Task.Run(async () => await program.DoTask());
            Console.ReadLine();
        }

        private async Task DoTask()
        {
            IShopifyClient shopifyClient =
                new ShopifyClient(new ShopifyClientConfiguration()
                {
                    AccessToken = Environment.GetEnvironmentVariable("ShopifyToken", EnvironmentVariableTarget.User),
                    ShopDomain = Environment.GetEnvironmentVariable("ShopifyDomain", EnvironmentVariableTarget.User)
                });

            ////var responseAll = await shopifyClient.Webhooks.GetAllAsync(topic: WebhookTopic.ShopUpdate);
            ////var updateResponse = await shopifyClient.Webhooks.UpdateAsync("", "", "", "http://example.com/");
            ///// var deleteResponse = await shopifyClient.Webhooks.DeleteAsync("", "", "");
            ////var allscripttag = await shopifyClient.ScriptTag.GetAllAsync(fields: ScriptTagField.Id | ScriptTagField.Source);
        }
    }
}