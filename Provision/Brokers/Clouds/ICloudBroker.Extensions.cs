using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Provision.Brokers.Clouds
{
    public partial interface ICloudBroker
    {
        ValueTask<SiteExtensionInfoInner> InstallExtensionAsync(
            string resourceGroupName,
            string siteName,
            string extensionName);
    }
}
