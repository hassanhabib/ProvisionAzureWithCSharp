using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Provision.Brokers.Clouds
{
    public partial class CloudBroker
    {
        public async ValueTask<IWebApp> CreateWebAppAsync(
            string webAppName, 
            IAppServicePlan plan,
            IResourceGroup resourceGroup)
        {
            return await azure.AppServices.WebApps
                .Define(webAppName)
                .WithExistingWindowsPlan(plan)
                .WithExistingResourceGroup(resourceGroup)
                .CreateAsync();
        }
    }
}
