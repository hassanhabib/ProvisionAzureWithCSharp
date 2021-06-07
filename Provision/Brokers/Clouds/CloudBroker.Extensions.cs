using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Provision.Brokers.Clouds
{
    public partial class CloudBroker
    {
        public async ValueTask<SiteExtensionInfoInner> InstallExtensionAsync(
            string resourceGroupName,
            string siteName,
            string extensionName)
        {
            IWebAppsOperations webAppsOperations =
                this.azure.WebApps.Inner;

            return await webAppsOperations.InstallSiteExtensionAsync(
                resourceGroupName,
                siteName,
                extensionName);
        }
    }
}
