using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

class Program
{
    static async Task Main(string[] args)
    {
        // Replace these variables with your own values
        string resourceGroupName = "my-sdk-rg";
        string location = "westus"; //AzureLocation.WestUS2;//"westus";

        try
        {
            var credential = new DefaultAzureCredential();
            var client = new ArmClient(credential);

            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            ResourceGroupData resourceGroupData = new ResourceGroupData(location);
            ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(Azure.WaitUntil.Completed, resourceGroupName, resourceGroupData);//resourceGroupName, resourceGroupData);

            Console.WriteLine($"Resource group '{operation.Value.Data.Name}' created or updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
