using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Provision.Brokers.Clouds
{
    public partial class CloudBroker
    {
        public async ValueTask<IResourceGroup> CreateResourceGroupAsync(string resourceGroupName)
        {
            return await azure.ResourceGroups
                 .Define(resourceGroupName)
                 .WithRegion(Region.USWest2)
                 .CreateAsync();
        }
    }
}
